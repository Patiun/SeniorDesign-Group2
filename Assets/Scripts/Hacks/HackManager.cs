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

    //contained the list of objects that has already been hack
    //potentially to be removed? 
    private List<GameObject> _camera;
    private List<GameObject> _door;
    private List<GameObject> _turret;

    private void Awake()
    {
        if (_persistent)
            DontDestroyOnLoad(gameObject);

        _camera = new List<GameObject>();
        _door = new List<GameObject>();
        _turret = new List<GameObject>();        
    }

    /// <summary>
    /// Send a notifcation to the operator that there is an object ready to be hack.
    /// </summary>
    /// <param name="obj">The owner of the object requesting to be hack.</param>
    /// <param name="level">The level of difficult to generate the puzzle.</param>
    public void RequestHack(GameObject obj, PuzzleDifficultiesLevel level)
    {

    }

    /// <summary>
    /// Change the screen of the operaator to start hacking the type of puzzle
    /// </summary>
    /// <param name="obj">The object to be hack</param>
    /// <param name="level">The difficulty of the puzzle</param>
    public void InitializeHacking(GameObject obj, PuzzleDifficultiesLevel level)
    {

    }


}
