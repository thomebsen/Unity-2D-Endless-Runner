using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.

public class Score : MonoBehaviour
{
    public TextMeshProUGUI timerCount_Pro;
    public TextMeshProUGUI bestTime_Pro;


    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    private float currentScore = 0;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        //Don't fuck with this.. it works, so lets keep it that way
        secondsCount += Time.deltaTime;
        currentScore += Time.deltaTime;

        timerCount_Pro.text = hourCount + " : " + minuteCount + " : " + (int)secondsCount;
        bestTime_Pro.text = PlayerPrefs.GetString("BestTime");

        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }

        if(currentScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", (int)currentScore);
            PlayerPrefs.SetString("BestTime", hourCount + " : " + minuteCount + " : " + (int)secondsCount); //Save the highScore to make it persist
        }

    }
}
