﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeHackyManager : MonoBehaviour {

    public Text[] row;

    private List<Text> texts;
    private bool isInital;

    private int currentPosition;
    private bool startNewLine;

    private ContainerToType codeWords;

	void Start () {
        isInital = true;
        currentPosition = 0;
        texts = new List<Text>();
        codeWords = new ContainerToType();
        startNewLine = false;

        foreach(Text r in row)
        {
            texts.Add(r);
        }

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            if(isInital)
            {
                foreach(Text t in row)
                {
                    t.text = "";
                }
                isInital = false;
            }
            else
            {
                Text t;
                if (currentPosition == texts.Count - 1)
                    t = ShiftFirstLineToLast();
                else
                    t = NextLine();

                SetTextLetters(t);
            }
        }
	}


    private Text ShiftFirstLineToLast()
    {
        if(startNewLine)
        {
            Text t = texts[0];
            t.transform.SetAsLastSibling();
            t.text = "";
            texts.RemoveAt(0);
            texts.Add(t);
            startNewLine = false;
            return t;
        }
        else
        {
            Text t = texts[texts.Count - 1];
            return t;
        }


    }

    private Text NextLine()
    {
        if (startNewLine)
        {
            startNewLine = false;
            return texts[++currentPosition];
            
        }
        return texts[currentPosition];
    }

    //return bool true if it should go to next row
    private bool SetTextLetters(Text t)
    {
        StringData data = codeWords.GetNSizeLetters();

        if(data.finish)
        {
            finishGame();
            return false;
        }

        t.text += data.NLetters;

        if (data.endOfLine)
            startNewLine = true;
        else
            startNewLine = false;

        

        return false;
    }

    private void finishGame()
    {
        Debug.Log("You have completed hacking");
    }
}