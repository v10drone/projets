package com.example.pjandroid;

import android.app.AlertDialog;
import android.app.TimePickerDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Objects;
import java.util.TimeZone;

import calendar.Cours;
import calendar.ICSCalendar;
import calendar.ICSCalendarDataReadyListener;
import fragments.TimePickerFragment;


public class Config3_4 extends AppCompatActivity {


    private static final int PERMISSION_STORAGE_CODE = 1000;
    //Variable qui contiendra l'URL de synhronisation
    private String file_url = "";

    private static final String DOWNLOAD_PATH = "helloMorning";
    private static final String CALENDAR_FILE_NAME = "calendar.ics";
    //Ici on met pas localhost dans l'URL car le localhost ici référerais au téléphone lui même
    //le 10.0.2.2 nous permet de faire référence au localhost de notre ordinateur
    //private static final String CALENDAR__API_URL = "http://10.0.2.2:3000/dowloadParse";

    private Toolbar toolbar;

    private List<TextView> listeAlarmText;
    private List<CheckBox> listeAlarmCheckBox;

    private static final String SHARED_PREF_NAME = "alarm_conf";

    @Override
    public void onResume(){
        super.onResume();

        Page_option.loadPreferenceTheme(Config3_4.this);

        View config3_4 = findViewById(R.id.config3_4);

        List<Button> btn_list = getAllButtons((ViewGroup) config3_4);
        Log.d("DEBUG",btn_list.size()+ " btn size welcome");

        Page_option.chargementButtons(btn_list);


        toolbar = (Toolbar) findViewById(R.id.toolbar);
        Page_option.changeToolbar(toolbar);

    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.config3_4);


        Page_option.loadPreferenceTheme(Config3_4.this);

        View config3_4 = findViewById(R.id.config3_4);

        List<Button> btn_list = getAllButtons((ViewGroup) config3_4);
        Log.d("DEBUG",btn_list.size()+ " btn size welcome");

        Page_option.chargementButtons(btn_list);


        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        toolbar.setTitle("");
        toolbar.setTitleMargin(210,10,50,10);
        toolbar.setLogo(R.drawable.ic_alarm_black_24dp);


        Objects.requireNonNull(getSupportActionBar()).setDisplayShowTitleEnabled(false);

        setButtonURLListener();
        setAlarmePickListener();

        Button btnSuivant = (Button) findViewById(R.id.btnSuivant);

        btnSuivant.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                //Stocker les variable importante dans les sharedPreference


                SharedPreferences pref = getApplicationContext().getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode
                SharedPreferences.Editor editor = pref.edit();



                //On ne peut stocker que des long ,int et string dans les shared preference

                List<String> joursSemaine = new ArrayList<String>(Arrays.asList("LUNDI","MARDI","MERCREDI","JEUDI","VENDREDI","SAMEDI","DIMANCHE"));

                for(int i = 0 ; i < listeAlarmText.size() ; i++){
                    //On met l'heure et l'état (activé ou désactivé)
                    //Heure à laquelle on commence
                    editor.putString(joursSemaine.get(i) + "_HOUR_START",listeAlarmText.get(i).getText().toString());
                    editor.putBoolean(joursSemaine.get(i) + "_IS_ACTIVATED",listeAlarmCheckBox.get(i).isChecked());
                }

                //On sauvegarde
                editor.commit();

