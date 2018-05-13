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
    [Tooltip("How many needed to type to beat it")]
    private int winCondition;
    [SerializeField]
    float timeDelay;
    private bool hasActiveWord;
    private Word activeWord;
    private float nextWordTime;

    private int count;

    private int fail;
    private void Start()
    {
        fail = 0;
        count = 0;
        nextWordTime = 0;
        words = new List<Word>();
    }

    private void Update()
    {
        if (fail > 1)
            Reset();

        if (Time.time >= nextWordTime)
        {
            AddWord();
            nextWordTime = Time.time + timeDelay;
            timeDelay *= .99f;
        }

        foreach (char letter in Input.inputString)
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
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }

        if(hasActiveWord == activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            count++;

            if(count >= winCondition)
            {
                HackManager.Instance.FinishHacking(true);
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
        CameraManager.Instance.SwitchMainCamera();
        count = 0;
        fail = 0;
        words.RemoveRange(0, words.Count);
        activeWord = null;
        
        gameObject.SetActive(false);
        nextWordTime = 0;
        foreach (Transform child in wordSpawner.transform)
            Destroy(child.gameObject);
    }

    public void IncrementFailWord(GameObject obj)
    {
        if(activeWord.GetWord().Contains(obj.GetComponent<WordDisplay>().GetWord()))
        {
            activeWord = null;
            hasActiveWord = false;
        }
        fail++;
    }
}
