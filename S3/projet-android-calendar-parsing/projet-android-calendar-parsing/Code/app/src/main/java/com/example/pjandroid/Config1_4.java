package com.example.pjandroid;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

import adresse.AdresseAPI;

public class Config1_4 extends AppCompatActivity {

    private Toolbar toolbar;

    @Override
    public void onResume() {
        super.onResume();

        Page_option.loadPreferenceTheme(Config1_4.this);

        View config1_4 = findViewById(R.id.config1_4);

        List<Button> btn_list = getAllButtons((ViewGroup) config1_4);
        Log.d("DEBUG", btn_list.size() + " btn size welcome");

        Page_option.chargementButtons(btn_list);

        toolbar = (Toolbar) findViewById(R.id.include2);
        Page_option.changeToolbar(toolbar);

    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.config1_4);

        AdresseAPI.setActivity(Config1_4.this);
        Page_option.loadPreferenceTheme(Config1_4.this);

        View config1_4 = findViewById(R.id.config1_4);

        List<Button> btn_list = getAllButtons((ViewGroup) config1_4);
        Log.d("DEBUG", btn_list.size() + " btn size welcome");

        Page_option.chargementButtons(btn_list);


        setContentView(R.layout.config1_4);
//
        toolbar = (Toolbar) findViewById(R.id.include2);

        setSupportActionBar(toolbar);
        toolbar.setTitle("HelloMorning !");
        toolbar.setTitleMargin(210, 10, 50, 10);
        toolbar.setLogo(R.drawable.ic_alarm_black_24dp);


        Objects.requireNonNull(getSupportActionBar()).setDisplayShowTitleEnabled(false);


        final AutoCompleteTextView adresseD = (AutoCompleteTextView) findViewById(R.id.adresseDomicile);
        final EditText villeD = (EditText) findViewById(R.id.villeDomicile);
        final EditText adresseT = (EditText) findViewById(R.id.adresseTravail);
        final EditText villeT = (EditText) findViewById(R.id.villeTravail);
        EditText pseudo = (EditText) findViewById(R.id.pseudo);


        Button btnSuivant = (Button) findViewById(R.id.btnSuivant4);
        btnSuivant.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final EditText adresseD = (EditText) findViewById(R.id.adresseDomicile);
                final EditText villeD = (EditText) findViewById(R.id.villeDomicile);
                final EditText adresseT = (EditText) findViewById(R.id.adresseTravail);
                final EditText villeT = (EditText) findViewById(R.id.villeTravail);
                EditText pseudo = (EditText) findViewById(R.id.pseudo);
                SharedPreferences pref = getApplicationContext().getSharedPreferences("alarm_conf", 0); // 0 - for private mode
                SharedPreferences.Editor editor = pref.edit();
                new AdresseAPI(adresseD, villeD, adresseT, villeT).execute();
            }
        });
    }

    public void Go(View v) {
        Intent intent = new Intent(this, Page_option.class);
        startActivity(intent);
    }

    public List<Button> getAllButtons(ViewGroup layout) {
        List<Button> btn = new ArrayList<>();
        Log.d("DEBUG", layout.getChildCount() + "=============");
        for (int i = 0; i < layout.getChildCount(); i++) {
            View v = layout.getChildAt(i);

            if (v instanceof ViewGroup) {
                btn.addAll(getAllButtons((ViewGroup) v));
            }
            if (v instanceof Button) {
                btn.add((Button) v);
            }
        }
        return btn;
    }
}
