using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField] private float timeBeforeLoad = 0.5f;

    [Header("Sounds")]
    [SerializeField] private AudioSource ambientSound;
    [SerializeField] private AudioSource btnSound;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogueUI;

    private Joke_Manager _jm;
    #endregion

    #region Builtin Methods
    private void Start()
    {
        if (ambientSound)
        {
            ambientSound.Play();
        }

        _jm = Joke_Manager.instance;
    }
    #endregion

    #region Custom Methods
    public void LoadMenu()
    {
        StartCoroutine(DelayMenu());
    }

    private IEnumerator DelayMenu()
    {
        btnSound.Play();
        yield return new WaitForSeconds(timeBeforeLoad);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void LoadBestScore()
    {
        StartCoroutine(DelayBestScore());
    }

    private IEnumerator DelayBestScore()
    {
        btnSound.Play();
        yield return new WaitForSeconds(timeBeforeLoad);
        SceneManager.LoadScene("Best_Score", LoadSceneMode.Single);
    }
    //Load the summary of the highest score

    public void Play()
    {
        StartCoroutine(DelayPlay());
    }

    private IEnumerator DelayPlay()
    {
        btnSound.Play();
        yield return new WaitForSeconds(timeBeforeLoad);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    //Start the game

    public void NextButton()
    {
        StartCoroutine(DelayNextButton());
    }

    private IEnumerator DelayNextButton()
    {
        btnSound.Play();
        yield return new WaitForSeconds(timeBeforeLoad);
        dialogueUI.SetActive(false);
        
        _jm.GenerateJokes();
    }
    //Unactive the dialogue at the beginning of the game and start the gameplay

    public void ExitGame()
    {
        StartCoroutine(DelayExitGame());
    }

    private IEnumerator DelayExitGame()
    {
        btnSound.Play();
        yield return new WaitForSeconds(timeBeforeLoad);
        Application.Quit();
    }
    //Exit the game
    #endregion
}