package examples;


import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Scanner;

import javax.mail.MessagingException;

import org.apache.commons.net.ftp.FTP;
import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;
import org.json.JSONObject;
import org.json.XML;

import bri.Service;
import tools.Encoder;


public class ServiceXML implements Service {

	private static FTPClient ftpClient;

	private static final int PRETTY_INDENT = 4;
	

	BufferedReader in ;
	PrintWriter out;


	private final Socket client;
	public ServiceXML(Socket sc) {
		client = sc;
	}


	public static void main(String[] args) throws MessagingException {

//
		// Establish a connection with the FTP URL
//		try {
//
//			ftpClient = new FTPClient();
//			ftpClient.connect("localhost",2121);
//			// Enter user details : user name and password
//			boolean isSuccess = ftpClient.login("anonymous","");
//			ftpClient.enterLocalPassiveMode();
//			ftpClient.setFileType(FTP.BINARY_FILE_TYPE);
//
//
//			System.out.println(getAllFiles());
//
//
////			JSONObject jsonObject =  XML.toJSONObject(fileToString("./testFile.xml"));
////
////			MailSender.sendRapportTo("keitadk9@gmail.com",jsonObject);
//
//
//
//		} catch (IOException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
	}

	public static String getAllFiles() throws IOException {

		FTPFile[] files = ftpClient.listFiles();

		DateFormat dateFormater = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		StringBuilder s = new StringBuilder();

		for (FTPFile file : files) {
			String details = file.getName();
			if (file.isDirectory() || !file.getName().toLowerCase().contains(".xml")) {
				continue;
			}
			details += "\t\t" + file.getSize();
			details += "\t\t" + dateFormater.format(file.getTimestamp().getTime());
			s.append(details + "\n");
		}

		return s.toString();

	}


	public static String fileToString(String path) throws IOException {

		StringBuilder s = new StringBuilder();
		InputStream inputStream = ftpClient.retrieveFileStream(path);
		@SuppressWarnings("resource")
		Scanner sc = new Scanner(inputStream);
		while (sc.hasNextLine()) {
			s.append(sc.next().replaceAll("\t", ""));
		}

		return s.toString();

	}



	public void run() {
		try {

			in = new BufferedReader (new InputStreamReader(client.getInputStream ( )));
			out = new PrintWriter (client.getOutputStream ( ), true);

			out.println("Quelle est l'url de votre FTP");
			String ftpUrl = in.readLine().trim();


			
			out.println("Quelle est votre identifiant de connexion");
			String username = in.readLine().trim();
			
			out.println("Quelle est votre mot de passe de connexion");
			String password = in.readLine();
			password = (password == null) ? "" : password;

			ftpClient = new FTPClient();

			System.out.println(ftpUrl);
			System.out.println(username);
			System.out.println(""+password+"'");
			
			ftpClient.connect(ftpUrl,2121);
			// Enter user details : user name and password
			boolean isSuccess = ftpClient.login(username,password+"");			
			ftpClient.enterLocalPassiveMode();
			ftpClient.setFileType(FTP.BINARY_FILE_TYPE);
			
			if(!isSuccess) {
				out.println("Echec de l'authentification");
				return;
			}
			
			
			
		
			out.println(Encoder.encode("Voici la liste des fichier lequel voulez vous convertir: \n" + getAllFiles()));
			String fileName = in.readLine();
			JSONObject jsonObject =  XML.toJSONObject(fileToString("./"+fileName));
			out.println("Quelle est votre mail ?");
			String mail = in.readLine();
			
			try {
				MailSender.sendRapportTo(mail,jsonObject);
				out.println(Encoder.encode("Le rapport a été envoyé.\nA bientôt"));
			} catch (MessagingException e) {
				out.println(Encoder.encodeError("Une erreur est survenue lors de l'envoie du mail"));
			}
			


		}
		catch (IOException e) {
			e.printStackTrace();
			out.println(Encoder.encodeError("Une erreur est survenue"));
		}
	}
	
	protected void finalize() throws Throwable {
		 client.close(); 
	}

	public static String toStringue() {
		return "Convertisseur de fichier XML en JSON";
	}



}
