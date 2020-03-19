package adresse;

import android.content.Context;
import android.os.Build;
import android.util.Log;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import calendar.Cours;

public class Itinerary {

    private static final String Travel_API_URL = "https://e49d7452.ngrok.io/itineraire";
    private Context context;

    public Itinerary(Context c){
        context = c;
    }


    public void getTravelTime(String origin , String destination,ItinerayDataReadyListener listener){




        RequestQueue requestQueue;

        // Instantiate the RequestQueue with the cache and network.
        requestQueue =  Volley.newRequestQueue(context);

        // Start the queue
        requestQueue.start();


        final String URL = Travel_API_URL + "?departure="+origin+"&arrival="+destination;
        //ICI
        JsonObjectRequest request = new JsonObjectRequest
                (Request.Method.GET, URL, null, new Response.Listener<JSONObject>() {

                    @Override
                    public void onResponse(JSONObject response) {
                        try {
                            Log.d("DEBUG",response.toString());

                            int time = response.getInt("duration");
                            listener.dataReady(time);

                        } catch (JSONException e) {
                            Log.d("DEBUG",e.toString());
                        }
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


}
