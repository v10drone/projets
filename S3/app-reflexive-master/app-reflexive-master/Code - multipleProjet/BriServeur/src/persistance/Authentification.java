package persistance;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import users.Amateur;
import users.Programmeur;

public class Authentification {
	
	private static final String LOGIN_BD = "SYSTEM";
	private static final String MDP_BD = "toto";
		
	//Création de l'objet programmeur
	
	public static Programmeur verifProgrammeur(String login ,String mdp) {
		
		try {
			String req1 ="SELECT * FROM PROGRAMMEUR WHERE login_p = ? AND mdp_p = ?";
			Connection conn = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:XE", LOGIN_BD,MDP_BD);
			PreparedStatement pst = conn.prepareStatement(req1);
			pst.setString(1,login);
			pst.setString(2,mdp);
		
			
			ResultSet res = pst.executeQuery();
			
			while (res.next()) {
				
				String log = res.getString("login_p");
				String password = res.getString("mdp_p");
				String mail  = res.getString("mail");
				String url = res.getString("url");

				return new Programmeur(log, password, mail, url);
			}
			
			res.close();
			pst.close();
			conn.close();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return null;
		
	}
	

	//Création de l'objet Amateur
	public static Amateur verifAmateur(String login ,String mdp) {
		
		try {
			String req1 ="SELECT * FROM AMATEUR WHERE login = ? AND mdp = ?";
			Connection conn = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:XE", LOGIN_BD, MDP_BD);
			PreparedStatement pst = conn.prepareStatement(req1);
			pst.setString(1, login);
			pst.setString(2, mdp);
			
			ResultSet res = pst.executeQuery(req1);
			
			while (res.next()) {
				String login_a = res.getString("login"); 
				String mdp_a = res.getString("mdp");
				String mail_a = res.getString("mail");
				
				return new Amateur(login_a, mdp_a, mail_a);
			}
			
			res.close();
			pst.close();
			conn.close();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return null;	
	}
	
}
