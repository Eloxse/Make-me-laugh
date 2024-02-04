using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UI_Manager : MonoBehaviour
{
    #region Variables
    public static UI_Manager instance;

    [SerializeField] private List<GameObject> _btn;

    [Header("Score")]
    [SerializeField] private TMP_Text txtScore;
    [SerializeField] private TMP_Text txtEndScoreW;
    [SerializeField] private TMP_Text txtEndScoreGO;

    [Header("Life")]
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Transform heartParent;

    private string _chara;

    private GameObject[] _hearts;
    private GameManager _gm;
    #endregion

    #region Builtin Methods
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    private void Start()
    {
        CreateHeart();

        _gm = GameManager.instance; 
    }
    #endregion

    #region Custom Methods
    private void CreateHeart()
    {
        _hearts = new GameObject[GameManager.instance.life];

        for (int i = 0; i < GameManager.instance.life; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartParent);
            _hearts[i] = heart;
        }
    }
    //Generate hearts from the heart prefab

    public void UpdateScoreText(int nbScore)
    {
        txtScore.text = nbScore.ToString();
    }
    //Update the text for the scoring

    public void UpdateEndScoreText(int nbEndScore)
    {
        txtEndScoreW.text = nbEndScore.ToString();
        txtEndScoreGO.text = nbEndScore.ToString();
    }
    //Update the text for the scoring at the end of the game

    public void UpdateLifeImage(int nbLife)
    {
        _hearts[nbLife].SetActive(false);
    }
    //Update life number left

    public void AnswerVerification()
    {
        _chara = _gm.randomPerso.tag;

        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.CompareTag(_chara))
        {
            _gm.AddScore();
        }
        else
        {
            _gm.RemoveLife();
        }

        _gm.ChangeJoke();
    }
    //Compare the tag of accessories and the joke category to verify if it's the right answer, if it's right, score increment
    #endregion
}