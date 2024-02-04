using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Joke_Manager : MonoBehaviour
{
    #region Variables
    public static Joke_Manager instance;

    [SerializeField] private List<Joke> humours;
    [SerializeField] private List<TextMeshProUGUI> btnText;

    private List<Joke> jokeTemp;
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
    #endregion

    #region Custom Methods
    public void GenerateJokes()
    {
        jokeTemp = new List<Joke>(humours);

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, jokeTemp.Count);

            btnText[i].text = jokeTemp[index].joke[Random.Range(0, jokeTemp[index].joke.Count)];

            btnText[i].gameObject.transform.parent.gameObject.tag = jokeTemp[index].accessCat;

            jokeTemp.RemoveAt(index);
        }
    }
    #endregion
}