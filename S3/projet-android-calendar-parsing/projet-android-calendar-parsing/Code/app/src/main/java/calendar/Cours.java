package calendar;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.Date;

public class Cours {




    private String start;



    private String location;
    private String nomCours;
    private String description;


    public Cours(JSONObject object){


        try {
            location = (String) object.get("location");
            nomCours = (String) object.get("summary");
            description = (String) object.get("description");
            start = (String) object.get("start");

        } catch (JSONException e) {
            e.printStackTrace();
        }


    }
    public String getStart() {
        return start;
    }

    public String getLocation() {
        return location;
    }

    public String getNomCours() {
        return nomCours;
    }

    public String getDescription() {
        return description;
    }


    @Override
    public String toString(){
        return "name: "+nomCours + ", location: "+location + ", start "+start;
    }




}