                Intent intent = new Intent(v.getContext(), Config4_4.class);
                startActivity(intent);
            }
        });





    }

    private void setAlarmePickListener() {

        listeAlarmText = new ArrayList<>();
        listeAlarmCheckBox = new ArrayList<>();


        listeAlarmText.add((TextView) findViewById(R.id.alarm1));
        listeAlarmText.add((TextView) findViewById(R.id.alarm2));
        listeAlarmText.add((TextView) findViewById(R.id.alarm3));
        listeAlarmText.add((TextView) findViewById(R.id.alarm4));
        listeAlarmText.add((TextView) findViewById(R.id.alarm5));
        listeAlarmText.add((TextView) findViewById(R.id.alarm6));
        listeAlarmText.add((TextView) findViewById(R.id.alarm7));

        listeAlarmCheckBox.add((CheckBox) findViewById(R.id.check1));
        listeAlarmCheckBox.add((CheckBox) findViewById(R.id.check2));
        listeAlarmCheckBox.add((CheckBox) findViewById(R.id.check3));
        listeAlarmCheckBox.add((CheckBox) findViewById(R.id.check4));
        listeAlarmCheckBox.add((CheckBox) findViewById(R.id.check5));
        listeAlarmCheckBox.add((CheckBox) findViewById(R.id.check6));
        listeAlarmCheckBox.add((CheckBox) findViewById(R.id.check7));



        for(int i = 0 ; i < listeAlarmCheckBox.size() ; i++){

            TextView alarm = listeAlarmText.get(i);
            CheckBox alarmCheck = listeAlarmCheckBox.get(i);

            //On prend pas samedi et dimanche
            if(i <5){
                alarmCheck.setChecked(true);
            }

            alarm.setText("08:00");
            alarm.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    TimePickerFragment timePicker = new TimePickerFragment();

                    int hours = Integer.parseInt(alarm.getText().toString().split(":")[0]);
                    int minute = Integer.parseInt(alarm.getText().toString().split(":")[1]);

                    timePicker.setHours(hours);
                    timePicker.setMinute(minute);

                    timePicker.setOnTimeSetListener(new TimePickerDialog.OnTimeSetListener() {
                        @Override
                        public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                            Log.d("DEBUG",hourOfDay + ":"  + minute);
                            alarm.setText( ( (hourOfDay < 10) ? "0"+hourOfDay : hourOfDay)+ ":"  + ((minute < 10) ? "0"+minute : minute));
                        }
                    });
                    timePicker.show(getSupportFragmentManager(),"Alarme");
                }
            });
        }


    }

    private void setButtonURLListener() {

        Button urlButton = (Button) findViewById(R.id.urlButton);
        urlButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(Config3_4.this);
                alertDialog.setTitle("Url de synchronisation");


                final EditText input = new EditText(Config3_4.this);
                input.setText("http://planning.parisdescartes.fr/jsp/custom/modules/plannings/anonymous_cal.jsp?data=4b257cf1283ff9308ccc52f2198575a0c7f281e4e3ad06b85d3374100ac416a42a2c262ab3ba48506729f6560ae33af6db9fed5e05d0fde49312cebb836cbbbc,1");
                LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.MATCH_PARENT,
                        LinearLayout.LayoutParams.MATCH_PARENT);

                input.setLayoutParams(lp);
                alertDialog.setView(input);

                alertDialog.setPositiveButton("OK",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                String url = input.getText().toString();
                                if (url.equals("")) {
                                    Toast.makeText(Config3_4.this, "Champ vide veuillez saisir une url", Toast.LENGTH_SHORT).show();
                                }
                                file_url = url;

                                ICSCalendar calendar = new ICSCalendar(Config3_4.this,Config3_4.this,file_url);


                                //On récup le layout avec le gif de chargement
                                FrameLayout loadingLayout = (FrameLayout) findViewById(R.id.loadingLayout);
                                loadingLayout.setVisibility(View.VISIBLE);
                                calendar.downloadFile(new ICSCalendarDataReadyListener() {
                                    @Override
                                    public void dataReady() {
                                        List<String> joursSemaine = new ArrayList<String>(Arrays.asList("LUNDI","MARDI","MERCREDI","JEUDI","VENDREDI","SAMEDI","DIMANCHE"));
                                        Log.d("DEBUG","Taille " + joursSemaine.size());
                                        SimpleDateFormat parser = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
                                        parser.setTimeZone(TimeZone.getTimeZone("GMT"));

                                        for(int i = 0 ;  i < joursSemaine.size() ; i++){

                                            String jour = joursSemaine.get(i);

                                            //On recup le label associé au jour en question
                                            TextView alarmLabel = listeAlarmText.get(i);
                                            //On recup la checkbox aussi
                                            CheckBox checkAlarm = listeAlarmCheckBox.get(i);


                                            Cours cours = calendar.getCours(jour);
                                            //ON récupère l'heure a laquelle on commence
                                            if(cours == null){
                                                checkAlarm.setChecked(false);
                                                continue;

                                            }
                                            String start = cours.getStart();
                                            start = start.replace("T"," ");
                                            start = start.replace("Z"," ");
                                            try{
                                                Date date = parser.parse(start);
                                                Log.d("DEBUG",start);

                                                alarmLabel.setText(((date.getHours() < 10) ? "0"+date.getHours() : date.getHours())+ ":"  + ((date.getMinutes() < 10) ? "0"+date.getMinutes() : date.getMinutes()));
                                                checkAlarm.setChecked(true);



                                            }catch (ParseException ex){
                                                ex.printStackTrace();
                                            }

                                        }

                                        loadingLayout.setVisibility(View.INVISIBLE);



                                    }
                                });



                            }
                        });

                alertDialog.setNegativeButton("Annuler",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                dialog.cancel();
                            }
                        });


                alertDialog.show();
            }
        });
    }

    public void Go(android.view.View v){
        Intent intent = new Intent(this, Page_option.class);
        startActivity(intent);
    }

    public List<TextView> getListeAlarmText() {
        return listeAlarmText;
    }


    public List<Button> getAllButtons(ViewGroup layout){
        List<Button> btn = new ArrayList<>();
        Log.d("DEBUG",layout.getChildCount() + "=============");
        for(int i =0; i< layout.getChildCount(); i++){
            View v = layout.getChildAt(i);

            if (v instanceof ViewGroup) {
                btn.addAll(getAllButtons((ViewGroup) v));
            }
            if(v instanceof Button && ! (v instanceof CheckBox)){
                btn.add((Button) v);
            }
        }
        return btn;
    }

}
