package tools;


import org.apache.commons.lang3.StringUtils;

public class Encoder {

	public static final String LINE_BREAK = "###";
	private static final String ERROR_TAG = "<error>";
	public static final String END_COMMUNICATION = "<end>";
	
	public static String encode(String chaine) {
		return chaine.replace("\n", LINE_BREAK);
	}
	
	
	public static String encodeError(String chaine) {
		return (chaine.length() > 0 ) ? ERROR_TAG + chaine + ERROR_TAG : "";
	}
	
	public static String getErrors(String chaine) {
		
		return StringUtils.substringBetween(chaine,ERROR_TAG);
				
	}
	
	public static String decode(String chaine) {
		return chaine.replace(LINE_BREAK, "\n").replace(END_COMMUNICATION,"").replaceAll(ERROR_TAG + ".*" +ERROR_TAG,"");	
	}
	
	
	
	public static String addEndCommunication(String chaine) {
		return chaine + END_COMMUNICATION;
	}
	
	
	public static boolean isEndCommunication(String chaine) {
		return chaine.contains(END_COMMUNICATION);
	}


}
