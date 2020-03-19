package com.example.pjandroid;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;


public class WelcomePage extends AppCompatActivity {

    private Toolbar toolbar;


    @Override
    public void onResume(){
        super.onResume();

        Page_option.loadPreferenceTheme(WelcomePage.this);

        View wlcm_page = findViewById(R.id.wlc_page);

        List<Button> btn_list = getAllButtons((ViewGroup) wlcm_page);
        Log.d("DEBUG",btn_list.size()+ " btn size welcome");

        Page_option.chargementButtons(btn_list);

        toolbar = (Toolbar) findViewById(R.id.toolbar);
        Page_option.changeToolbar(toolbar);

    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.welcome_page);

        Page_option.loadPreferenceTheme(WelcomePage.this);

        View wlcm_page = findViewById(R.id.wlc_page);

        List<Button> btn_list = getAllButtons((ViewGroup) wlcm_page);
        Log.d("DEBUG",btn_list.size()+ " btn size welcome");

        Page_option.chargementButtons(btn_list);

        toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        toolbar.setTitle("");
        toolbar.setTitleMargin(210,10,50,10);
        toolbar.setLogo(R.drawable.ic_alarm_black_24dp);


        Objects.requireNonNull(getSupportActionBar()).setDisplayShowTitleEnabled(false);

        Button button = findViewById(R.id.button1);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) { moveToActivity3();
            }
        });

    }

    private void moveToActivity3() {
        //Temporaire
        Intent intent = new Intent(WelcomePage.this, Config1_4.class);
        startActivity(intent);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    //Avec sa on bloquue le fait de retourner sur la page de chargement qu'on lance au lancement
    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        if (keyCode == KeyEvent.KEYCODE_BACK) {
            // your code
            return true;
        }

        return super.onKeyDown(keyCode, event);
    }

    public void Go(android.view.View v){
        Intent intent = new Intent(WelcomePage.this, Page_option.class);
        startActivity(intent);
    }


    public List<Button> getAllButtons(ViewGroup layout){
        List<Button> btn = new ArrayList<>();
        Log.d("DEBUG",layout.getChildCount() + "=============");
        for(int i =0; i< layout.getChildCount(); i++){
            View v = layout.getChildAt(i);

            if (v instanceof ViewGroup) {
                btn.addAll(getAllButtons((ViewGroup) v));
            }
            if(v instanceof Button){
                btn.add((Button) v);
            }
        }
        return btn;
    }



}