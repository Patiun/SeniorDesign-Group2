using UnityEngine;
using System.Collections;

public class Word
{
    
    private string word;

    private int typeIndex;

    WordDisplay display;

    public Word(string word, WordDisplay display)
    {
        this.word = word;
        typeIndex = 0;

        this.display = display;
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

    public string GetWord()
    {
        return word;
    }
}
