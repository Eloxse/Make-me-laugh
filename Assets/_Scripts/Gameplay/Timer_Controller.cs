using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer_Controller : MonoBehaviour
{
    #region Variables
    [Header("Manager")]
    [SerializeField] private GameManager manager;
    [SerializeField] private AudioSource clockSound;

    [Header("Timer")]
    [SerializeField] private float timeValue = 60;
    [SerializeField] private TextMeshProUGUI txtTimer;

    private bool _timerIsRed = true;
    #endregion

    #region Builtin Methods
    private void Update()
    {
        TimeSetUp();
    }
    #endregion

    #region Custom Methods
    private void TimeSetUp()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        //If use delta time to scale it correctly

        DisplayTime(timeValue);

        if(timeValue <= 0)
        {
            manager.Win();
            clockSound.Stop();
        }
        //When the countdowhit 0, it's the end of the game
    }
    private void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float secondes = Mathf.FloorToInt(timeToDisplay % 60);

        txtTimer.text = string.Format("{0:00}:{1:00}", minutes, secondes);
        //Countdown + Format 

        if(timeValue < 11 && _timerIsRed)
        {
            _timerIsRed = false;
            txtTimer.color = Color.red;

            clockSound.Play();
        }
        //Change the text color when it's 10sec left
    }
    #endregion
}