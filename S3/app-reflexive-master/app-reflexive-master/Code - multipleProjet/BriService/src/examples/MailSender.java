package examples;

import java.io.UnsupportedEncodingException;
import java.util.Properties;

import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;

import org.json.JSONObject;



public class MailSender {


	private static final int PRETTY_INDENT = 4;

	private String fromEmail;
	private String fromName;

	private String toEmail;
	private String toName;

	private String smtpHost;
	private String smtpUsername;
	private String smtpPassword;
	private Integer smtpPort = 587;

	private String subject;
	private String content;

	public MailSender setFrom(String fromEmail, String fromName) {
		assert (fromEmail.length() != 0);
		assert (fromName.length() != 0);
		this.fromEmail = fromEmail;
		this.fromName = fromName;

		return this;
	}

	public MailSender setTo(String toEmail, String toName) {
		assert (toEmail.length() != 0);
		assert (toName.length() != 0);
		this.toEmail = toEmail;
		this.toName = toName;

		return this;
	}

	public MailSender setHost(String host, Integer port) {
		assert (toEmail.length() != 0);
		assert (toName != null);
		this.smtpHost = host;
		this.smtpPort = port;

		return this;
	}

	public MailSender setAuth(String username, String password) {
		assert (username.length() != 0);
		assert (password.length() != 0);
		this.smtpUsername = username;
		this.smtpPassword = password;

		return this;
	}

	public MailSender setSubject(String subject) {
		assert (subject.length() != 0);
		this.subject = subject;
		return this;
	}

	public MailSender setContent(String content) {
		assert (content.length() != 0);
		this.content = content;
		return this;
	}

	// https://docs.aws.amazon.com/fr_fr/ses/latest/DeveloperGuide/send-using-smtp-java.html
	public void send() throws UnsupportedEncodingException, MessagingException {
		Properties props = System.getProperties();
		props.put("mail.transport.protocol", "smtp");
		props.put("mail.smtp.port", this.smtpPort);
		props.put("mail.smtp.starttls.enable", "true");
		props.put("mail.smtp.auth", "true");
		props.put("mail.smtp.ssl.trust", "*");

		Session session = Session.getDefaultInstance(props);

		MimeMessage msg = new MimeMessage(session);
		msg.setFrom(new InternetAddress(this.fromEmail, this.fromName));
		msg.setRecipient(Message.RecipientType.TO, new InternetAddress(this.toEmail));
		msg.setSubject(this.subject);
		msg.setContent(this.content, "text/plain");

		Transport transport = session.getTransport();

		try {
			System.out.println("Sending...");

			transport.connect(this.smtpHost, this.smtpUsername, this.smtpPassword);
			transport.sendMessage(msg, msg.getAllRecipients());
			System.out.println("Email sent!");
		} catch (Exception ex) {

			System.out.println("The email was not sent.");
			System.out.println("Error message: " + ex.getMessage());
			ex.printStackTrace();
		} finally {
			transport.close();
		}
	}


	public static void sendRapportTo(String email,JSONObject data) throws UnsupportedEncodingException, MessagingException {

		

		(new MailSender())
		.setFrom("email", "Service Inversion KEITA_VIGNARAJAH")
		.setTo(email,"")
		.setHost("smtp.gmail.com", 587)
		.setAuth("devcompte44", "slnidhqgxsfoszos")
		.setSubject("Rapport Service XML !")
		.setContent("Bonjour,\n"
				+ data.toString(PRETTY_INDENT))
		.send();

	}

}
