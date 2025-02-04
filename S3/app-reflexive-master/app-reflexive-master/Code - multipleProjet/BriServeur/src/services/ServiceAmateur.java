package services;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.lang.reflect.InvocationTargetException;
import java.net.Socket;
import java.util.Hashtable;
import java.util.Set;
import java.util.Vector;

import bri.Service;
import tools.Encoder;
import users.Programmeur;

public class ServiceAmateur implements Service{



	private Socket socket;
	private Programmeur programmeur;

	private BufferedReader sin;
	private PrintWriter sout;


	public ServiceAmateur(Socket sc) {
		socket = sc;
	}

	@Override
	public void run() {

		System.out.println("Nouveau client");
		try {	
			sin = new BufferedReader(new InputStreamReader(socket.getInputStream()));
			sout = new PrintWriter(socket.getOutputStream(),true);




			Hashtable<String, Vector<ObjectWrapper<Class<? extends Service>>>> allServices = ServiceRegistry.getServices();
			String line ="";
			String error = "";



			while(true) {

				StringBuilder s = new StringBuilder();

				int index = 1;

				s.append("Bonjour et bienvenue sur notre plateforme ! \n"
						+ "Voici la liste des services disponible :\n");

				Set<String> keys=   allServices.keySet();

				for(String key : keys) {


					Vector<ObjectWrapper<Class<? extends Service>>> services = allServices.get(key);

					for (ObjectWrapper<Class<? extends Service>> serviceWrapper : services) {

						//Si le service n'est pas d�mar� on ne fait rien
						if(!serviceWrapper.isStarted()) {
							continue;
						}
						
						Class<? extends Service> serviceClass  = serviceWrapper.getObject();
						
						
						
						try {
							//On instancie un objet service � l'aide l'objet class
							//Et on appel ensuite la m�thode toStringue
							Service service = (Service) serviceClass.getDeclaredConstructor(Socket.class).newInstance(socket);


							s.append( "\t " + index +") " +serviceClass.getDeclaredMethod("toStringue").invoke(service) + " ("+  key +")\n" );

							index++;
						} catch (InstantiationException | IllegalAccessException | IllegalArgumentException
								| InvocationTargetException | NoSuchMethodException | SecurityException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
					}
				}

				if(index == 1) {
					s.append("\tAucun service disponible pour le moment ");
				}
				sout.println(Encoder.encode( Encoder.encodeError(error)  + s.toString()));
				
				if(index == 1) {
					return;
				}


				line = sin.readLine();

				if (line == null) break; // fermeture par le client

				int choix = -1;
				try {
					choix = Integer.parseInt(line);
					
					
					if(choix > index || choix < 1) {
						error += "Choix invalide \n";
						continue;
					}
					
				}catch(NumberFormatException e) {
					e.printStackTrace();
					error += "Vous devez saisir un numro \n";
					continue;
				}


				for (String key : keys) {
					
					
					int nbServiceStarted = 0;

					for(ObjectWrapper<Class<? extends Service>> serviceWrapper : allServices.get(key)) {
						if(serviceWrapper.isStarted())
							nbServiceStarted++;
					}
					

					if(choix - nbServiceStarted > 0) {
						choix -= allServices.get(key).size();
					}else {

						try {
							Class<? extends Service> serviceSelected = allServices.get(key).get(choix-1).getObject();


							Service service = (Service) serviceSelected.getDeclaredConstructor(Socket.class).newInstance(socket);

							new Thread(service).start();;
							return;

						} catch (InstantiationException | IllegalAccessException | IllegalArgumentException
								| InvocationTargetException | NoSuchMethodException | SecurityException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}

					}

				}


			}


		}catch(IOException ex) {
			ex.printStackTrace();
		}





	}

	

	@Override
	protected void finalize() throws Throwable {
		super.finalize();
		this.socket.close();
	}


}
