using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/JokeCategories", order = 1)]

public class Joke : ScriptableObject
{
    #region Variables
    public string accessCat;

    public List<string> joke;
    public typeJoke type;
    #endregion
}

public enum typeJoke 
{
    beaufHumor, blackHumor, carambarHumor
}