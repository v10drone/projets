package com.example.pjandroid;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.os.Bundle;
import android.text.InputFilter;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import java.util.ArrayList;
import java.util.List;

import alarm.AlarmConfigurator;
import utility.InputFilterMinMax;

public class Config4_4 extends AppCompatActivity {


    private static final int MIN_ALARM_SUPP = 0;
    private static final int MAX_ALARM_SUPP = 10;


    private static final int MIN_ALARM_INTERVAL = 0;
    private static final int MAX_ALARM_INTERVAL = 59;


    private static final int MIN_AVANCE = 0;
    private static final int MAX_AVANCE = 59;

    private Toolbar toolbar;

    private static final String SHARED_PREF_NAME = "alarm_conf";

    //Savoir si on a besoin de plusieur alarmes
    private static boolean multiple_alarm_needed = false;

    @Override
    public void onResume(){
        super.onResume();

        Page_option.loadPreferenceTheme(Config4_4.this);

        View config4_4 = findViewById(R.id.config4_4);

        List<Button> btn_list = getAllButtons((ViewGroup) config4_4);
        Log.d("DEBUG",btn_list.size()+ " btn size welcome");

        Page_option.chargementButtons(btn_list);

        toolbar = (Toolbar) findViewById(R.id.toolbar);
        Page_option.changeToolbar(toolbar);

    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);




        setContentView(R.layout.config4_4);


        Page_option.loadPreferenceTheme(Config4_4.this);

        View config4_4 = findViewById(R.id.config4_4);

        List<Button> btn_list = getAllButtons((ViewGroup) config4_4);
        Log.d("DEBUG",btn_list.size()+ " btn size welcome");

        Page_option.chargementButtons(btn_list);


        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        toolbar.setTitle("HelloMorning !");
        toolbar.setTitleMargin(210,10,50,10);
        toolbar.setLogo(R.drawable.ic_alarm_black_24dp);

        getSupportActionBar().setDisplayShowTitleEnabled(false);

        Page_option.changeToolbar(toolbar);


        //On va désactiver tout les composant de l'écran
        LinearLayout layout = (LinearLayout) findViewById(R.id.layout_4_4);
        disableEnableControls(false, layout);


        Button btn_multiple_alarm_no = (Button) findViewById(R.id.multiple_alarm_no);
        Button btn_multiple_alarm_yes = (Button) findViewById(R.id.multiple_alarm_yes);

        btn_multiple_alarm_no.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d("DEBUG", "FALSE");
                disableEnableControls(false, layout);
                multiple_alarm_needed = false;
            }
        });

        btn_multiple_alarm_yes.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d("DEBUG", "TRUEEE");
                disableEnableControls(true, layout);
                multiple_alarm_needed = true;

            }
        });


        TextView nbAlarmText = (TextView) findViewById(R.id.nbRep);
        TextView intervalAlarmText = (TextView) findViewById(R.id.intervalAlarm);
        TextView minuteAvanceText = (TextView) findViewById(R.id.minAvance);
        CheckBox checkVibreur = (CheckBox) findViewById(R.id.checkVibreur);
        FrameLayout loadingLayout = (FrameLayout) findViewById(R.id.loadingLayout);


        nbAlarmText.setFilters(new InputFilter[]{new InputFilterMinMax(MIN_ALARM_SUPP, MAX_ALARM_SUPP)});
        intervalAlarmText.setFilters(new InputFilter[]{new InputFilterMinMax(MIN_ALARM_INTERVAL, MAX_ALARM_INTERVAL)});
        minuteAvanceText.setFilters(new InputFilter[]{new InputFilterMinMax(MIN_AVANCE, MAX_AVANCE)});


        Button btnSuivant = (Button) findViewById(R.id.btnSuivant);
        btnSuivant.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.KITKAT)
            @Override
            public void onClick(View v) {

                if (!multiple_alarm_needed) {
                    SharedPreferences pref = getApplicationContext().getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode
                    SharedPreferences.Editor editor = pref.edit();
                    editor.putInt("NB_ALARM", 0);
                    editor.putInt("INTERVAL_ALARM", 0);
                    editor.putInt("MINUTE_AVANCE", 0);
                    editor.putBoolean("VIBREUR", false);
                    editor.commit();
                    AlarmConfigurator configurator = new AlarmConfigurator(Config4_4.this);
                    loadingLayout.setVisibility(View.VISIBLE);
                    configurator.setAlarm();
                    return;
                }


                try {
                    int nbAlarmSupp = Integer.parseInt(nbAlarmText.getText().toString());
                    int intervalAlarm = Integer.parseInt(intervalAlarmText.getText().toString());
                    int minuteAvance = Integer.parseInt(minuteAvanceText.getText().toString());
                    boolean vibreur = checkVibreur.isChecked();

                    SharedPreferences pref = getApplicationContext().getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode
                    SharedPreferences.Editor editor = pref.edit();

                    editor.putInt("NB_ALARM", nbAlarmSupp);
                    editor.putInt("INTERVAL_ALARM", intervalAlarm);
                    editor.putInt("MINUTE_AVANCE", minuteAvance);
                    editor.putBoolean("VIBREUR", vibreur);
                    editor.commit();

                    AlarmConfigurator configurator = new AlarmConfigurator(Config4_4.this);
                    loadingLayout.setVisibility(View.VISIBLE);
                    configurator.setAlarm();
                    loadingLayout.setVisibility(View.INVISIBLE);
                    Log.d("DEBUG", "DONNNNEEEE");
//                  Intent intent  = new Intent(Config4_4.this,LastConfigPage.class);
//                  startActivity(intent);

                } catch (NumberFormatException e) {
                    Toast.makeText(Config4_4.this, "Veuillez remplir tout les champs", Toast.LENGTH_LONG).show();


                }


            }
        });


//        SharedPreferences pref = getApplicationContext().getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode
//
//
//        List<String> joursSemaine = new ArrayList<String>(Arrays.asList("LUNDI","MARDI","MERCREDI","JEUDI","VENDREDI","SAMEDI","DIMANCHE"));
//
//        for(int i = 0 ; i < joursSemaine.size() ; i++){
//            //On met l'heure et l'état (activé ou désactivé)
//           Log.d("DEBUG" ,"For : " +  joursSemaine.get(i) + " , " + pref.getString(joursSemaine.get(i) + "_HOUR","") + pref.getBoolean(joursSemaine.get(i) + "_IS_ACTIVATED",false));
//        }


    }

    public void Go(android.view.View v){
        Intent intent = new Intent(this, Page_option.class);
        startActivity(intent);
    }


    private void disableEnableControls(boolean enable, ViewGroup vg) {
        for (int i = 0; i < vg.getChildCount(); i++) {
            View child = vg.getChildAt(i);
            child.setEnabled(enable);
            if (child instanceof ViewGroup) {
                disableEnableControls(enable, (ViewGroup) child);
            }
        }
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
