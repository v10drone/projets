package calendar;


import android.Manifest;
import android.app.Activity;
import android.content.Context;
import android.content.pm.PackageManager;
import android.os.Build;
import android.util.Log;
import android.widget.Toast;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

//Documentation de la librairie ical4j.Calendar "http://ical4j.sourceforge.net/introduction.html"
public class ICSCalendar extends AppCompatActivity {

    private static final int PERMISSION_STORAGE_CODE = 1000;
   // private static final String CALENDAR__API_URL = "http://10.0.2.2:3000/dowloadParse";
    private static final String CALENDAR__API_URL = "https://e49d7452.ngrok.io/dowloadParse";
    private String calendarURL;
    private Context context;
    private Activity activity;
    private Boolean dataLoaded;
    private ICSCalendarDataReadyListener listener;

    private HashMap<String,Cours> listCours;




    public ICSCalendar(Context context, Activity activity, String url_path){

        calendarURL = url_path;
        this.context = context;
        this.activity = activity;
        dataLoaded = false;
        listCours = new HashMap<>();


    }





    /**
     *
     */
    public void downloadFile(ICSCalendarDataReadyListener listener) {
        this.listener = listener;
        //Si la version de android est marshmallow ou supérieur on doit gérer les permisssion nous même
        if (Build.VERSION.SDK_INT > Build.VERSION_CODES.M) {

            //On regarde si la permission "write external storage" est refusé
            if (ContextCompat.checkSelfPermission(context,Manifest.permission.WRITE_EXTERNAL_STORAGE) == PackageManager.PERMISSION_DENIED) {
                //Permission denied

                String[] permissions = {Manifest.permission.WRITE_EXTERNAL_STORAGE};

                //On demande maintenant la permission à l'utilisateur et on récupère le résultat dans la fonction  OnRequestPermissionResult
                ActivityCompat.requestPermissions(activity,permissions, PERMISSION_STORAGE_CODE);

            }
        }
        //A partir d'ici on a toutes les autorisations pour faire le téléchargement
        startDownloadFromApi(listener);
    }


    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {

        switch (requestCode) {
            case PERMISSION_STORAGE_CODE: {
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    startDownloadFromApi(listener);
                } else {
                    Toast.makeText(this, "Permission non accordé, la synchronisation n'a pas eu lieu", Toast.LENGTH_SHORT).show();
                }
            }
        }
    }

    public void startDownloadFromApi(ICSCalendarDataReadyListener listener) {

        Log.d("DEBUG","start API");


        RequestQueue requestQueue;

        // Instantiate the RequestQueue with the cache and network.
        requestQueue =  Volley.newRequestQueue(context.getApplicationContext());

        // Start the queue
        requestQueue.start();

        //On crée le json qui servira de paramètre à notre API
        Map<String, String> params = new HashMap<String, String>();
        params.put("calendarURL", calendarURL);

        JSONObject parameters = new JSONObject(params);


        Log.d("DEBUG","start params");

        //ICI
        JsonObjectRequest request = new JsonObjectRequest
                (Request.Method.POST, CALENDAR__API_URL, parameters, new Response.Listener<JSONObject>() {

                    @RequiresApi(api = Build.VERSION_CODES.N)
                    @Override
                    public void onResponse(JSONObject response) {
                        try {
                            Log.d("DEBUG",response.toString());

                            //On va itérer parmis chaque jour de la semaine
                            List<String> joursSemaine = getKeyOrdered(response);

                            for(String jour : joursSemaine){

                                Log.d("DEBUG","Jour: "+jour);
                                JSONObject coursJson = (JSONObject) response.get(jour);

                                List<String> coursDuJour = getKeyOrdered(coursJson);

                                if(coursDuJour.size() > 0){
                                    String cours = coursDuJour.get(0);
                                    //Dans le tableau on retrouve les cours pour le cours en question
                                    JSONArray prochainJourCour = (JSONArray) coursJson.get(cours);
                                    JSONObject premierCour = (JSONObject) prochainJourCour.get(0);
                                    listCours.put(jour.toUpperCase(),new Cours(premierCour));
                                    //Log.d("DEBUG","Premier cours pour la journée de " + jour + " : "+premierCour.toString());;

                                }

                            }
                        } catch (JSONException e) {
                            Log.d("DEBUG",e.toString());
                        }



                        //Log.d("DEBUG",test.toString());

                        // JSONArray tabLundi = (JSONArray) test.get("28/2/2020");
                        // Log.d("DEBUG", "Longeur tab " + String.valueOf(tabLundi.length()));
                        dataLoaded = true;
                        listener.dataReady();
                    }
                }, new Response.ErrorListener() {

                    @Override
                    public void onErrorResponse(VolleyError error) {

                        Log.d("DEBUG", error.toString());

                    }
                });

        Log.d("DEBUG","before add");
        requestQueue.add(request);
        Log.d("DEBUG","after add");



    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    private List<String> getKeyOrdered(JSONObject object){

        Iterator iterator = object.keys();
        List<String> orderedKey = new ArrayList<String>();


        while(iterator.hasNext()){
            orderedKey.add((String)iterator.next());
        }


        Collections.sort(orderedKey, new Comparator<String>() {
            @Override
            public int compare(String o1, String o2) {
                return o1.compareTo(o2);
            }
        });

        return orderedKey;
    }



    public Cours getCours(String jour){
        return listCours.get(jour);
    }

    public boolean isDataReady() {
        return dataLoaded;
    }
}
