using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessories : MonoBehaviour
{
    #region Variables
    public Transform[] perso;

    [SerializeField] private List<Joke> tagUn;

    private GameObject _name;
    #endregion

    #region Builtin Methods
    void Start()
    {
        SpawnAccessories();
    }
    #endregion

    #region Custom Methods
    void SpawnAccessories()
    {
        Instantiate(_name, transform.position, Quaternion.identity);
    }
    #endregion
}
