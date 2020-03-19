package fragments;

import android.app.Dialog;
import android.app.TimePickerDialog;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.DialogFragment;

public class TimePickerFragment extends DialogFragment {


    private TimePickerDialog.OnTimeSetListener listener = null;
    private int hours;
    private int minute;

    @NonNull
    @Override
    public Dialog onCreateDialog(Bundle savedInstance){

        //Pour le moment on gère juste le format 24h
        return new TimePickerDialog(getActivity() ,listener,hours,minute,true);
    }
    public void setOnTimeSetListener(TimePickerDialog.OnTimeSetListener l ){
        listener = l;
    }

    public void setHours(int hours) {
        this.hours = hours;
    }

    public void setMinute(int minute) {
        this.minute = minute;
    }
}
