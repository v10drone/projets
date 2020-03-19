package services;

import java.io.BufferedReader;

import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.lang.reflect.InvocationTargetException;
import java.net.Socket;
import java.net.URL;
import java.net.URLClassLoader;
import java.util.Vector;

import bri.Service;
import persistance.Authentification;
import persistance.ObjectSaver;
import tools.Encoder;
import users.Programmeur;



public class ServiceProgrammeur implements Service{

	private Socket socket;
	private Programmeur programmeur;

	private BufferedReader sin;
	private PrintWriter sout;
	private URLClassLoader loader;


	public ServiceProgrammeur(Socket s) {	
		socket = s;
	}


	@SuppressWarnings("static-access")
	@Override
	public void run() {

		// --- Authentification ----

		System.out.println("Nouveau client");
		try {	
			sin = new BufferedReader(new InputStreamReader(socket.getInputStream()));
			sout = new PrintWriter(socket.getOutputStream(),true);


			//Authentification
			//Demande login et mdp			
			String login = "";
			String mdp = "";

			do {

				String message =   "Bonjour et bienvenue sur notre plateforme ! \n"
						+ "Veuillez vous connecter : \n"
						+ "Login : ";

				sout.println(Encoder.encode(message));


				login = sin.readLine();

				sout.println("Mot de passe : ");
				mdp = sin.readLine();

				System.out.println("login et mdp reçu, place à la vérification ...");

				if(login == "" & mdp == "");

				programmeur = Authentification.verifProgrammeur(login, mdp); // ça va instancier un programmeur 
				if(programmeur == null) {
					sout.println("Echec de l'authentification");
					this.socket.close();
				}

			}while(programmeur == null);


			System.out.println("Authentification terminée");
			System.out.println(programmeur.getFtpURL());


			System.out.println(programmeur.getFtpURL() + programmeur.getLogin());
			loader = new URLClassLoader(new URL[] {new URL(programmeur.getFtpURL())}) {

				@Override
				public Class<?> loadClass(String classeName) throws ClassNotFoundException {

					if(classeName.equals("bri.Service")) {
						return Class.forName(classeName);
					}
					System.out.println(classeName);
					return super.loadClass(classeName);
				}
			};

			String error = "";
			String line = "";
			String lastAction = "";

			while(true) {	

				//Envoie le menu
				line = Encoder.encodeError(error) 
						+ lastAction
						+ "Menu => \n"
						+ "1 : Nouveau service \n"
						+ "2 : Mis jour d'un service \n"
						+ "3 : Changement de votre adresse FTP \n"
						+ "4 : Démarer un service \n"
						+ "5 : Arrêter un service";

				sout.println(Encoder.encode(line));

				line = sin.readLine();
				lastAction = "";
				error = "";

				if (line == null) break; // fermeture par le client

				int choix = -1;
				try {
					choix = Integer.parseInt(line);
				}catch(NumberFormatException e) {
					e.printStackTrace();
					error += "Choix invalide";
					continue;
				}

				try {
					switch (choix) {
					case 1:
						newService();
						lastAction = "Nouveau service ajouté !\n";
						break;
					case 2:
						misAJour();
						lastAction = "Mis  jour effectué !\n";
						break;
					case 3:
						changementFTP();
						lastAction = "Mis  jour de l'url de votre serveur FTP effectué !\n";
						break;
					case 4 :
						changeServiceStatus(true);
						lastAction = "Service démarré avec succès! \n";
						break;
					case 5 :
						changeServiceStatus(false);
						lastAction = "Service stoppé avec succès! \n";
						break;
					}
				}catch(BriException e) {
					e.printStackTrace();
					error += e.getMessage();
				}catch(NumberFormatException e) {
					e.printStackTrace();
					error += "Vous devez saisir un numro";
				}
			}

		}catch(IOException e) {
			e.printStackTrace();
		}



	}


