package alarm;

import android.app.AlarmManager;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.provider.AlarmClock;
import android.util.Log;

import androidx.annotation.RequiresApi;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class AlarmConfigurator {

    private Context context;
    private static final String SHARED_PREF_NAME = "alarm_conf";
    private static List<Intent> alarmList = new ArrayList<>();

    public AlarmConfigurator(Context c){
        context =c;
    }


    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    public void setAlarm(){
        alarmList.clear();
        SharedPreferences pref = context.getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode

        List<String> joursSemaine = new ArrayList<String>(Arrays.asList("LUNDI","MARDI","MERCREDI","JEUDI","VENDREDI","SAMEDI","DIMANCHE"));
        List<Integer> joursSemaineAlarmClock = new ArrayList<Integer>(Arrays.asList(Calendar.MONDAY,Calendar.TUESDAY,Calendar.WEDNESDAY,Calendar.THURSDAY,Calendar.FRIDAY,Calendar.SATURDAY,Calendar.SUNDAY));

//        for(int i = 0 ; i < joursSemaine.size() ; i++):{
//
//            String jour = joursSemaine.get(i);
//
//        }

        Log.d("DEBUG","CONNFIGGS");
        //Exemple
        AlarmManager manager = (AlarmManager) context.getSystemService(Context.ALARM_SERVICE);
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("EEEE", Locale.FRENCH);
        //On récup le jour d'aujourdhui (LUNDI,MARDI...)
        String day_of_today = simpleDateFormat.format(new Date()).toUpperCase();





        //On va config les alarm pour chaque jour 
        for(int i = 0 ; i < joursSemaine.size() ; i++){

            for(int j = 0 ; j < pref.getInt("NB_ALARM",0) + 1 ; j++) {

                String jour = joursSemaine.get(i);
                //On récup l'heure d'activation et le fait que l'alarm soit réglé pour le jour en question
                String alarm_start = pref.getString(jour + "_HOUR_START", "");
                boolean isActivated = pref.getBoolean(jour + "_IS_ACTIVATED", false);

                if (!isActivated) {
                    continue;
                }

                Calendar cal_alarm = Calendar.getInstance();

                //On calcule la distance en jour entre aujourd'hui et le jour en question
                int indexToday = joursSemaine.indexOf(day_of_today);
                int indexTarget = joursSemaine.indexOf(jour);


                int day_distance = 0;

                if (indexTarget < indexToday) {
                    day_distance = joursSemaine.size() - indexToday;
                    day_distance += indexTarget;
                } else {
                    day_distance = indexTarget - indexToday;
                }

                cal_alarm.add(Calendar.DATE, day_distance);
                //On set maintenant l'heure

                int hours = Integer.parseInt(alarm_start.split(":")[0]) ;
                int minute = Integer.parseInt(alarm_start.split(":")[1]);


                cal_alarm.set(Calendar.HOUR_OF_DAY, hours);
                cal_alarm.set(Calendar.MINUTE, minute);
                cal_alarm.set(Calendar.SECOND, 0);

                //On ajoute l'interval pour la répétition

                cal_alarm.add(Calendar.MINUTE,pref.getInt("INTERVAL_ALARM",1)*(j+1));
                //Soustraire a partir d'ici tout les élément intermédiaire (  cal_alarm.add(Calendar.MINUTE,-20); ) enlève 20 minute à l'alarme par exemple

                int travelTime = pref.getInt("TRAVEL_TIME",0);
                cal_alarm.add(Calendar.MINUTE,-travelTime);


                ///Fin des soustraction

                Intent intent = new Intent(AlarmClock.ACTION_SET_ALARM);
                intent.putExtra(AlarmClock.EXTRA_SKIP_UI, true);

                ArrayList<Integer> alarmDays = new ArrayList<Integer>();
                alarmDays.add(joursSemaineAlarmClock.get(i));


                intent.putExtra(AlarmClock.EXTRA_DAYS, alarmDays);
                intent.putExtra(AlarmClock.EXTRA_HOUR, cal_alarm.get(Calendar.HOUR_OF_DAY));
                intent.putExtra(AlarmClock.EXTRA_MINUTES, cal_alarm.get(Calendar.MINUTE));
                intent.putExtra(AlarmClock.EXTRA_VIBRATE, pref.getBoolean("VIBREUR", false));
               // intent.putExtra(AlarmClock.EXTRA_RINGTONE)


                //On ajoute l'intent à la liste pour pouvoir désactiver le réveil plus tard si on veut
                alarmList.add(intent);
                context.startActivity(intent);
            }

//            Intent myIntent = new Intent(context, AlarmReceiver.class);
//            //Pour régler différent alarm on doit changer le second paramètre (c'est comme l'ID de notre alarm
//            PendingIntent pendingIntent = PendingIntent.getBroadcast(context, i+1, myIntent, PendingIntent.FLAG_ONE_SHOT);
//
//            Log.d("DEBUG","Configured for :"+ jour + " at " + cal_alarm.getTime().toString() + " Millis " + cal_alarm.getTimeInMillis() + "Vs " + Calendar.getInstance().getTimeInMillis());
//            manager.set(AlarmManager.RTC_WAKEUP,cal_alarm.getTimeInMillis(), pendingIntent);
//            Log.d("DEBUG","LAUCHED");
        }







    }
}
