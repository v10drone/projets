package com.example.pjandroid;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.constraintlayout.widget.ConstraintLayout;

import java.util.ArrayList;
import java.util.List;

import petrov.kristiyan.colorpicker.ColorPicker;

public class Page_option extends AppCompatActivity {

    private Button Bcolor;
    private Button Bplanning;
    private Button Badresse;
    private Button Bsonnerie;
    private Button Bvalidate;
    private Button Bsuivant4;
    private Button Burl;
    private Button Bsuivant;
    private Button button1;

    private LinearLayout layoutMaster;

    private static Toolbar toolbar;

    static int colorpicked = R.color.colorPrimary ;

    private static final String SHARED_PREF_NAME = "alarm_conf";

    public static final String SHARED_PREFS = "sharedPrefs";
    public static final String TEXT = "text";

    public static void loadPreferenceTheme(Context c) {
        SharedPreferences pref = c.getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode
        colorpicked = pref.getInt("THEME", R.color.colorPrimary);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_page_option);


        loadPreferenceTheme(Page_option.this);

        View page_option = findViewById(R.id.base);

        List<Button> btn_list = getAllButtons((ViewGroup) page_option);
        Log.d("DEBUG",btn_list.size()+ " btn size welcome");

        Page_option.chargementButtons(btn_list);



        toolbar = (Toolbar) findViewById(R.id.include);
        setSupportActionBar(toolbar);
        toolbar.setTitle("");
        toolbar.setTitleMargin(210, 10, 50, 10);
        toolbar.setLogo(R.drawable.ic_alarm_black_24dp);




        getSupportActionBar().setDisplayShowTitleEnabled(false);

        changeToolbar(toolbar);

        ConstraintLayout lay = findViewById(R.id.base);


        layoutMaster = findViewById(R.id.layout_option);

        Bcolor = (Button) findViewById(R.id.button_ColorPicker);
        Badresse = (Button) findViewById(R.id.button_setAdresse);
        Bplanning = (Button) findViewById(R.id.button_setPlanning);
        Bsonnerie = (Button) findViewById(R.id.button_setSonnerie);
        Bvalidate = (Button) findViewById(R.id.button_validate);

        Bsuivant4 = (Button) findViewById(R.id.btnSuivant4);
        Burl = (Button) findViewById(R.id.urlButton);
        Bsuivant = (Button) findViewById(R.id.btnSuivant);
        button1 = (Button) findViewById(R.id.button1);

        Bcolor.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                opencolorpicker();
            }
        });

        Bvalidate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                goBack();
            }
        });

        Badresse.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Page_option.this, Config1_4.class);
                startActivity(intent);
            }
        });

        Bplanning.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Page_option.this, Config3_4.class);
                startActivity(intent);
            }
        });

    }

    public void goBack(){
        finish();
    }

    public void opencolorpicker(){
        final ColorPicker colorPicker = new ColorPicker(this);
        ArrayList<String> colors = new ArrayList<>();
        colors.add("#FF914C");
        colors.add("#b8cdf9");
        colors.add("#ffaeb4");
        colors.add("#f3ce00");
        colors.add("#faf3ed");
        colors.add("#6c3e2c");
        colors.add("#ffa0a0");
        colors.add("#e0795d");
        colors.add("#3d1159");
        colors.add("#fedb90");

        colorPicker.setColors(colors).setColumns(5).setRoundColorButton(true)
                .setOnChooseColorListener(new ColorPicker.OnChooseColorListener() {
                        @Override
                        public void onChooseColor(int position,int color) {

                            colorpicked = color;
                            Log.d("DEBUG",color + "=============");
                            chargementButtons(getAllButtons((ViewGroup) layoutMaster ));
                            changeToolbar(toolbar);

                            SharedPreferences pref = getApplicationContext().getSharedPreferences(SHARED_PREF_NAME, 0); // 0 - for private mode
                            SharedPreferences.Editor editor = pref.edit();

                            editor.putInt("THEME",color);

                            editor.commit();
                    }
                    @Override
                    public void onCancel(){
                    }
                }).show();
    }

    @SuppressLint("ResourceAsColor")
    public static void chargementButtons(List<Button> buttons){
        Log.d("DEBUG",buttons.size() + " btn size");
        for (Button btn : buttons) {
            btn.setBackgroundColor(colorpicked);
        }
    }
    @SuppressLint("ResourceAsColor")
    public static void changeToolbar(androidx.appcompat.widget.Toolbar bar){
        bar.setBackgroundColor(colorpicked);
    }


    public void Go(View v) {
       
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
