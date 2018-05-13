using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private float fallSpeed = 80f;

    public void SetWord(string word)
    {
        text.text = word;
    }
 
    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.white;
    }

    public void RemoveWord()
    {
        if(gameObject != null)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -fallSpeed * Time.deltaTime, 0);
    }

    public string GetWord()
    {
        return text.text;
    }
}
