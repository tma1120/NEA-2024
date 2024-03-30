using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;//the actual timer text
    float timePassed = 0; // holds the time passed
    int minutes = 0; // the number of minutes passed is stored here
    int seconds = 0; // the number of seconds passed is stored here

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime; //timepassed is equal to the total time passed 
        minutes = Mathf.FloorToInt(timePassed/60); //get the minutes passed
        seconds = Mathf.FloorToInt(timePassed % 60); // the seconds passed here, as a remainder of 60 to be shown on the timer

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // formats the timer in the correct way, to show as 00:00. Sets the timerText to this value
}

}