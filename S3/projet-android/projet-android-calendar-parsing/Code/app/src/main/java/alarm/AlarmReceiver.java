package alarm;

import android.app.Notification;
import android.app.NotificationManager;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.media.Ringtone;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build;
import android.os.Vibrator;
import android.util.Log;
import android.widget.Toast;

import androidx.annotation.RequiresApi;

import com.example.pjandroid.R;

public class AlarmReceiver extends BroadcastReceiver {


    private static final int NOTIF_ID = 123;

    //Méthode qui sera appélé quand l'alarm va se déclancher
    @RequiresApi(api = Build.VERSION_CODES.JELLY_BEAN)
    @Override
    public void onReceive(Context context, Intent intent) {
        Toast.makeText(context, "ALARM", Toast.LENGTH_LONG).show();
        Log.d("DEBUG","ALAAARRRRMMM");

        Vibrator vibrator = (Vibrator) context.getSystemService(Context.VIBRATOR_SERVICE);
        long[] pattern = { 0, 100, 500, 100, 500, 100, 500, 100, 500, 100, 500};
        vibrator.vibrate(pattern,0);


        Notification noti = new Notification.Builder(context)
                .setContentTitle("Alarm is On")
                .setContentText("You toto")
                .setSmallIcon(R.mipmap.ic_launcher).build();

        NotificationManager manager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
        noti.flags |= Notification.FLAG_AUTO_CANCEL;

        manager.notify(0,noti);


        try{
            Uri notification = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_RINGTONE);
            Ringtone r = RingtoneManager.getRingtone(context,notification);
            r.play();

        }catch(Exception e){
            Log.d("DEBUG",e.toString());
        }


//        Intent intent_second = new Intent(context, Config4_4.class);
//        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//        context.startActivity(intent_second);





    }
}
