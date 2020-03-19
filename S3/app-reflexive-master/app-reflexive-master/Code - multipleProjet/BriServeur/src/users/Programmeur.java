package users;



public class Programmeur extends Amateur{
	
	private String ftpURL;
	
	public Programmeur(String login, String mdp, String mail,String ftpURL) {
		super(login, mdp, mail);
		this.ftpURL = ftpURL;
	}
	

	public String getFtpURL() {
		return ftpURL;
	}

	public void setFtpURL(String ftpURL) {
		this.ftpURL = ftpURL;
	}


}
