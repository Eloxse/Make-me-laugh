using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_Scroll : MonoBehaviour
{
    #region Variables
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private float timeStartTextDialogue = 0.5f;

    [SerializeField] TextMeshProUGUI textComponent;

    private int _index;
    #endregion
	
	#region Builtin Methods
    private void Start()
    {
        textComponent.text = string.Empty;
        StartCoroutine(StartTextDialogue());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[_index])
            {
                NextLine();
            }
        }
    }
    #endregion

    #region Custom Methods
    public void StartDialogue()
    {
        StartCoroutine(TypeLine());
        _index = 0;
    }

    private IEnumerator TypeLine()
    {
        foreach(char c in lines[_index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    //Displaying letter by letter with delay

    private void NextLine()
    {
        if(_index < lines.Length - 1)
        {
            _index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator StartTextDialogue()
    {
        yield return new WaitForSeconds(timeStartTextDialogue);
        StartDialogue();
    }
    #endregion
}