	// ---- SERVICE -----
	//Status == true => On veut démarer un service on va donc afficher ceux qui sont arrété
	//Status == false => L'inverse
	private void changeServiceStatus(boolean status) throws BriException, NumberFormatException, IOException {

		//On récupère la liste des service que le programmeur a déjà ajouté
		Vector<ObjectWrapper<Class<? extends Service>>> services = null;
		try {
			services = ServiceRegistry.getServices(programmeur.getLogin());
		}catch(IllegalArgumentException e) {
			//Déclanché si le programmeur n'a ajouté aucun service
			throw new BriException("Vous n'avez ajouté aucun service");
		}

		System.out.println(services.size());

		//On va récup le nom de chaque service à l'aide la leurs méthode 'toStringue'
		StringBuilder s = new StringBuilder();
		for (int i = 0; i < services.size() ; i++) {
			
			if(services.get(i).isStarted() == status) {
				continue;
			}
			
			Class<? extends Service> serviceClass  = services.get(i).getObject();


			try {
				//On instancie un objet service à l'aide l'objet class
				//Et on appel ensuite la méthode toStringue
				Service service = (Service) serviceClass.getDeclaredConstructor(Socket.class).newInstance(socket);
				s.append( "\t" + (i + 1)  + ") " +serviceClass.getDeclaredMethod("toStringue").invoke(service) + "\n" );

			} catch (InstantiationException | IllegalAccessException | IllegalArgumentException
					| InvocationTargetException | NoSuchMethodException | SecurityException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}
		
		
		if(s.toString().isEmpty()) {
			//Déclanché si le programmeur n'a ajouté aucun service
			throw new BriException("Tous vos service sont " + ((status) ? "actifs" : "arrétés"));
		}
		
		
		sout.println(Encoder.encode("Voici la liste des services "+ ((status) ? "arrétés" : "actifs") +" lequel voulez vous "+ ((status) ? "démarrer" : "stopper")  + " ? \n" + 
				s.toString()));


		int choix = Integer.parseInt(sin.readLine());
		if(choix > services.size() || choix < 1) {
			throw new BriException("Choix non valide");
		}
		
		//On doit récup le ObjectWrapper choisi
		
		for (ObjectWrapper<Class<? extends Service>> objectWrapper : services) {
			
			if(objectWrapper.isStarted() != status) {
				choix--;
				//On la trouvé
				if(choix == 0) {
					objectWrapper.setStatus(status);
					break;
				}
			}
			
		}




	}


	private void newService() throws BriException, IOException {

		sout.println("Quelle est le nom fichier .class ?");

		String classeName = "";
		classeName = sin.readLine().trim();
		System.out.println(classeName);

		//On met 2 \\ car le . est un caractre qui veut dire 
		//Nimporte quelle lettre en expression rgulire
//		if(!classeName.split("\\.")[0].equals(programmeur.getLogin())) {
//			throw new BriException("Votre travail doit être dans un package portant comme nom votre login qui est : " +programmeur.getLogin());
//		}


		// charger la classe et la dclarer au ServiceRegistry
		Class<?> classCharg = loadClass(classeName);

		ServiceRegistry.addService(programmeur.getLogin(),(Class<?>) classCharg);


	}

	private void misAJour() throws NumberFormatException, IOException, BriException {

		//Pour la mis à jour on doit refaire un URLClassLoader
		loader = new URLClassLoader(new URL[] {new URL(programmeur.getFtpURL())}) {
			@Override
			public Class<?> loadClass(String classeName) throws ClassNotFoundException {

				if(classeName.equals("bri.Service")) {
					return Class.forName(classeName);
				}

				System.out.println(classeName);

				return super.loadClass(classeName);
			}
		};

		//On récupère la liste des service que le programmeur a déjà ajouté
		Vector<ObjectWrapper<Class<? extends Service>>> services = null;
		try {
			services = ServiceRegistry.getServices(programmeur.getLogin());
		}catch(IllegalArgumentException e) {
			//Déclanché si le programmeur n'a ajouté aucun service
			throw new BriException("Vous n'avez ajouté aucun service");
		}

		System.out.println(services.size());

		//On va récup le nom de chaque service à l'aide la leurs méthode 'toStringue'
		StringBuilder s = new StringBuilder();
		for (int i = 0; i < services.size() ; i++) {

			Class<? extends Service> serviceClass  = services.get(i).getObject();


			try {
				//On instancie un objet service à l'aide l'objet class
				//Et on appel ensuite la méthode toStringue
				Service service = (Service) serviceClass.getDeclaredConstructor(Socket.class).newInstance(socket);
				s.append( "\t" + (i + 1)  + ") " +serviceClass.getDeclaredMethod("toStringue").invoke(service) + "\n" );

			} catch (InstantiationException | IllegalAccessException | IllegalArgumentException
					| InvocationTargetException | NoSuchMethodException | SecurityException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}

		sout.println(Encoder.encode("Voici la liste des services lequel voulez vous mettre à jour ? \n" + 
				s.toString()));


		int choix = Integer.parseInt(sin.readLine());
		if(choix > services.size() || choix < 1) {
			throw new BriException("Choix non valide");
		}


		Class<? extends Service> serviceSelected = services.get(choix-1).getObject();
		Class<? extends Service> serviceUpdated = (Class<? extends Service>) loadClass(serviceSelected.getName());
		services.set(choix-1,new ObjectWrapper<Class<? extends Service>>(serviceUpdated));

	}


	private void changementFTP() throws BriException {



		try {
			sout.println("Quelle est la nouvelle URL de votre FTP ?");
			String ftpUrl = sin.readLine().trim();


			if(!ftpUrl.contains("ftp://")) {
				throw new BriException("Url Ftp incorrect");
			}

			programmeur.setFtpURL(ftpUrl);
			loader = new URLClassLoader(new URL[] {new URL(programmeur.getFtpURL())}) {
				@Override
				public Class<?> loadClass(String classeName) throws ClassNotFoundException {

					if(classeName.equals("bri.Service")) {
						return Class.forName(classeName);
					}
					System.out.println(classeName);
					return super.loadClass(classeName);
				}
			};

			ObjectSaver.updateProgrammeur(programmeur);



		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}


	}

	private Class<?> loadClass(String classeName) throws BriException{
		Class<?> classChargé = null;
		try {
			classChargé = loader.loadClass(classeName);
			return classChargé;

		}catch(ClassNotFoundException ex) {
			throw new BriException("La Classe '"+ classeName  + "' est introuvable");
		}


	}

	@Override
	protected void finalize() throws Throwable {
		super.finalize();
		this.socket.close();
		loader.close();
	}
}
