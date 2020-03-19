package adresse;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.EditText;
import android.widget.Toast;

import com.example.pjandroid.Config3_4;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

//Android n'autorise pas les tâches en arrière-plan dans le main
//Car cela signifierai que l'appli va froze et donc NO GOOD !
//Donc faut faire une autre classe qui va fetch les datas
//= CREER UN AUTRE THREAD qui va s'en occuper sans froze l'app
public class AdresseAPI extends AsyncTask<Void, Void, Void> {
    private static final String SHARED_PREF_NAME = "alarm_conf";
    private static Activity activity;
    private EditText[] adresses;
    private EditText[] cp;
    private Boolean[] bool;


    public AdresseAPI(EditText adresseD, EditText villeD, EditText adresseT, EditText villeT) {
        super();
        bool = new Boolean[2];
        adresses = new EditText[2];
        cp = new EditText[2];
        adresses[0] = adresseD;
        cp[0] = villeD;
        adresses[1] = adresseT;
        cp[1] = villeT;
    }

    public static void setActivity(Activity a) {
        activity = a;
    }

    public boolean getBool(int i) {
        return bool[i];
    }

    protected Void doInBackground(Void... Voids) {
        for (int i = 0; i <= 1; i++) {
            String a = adresses[i].getText().toString().replaceAll(" ", "+");
            String v = cp[i].getText().toString();
            String lien = "https://api-adresse.data.gouv.fr/search/?q=" + a + "&postcode=" + v;
            Log.d("DEBUG", lien);
            try {
                URL url = new URL(lien);
                HttpURLConnection co = (HttpURLConnection) url.openConnection(); //Connexion au site
                InputStream in = co.getInputStream();
                BufferedReader out = new BufferedReader(new InputStreamReader(in));//to read data from this input stream
                String line = "";
                String data = "";
                while (line != null) {
                    line = out.readLine();
                    data = data + line; //contient tte les data du JSON
                }
                JSONObject ja = new JSONObject(data);
                JSONArray features = (JSONArray) ja.get("features");
                Log.d("DEBUG", ja.toString());
                Log.d("DEBUG", features.length() + "");
                if (features.length() == 1) {
                     bool[i] = true;
                }

            } catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            } catch (JSONException e) {
                e.printStackTrace();
            }
        }
        return null;
    }

    @Override
    protected void onPostExecute(Void aVoid) {
        super.onPostExecute(aVoid);
        int count = 0;
        String pb = "";
        for (Boolean bool : bool) {
            for (int i = 0; i <= 1; i++) {
                Log.d("DEBUG","totot 1" + bool);
                if (!bool){
                    count++;
                    pb += "'" + adresses[i].getText().toString() + " " + cp[i].getText().toString() + "'\n";
                }
            }
        }


        if (count > 0) {
            String msg = "Veuillez vérifier les adresses suivantes:\n " + pb;
            Toast.makeText(activity, msg, Toast.LENGTH_LONG).show();
        }else{
            String origin = adresses[0].getText().toString() + ", "+ cp[0].getText().toString();
            String destination = adresses[1].getText().toString() + ", "+ cp[1].getText().toString();

            new Itinerary(activity).getTravelTime(origin,destination, new ItinerayDataReadyListener() {
                @Override
                public void dataReady(int time) {
                    int travelTime = time;

                    SharedPreferences pref = activity.getApplicationContext().getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode
                    SharedPreferences.Editor editor = pref.edit();

                    Log.d("DEBUG","data ready");


                    editor.putInt("TRAVEL_TIME", time);
                    editor.commit();

                    //A changer
                    Intent intent = new Intent(activity.getApplicationContext(), Config3_4.class);
                    activity.startActivity(intent);

                }
            });
        }
    }
}