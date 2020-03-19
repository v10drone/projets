package com.example.pjandroid;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ImageView;

import androidx.appcompat.app.AppCompatActivity;

//import java.util.TimerTask;

public class LandingPage extends AppCompatActivity {

    ImageView image;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.landing_page);
        image =  findViewById(R.id.imageView); //(ImageView)

        Thread thread = new Thread(){
            @Override
            public void run(){
                try{
                    sleep(2*1000);
                    Intent i = new Intent(getApplicationContext(), WelcomePage.class);
                    startActivity(i);

                }catch(Exception e){

                }
            }
        };
        thread.start();
    }

}
