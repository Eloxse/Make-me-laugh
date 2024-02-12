using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;

    [Header("Manager")]
    public GameObject randomPerso;
    [SerializeField] private AudioSource ambientSound;
    [SerializeField] private GameObject userInterface, panJoke;

    [Header("Life")]
    public int life = 3;
    [SerializeField] private AudioSource loseLifeSound;

    [Header("Score")]
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private AudioSource scoreSound;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject clockSound;
    [SerializeField] private AudioSource gameOverSound;

    [Header("Win")]
    [SerializeField] private GameObject winUI;
    [SerializeField] private AudioSource winSound;

    [SerializeField] private List<GameObject> perso;
    [SerializeField] private int numberOfPerso;

    private bool _isLosed;
    private int _score;

    private Joke_Manager _jm;
    private UI_Manager _ui;
    #endregion

    #region Builtin Methods
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        PersoSpawner();
    }

    private void Start()
    {
        _ui = UI_Manager.instance;
        _jm = Joke_Manager.instance;

        if (ambientSound)
        {
            ambientSound.Play();
        }
    }

    private void Update()
    {
        NoMoreLife();
    }
    #endregion

    #region Custom Methods
    public void AddScore()
    {
        _score += scoreValue;

        _ui.UpdateScoreText(_score);
        _ui.UpdateEndScoreText(_score);
        scoreSound.Play();  
    }
    //Increment the scoring and call the function to update the text

    public void RemoveLife()
    {
        life -= 1;

        _ui.UpdateLifeImage(life);
        loseLifeSound.Play();
    }
    //Decrement life count

    private void NoMoreLife()
    {
        if(life <= 0 && !_isLosed)
        {
            _isLosed = true;

            GameOver();
        }
    }
    //Active the game over function, when life count equal to 0

    public void GameOver()
    {
        clockSound.SetActive(false);
        userInterface.SetActive(false);
        panJoke.SetActive(false);
        gameOverSound.Play();

        gameOverUI.SetActive(true);
    }
    //Display the game over screen

    public void Win()
    {
        userInterface.SetActive(false);
        panJoke.SetActive(false);
        winSound.Play();

        winUI.SetActive(true);
    }
    //Display win screen

    public void PersoSpawner()
    {
        randomPerso = Instantiate(perso[UnityEngine.Random.Range(0, numberOfPerso)], transform.position, transform.rotation);
    }
    //Spawn the characters

    public void ChangeJoke()
    {
        _jm.GenerateJokes();
        Destroy(randomPerso);

        PersoSpawner();
    }
    //Change the joke and character
    #endregion
}