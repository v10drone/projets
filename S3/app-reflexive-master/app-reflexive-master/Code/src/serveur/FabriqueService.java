package serveur;

import java.net.Socket;

import bri.Service;
import services.ServiceAmateur;
import services.ServiceProgrammeur;

public class FabriqueService {

	public static Service getService(ServiceType nom,Socket sc) {

		if(nom.equals(ServiceType.AMATEUR))
			return new ServiceAmateur(sc);

		if(nom.equals(ServiceType.PROGRAMMEUR))
			return new ServiceProgrammeur(sc);
		return null;
	}
}
