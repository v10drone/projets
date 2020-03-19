package services;

import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Hashtable;
import java.util.Vector;
import java.util.stream.Collectors;

import bri.Service;

public class ServiceRegistry {
	
	private static  Hashtable<String,Vector<Class<? extends Service>>> services = new Hashtable<String, Vector<Class<? extends Service>>>();
	
	
	public static void addService(String login,Class<?> s) throws NotBriClassException {
		
		
		testBri(s);
		
		if(!services.containsKey(login)) {
			services.put(login,new Vector<Class<? extends Service>>());
		}
		services.get(login).add((Class<? extends Service>) s);
	}
	
	
	public static Vector<Class<? extends Service>> getServices(String login) {
		
		System.out.println(services.size());
		System.out.println(login);
		
		
		if(!services.containsKey(login))
			throw new IllegalArgumentException("Login n'existe pas: " + login);
		
		return services.get(login);
		
		
	}
	
	
	public static void removeService(String login,String className) {
		
		if(!services.containsKey(login))
			throw new IllegalArgumentException("Login n'existe pas: " + login);
		
		
		Vector< Class<? extends Service> > programmeurServices = services.get(login);
		
		
		for (int i = 0 ; i < programmeurServices.size() ; i++) {
			
			Class<? extends Service> classObject = programmeurServices.get(i);
			if(classObject.getSimpleName().equals(className)) {
				programmeurServices.remove(i);
				break;
			}
		}
	}
	
	
	public static void update(String login,int index) {
		

		if(!services.containsKey(login))
			throw new IllegalArgumentException("Login n'existe pas: " + login);
		
		Vector< Class<? extends Service> > programmeurServices = services.get(login);
		
		
		
		Class<? extends Service> serviceClass = programmeurServices.get(index);
		
		
		
		
		
		
	}
	
	
	public static boolean serviceExist(String login,String className) {
		if(!services.containsKey(login))
			return false;
		
		Vector< Class<? extends Service> > programmeurServices = services.get(login);
		
		
		return programmeurServices.stream().map( c -> c.getSimpleName())
		.collect(Collectors.joining(" ")).contains(className);
		
	}
	
	public static Hashtable<String,Vector<Class<? extends Service>>> getServices(){
		return services;
	}
	
	
	
	public static void testBri(Class<?> classe)  throws NotBriClassException {
		boolean estValide = true;
		StringBuilder errorLog  = new StringBuilder();


		//Check si la classe implement Serializable
		Class<?>[] interfaces = classe.getInterfaces();
		boolean b = (new ArrayList<Class<?>>(Arrays.asList(interfaces)).contains(Service.class));
		
		if(!b) {
			errorLog.append("\tVotre classe doit implémenter l'interface Service \n");
			estValide = false;
		}

		//Test si la classe n'est pas abstract
		if(Modifier.isAbstract(classe.getModifiers())) {
			errorLog.append("\tLa classe ne doit pas être abstract \n");
			estValide = false;
		}

		//Test si la classe est public
		if(!Modifier.isPublic(classe.getModifiers())) {
			errorLog.append("\tLa classe n'est pas public \n");
			estValide = false;
		}


		//Check si la classe à un constructeur avec une socket
		try{
			classe.getConstructor(Socket.class);
		}catch(NoSuchMethodException exception) {
			errorLog.append("\tVotre classe n'a pas de constructeur avec socket \n");
			estValide = false;
		}

		//Socket private final
		Field[] attributs = classe.getDeclaredFields();
		boolean hasSocketAttribute = false;
		for(Field attribut : attributs) {

			
			if(attribut.getType() == Socket.class) {

				if(Modifier.isPrivate(attribut.getModifiers()) && Modifier.isFinal(attribut.getModifiers())) {
					hasSocketAttribute = true;
					break;
				}
			}
		}

		if(!hasSocketAttribute) {
			errorLog.append("\tVotre classe n'a d'attribut de type Socket private final \n");
			estValide = false;
		}

		
		
		try {
			classe.getDeclaredMethod("toStringue");	
		}catch(NoSuchMethodException ex) {
			errorLog.append("\tVotre classe n'a pas de méthode toStringue\n");
			estValide = false;
			
		}
		
		if(!estValide) {
			throw new NotBriClassException("Classe nom comforme \nErreur(s) : \n" + errorLog);
		}

	}
	
	
	
	
	

}
