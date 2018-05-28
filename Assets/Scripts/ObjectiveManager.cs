using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextInfo
{
    public GameObject TextObj;
    public int Id;

    public TextInfo(int id, GameObject text)
    {
        Id = id;
        TextObj = text;
    }
}

public class ObjectiveManager : MonoBehaviour
{

    #region Singleton
    private static ObjectiveManager _instance;
    //Used only once to ensure when one thread have access to create the instance
    private static readonly object _Lock = new object();

    public static ObjectiveManager Instance
    {
        get
        {
            //thread safe!
            lock (_Lock)
            {
                if (_instance != null)
                    return _instance;
                ObjectiveManager[] instances = FindObjectsOfType<ObjectiveManager>();
                //see if there are any already more instance of this
                if (instances.Length > 0)
                {
                    //yay only 1 instance so give it back
                    if (instances.Length == 1)
                        return _instance = instances[0];

                    //remove all other instance of it other than the 1st one
                    for (int i = 1; i < instances.Length; i++)
                        Destroy(instances[i]);
                    return _instance = instances[0];
                }

                GameObject manage = new GameObject("ObjectiveManager");
                manage.AddComponent<ObjectiveManager>();

                return _instance = manage.GetComponent<ObjectiveManager>();
            }
        }
    }
    #endregion

    [SerializeField]
    private GameObject parentHolder;

    [SerializeField]
    private GameObject textBox;

    private List<TextInfo> inactive;

    [SerializeField]
    private string[] objectives;

    private List<TextInfo> messages;

    private void Awake()
    {
        messages = new List<TextInfo>();
        inactive = new List<TextInfo>();
    }
    private void Start()
    {
        foreach(string objective in objectives)
        {
            AddObjective(objective);
        }
    }

    public int AddObjective(string msg)
    {
        GameObject t = Instantiate(textBox);
        Text text = t.transform.Find("txtObjectiveDetail").GetComponent<Text>();
        text.text = msg;

        t.transform.SetParent(parentHolder.transform);
        t.transform.localScale = Vector3.one;

        int id;

        if(inactive.Count == 0)
        {
            id = messages.Count + inactive.Count;
            TextInfo info = new TextInfo(id, t);
            messages.Add(info);
            ChangeObjectiveWord(id, msg);
        }
        else
        {
            TextInfo info = inactive[0];
            id = info.Id;
            ChangeObjectiveWord(id, msg);
            
        }
        return id;
    }

    public void RemoveObjective(int id)
    {
        if(id <= messages.Count)
        {
            messages[id].TextObj.SetActive(false);
            inactive.Add(messages[id]);
            //DestroyImmediate(messages[id]);
        }
        
    }

    public void ChangeObjectiveWord(int id, string msg)
    {
        if(id <= messages.Count)
        {
            Text text = messages[id].TextObj.transform.Find("txtObjectiveDetail").GetComponent<Text>();
            text.text = msg;
        }
    }
}
