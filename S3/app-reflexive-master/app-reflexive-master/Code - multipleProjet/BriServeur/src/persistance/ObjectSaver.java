package persistance;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import users.Programmeur;

public class ObjectSaver {
	
	private static final String LOGIN_BD = "SYSTEM";
	private static final String MDP_BD = "toto";
		

	public static void updateProgrammeur(Programmeur p) {
		try {
			String req1 ="UPDATE programmeur SET login_p = ? , mdp_p = ? , mail = ?, url = ? where login_p = ?";
			Connection conn = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:XE", LOGIN_BD,MDP_BD);
			PreparedStatement pst = conn.prepareStatement(req1);
			pst.setString(1,p.getLogin());
			pst.setString(2,p.getMdp());
			pst.setString(3,p.getMail());
			pst.setString(4,p.getFtpURL());
			pst.setString(5,p.getLogin());
			
		
			
			System.out.println(pst.executeUpdate());
			
			pst.close();
			conn.close();
			
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
}
