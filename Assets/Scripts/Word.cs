using UnityEngine;
using System.Collections;

public class Word
{
    [SerializeField]
    private string word;

    private int typeIndex;

    WordDisplay display;

    public Word(string word, WordDisplay display)
    {
        word = this.word;
        typeIndex = 0;

        display = this.display;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped()
    {
        if (typeIndex >= word.Length)
        {
            display.RemoveWord();
            return true;
        }
        else
            return false;

    }
}
