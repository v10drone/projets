package serveur;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

import bri.Service;

public class ServeurBRiLaunch implements Runnable{

	private ServerSocket serveur;
	private ServiceType serviceName;
	private int port;

	public ServeurBRiLaunch(int port, ServiceType s) {
		try {
			serveur = new ServerSocket(port);
			serviceName = s;
			this.port = port;
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Override
	public void run() {
		System.out.println("Lancement du service '"+serviceName+"' au port " + port);
		try {
			while(true) {
				Socket clientSocket = serveur.accept();
				Service service = FabriqueService.getService(serviceName,clientSocket);
				new Thread(service).start();
			}	
		} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

	}



}

