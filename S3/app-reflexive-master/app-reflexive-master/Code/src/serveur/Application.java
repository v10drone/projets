package serveur;


public class Application {
	
	private static int PORT_AMATEUR = 2500;
	private static int PORT_PROGRAMMEUR = 2600;
	
	
	public static void main(String[] args) {
		try {
			Class<?> oracleDriver = Class.forName("oracle.jdbc.OracleDriver");
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}

		new Thread(new ServeurBRiLaunch(PORT_PROGRAMMEUR,ServiceType.PROGRAMMEUR)).start();
		new Thread(new ServeurBRiLaunch(PORT_AMATEUR,ServiceType.AMATEUR)).start();
		
		
	}
	
	
	

	
	

}
