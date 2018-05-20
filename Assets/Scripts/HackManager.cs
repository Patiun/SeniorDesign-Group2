using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackManager : MonoBehaviour
{
    #region Singleton
    private static HackManager _instance;
    //Used only once to ensure when one thread have access to create the instance
    private static readonly object _Lock = new object();

    public static HackManager Instance
    {
        get
        {
            //thread safe!
            lock(_Lock)
            {
                if (_instance != null)
                    return _instance;
                HackManager[] instances = FindObjectsOfType<HackManager>();
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

                GameObject manage = new GameObject("HackManager");
                manage.AddComponent<HackManager>();

                return _instance = manage.GetComponent<HackManager>();
            }
        }
    }
    #endregion

    [SerializeField]
    [Tooltip("Allow the manager to be across all scenes.")]
    private bool _persistent = true;

    private void Awake()
    {
        if (_persistent)
            DontDestroyOnLoad(gameObject);

    }

    [SerializeField]
    private GameObject BruteForce;

    [SerializeField]
    private GameObject TypingSim;

    [SerializeField]
    private GameObject LinePizzle;

    private PuzzleDifficultiesLevel currentLevel;
    private AbstractHackMenu CurrentObjectHack;
    public bool InProgress;

    private void Start()
    {
        InProgress = false;
    }

    /// <summary>
    /// Change the screen of the operaator to start hacking the type of puzzle
    /// </summary>
    /// <param name="icon">The object to be hack</param>
    /// <param name="level">The difficulty of the puzzle</param>
    public void InitializeHacking(AbstractHackMenu icon, PuzzleDifficultiesLevel level)
    {
        CurrentObjectHack = icon;
        currentLevel = level;
        switch (level)
        {
            case PuzzleDifficultiesLevel.Easy:
                BruteForce.SetActive(true);
                CameraManager.Instance.DisableCurrent();
                InProgress = true;
                break;
            case PuzzleDifficultiesLevel.Medium:
                TypingSim.SetActive(true);
                CameraManager.Instance.DisableCurrent();
                InProgress = true;
                break;
            case PuzzleDifficultiesLevel.Hard:
                LinePizzle.SetActive(true);
                CameraManager.Instance.DisableCurrent();
                InProgress = true;
                break;
        }
        
    }

    public void FinishHacking(bool pass)
    {
        if(pass)
        {
            CurrentObjectHack.NotifyHackStatus(pass);
        }

        ResetHack();
    }

    public void ResetHack()
    {
        
        switch (currentLevel)
        {
            case PuzzleDifficultiesLevel.Easy:
                BruteForcePuzzle bfp = BruteForce.GetComponent<BruteForcePuzzle>();
                bfp.Reset();
                CameraManager.Instance.SwitchMainCamera();
                break;
            case PuzzleDifficultiesLevel.Medium:
                WordManager w = TypingSim.GetComponent<WordManager>();
                w.Reset();
                CameraManager.Instance.SwitchMainCamera();
                break;
            case PuzzleDifficultiesLevel.Hard:
                GridLevelManager g = LinePizzle.GetComponent<GridLevelManager>();
                g.Reset();
                CameraManager.Instance.SwitchMainCamera();
                break;
        }
        InProgress = false;
        currentLevel = PuzzleDifficultiesLevel.None;
    }

}
