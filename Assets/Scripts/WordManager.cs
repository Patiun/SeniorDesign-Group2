using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    private string[] wordBank = { "backdoor", "bug", "crypto", "cracking", "brute", "bots", "virus", "fear",
                                    "blackhat", "trojan", "eric", "exploit", "man-in-the-middle", "rootkit",
                                    "salt", "scripts", "attack", "sniffling", "spoofing", "DNS", "VPN", "Worm",
                                    "DDoS", "internet", "offshore", "social-engineering", "error", "channels",
                                    "deathray", "limewire", "priate", "torrent", "spy", "robots", "interference",
                                    "panic", "reverse", "doom", "jail-time", "WINNER", "unethical", "firewall"};

    [SerializeField]
    private List<Word> words;
    [SerializeField]
    public WordSpawner wordSpawner;
    [SerializeField]
    private int maxSize;
    private bool hasActiveWord;
    private Word activeWord;

    private int count;
    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        foreach(char letter in Input.inputString)
        {
            TypeLetter(letter);
        }
    }

    public void AddWord()
    {
        Word word = new Word(GenerateRandomWord(), wordSpawner.Spawn());

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if(hasActiveWord)
        {
            if(activeWord.GetNextLetter().Equals(letter))
            {
                activeWord.TypeLetter();
            }
        }

        if(hasActiveWord == activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            count++;

            if(count >= maxSize)
            {
                Reset();
            }
        }
    }

    public string GenerateRandomWord()
    {
        int random = Random.Range(0, wordBank.Length);
        return wordBank[random];
    }

    public void Reset()
    {
        count = 0;

        gameObject.SetActive(false);
    }
}
