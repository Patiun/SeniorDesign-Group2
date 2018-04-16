using UnityEngine;

public class Hackage : MonoBehaviour {

    [SerializeField]
    [Tooltip("Decide how difficulty level of the puzzles in order to fully control the object")]
    private PuzzleDifficultiesLevel _difficultyLevel = PuzzleDifficultiesLevel.None;

    [SerializeField]
    private GameObject icon;

    private void Start()
    {
        //In order for the rest of the script to work, it must have the associating object type tag so it can be used to execute it's functionality
        if (tag.Equals("Untagged"))
            Debug.LogErrorFormat("Missing tag for %s", gameObject.name);
    }


    /// <summary>
    /// Send notification there is a object to be hack.
    /// <remark> 
    /// Will be put into notification system.
    /// This is to be called when another object such as the mainframe or such that the agent is interacting request the operator to hack it
    /// </remark>
    /// </summary>
    public void RequestHack()
    {
        NotificationManager.Instance.HackNotify(gameObject, _difficultyLevel);
    }

    /// <summary>
    /// Start the hacking process in the Hack Manager
    /// <remark>
    /// When the operator clicks another object via camera to hack on clicking event.
    /// </remark>
    /// </summary>
    public void OnMouseDown()
    {
        StartHack();
    }

    /// <summary>
    /// Start the hacking process in the Hack Manager
    /// </summary>
    public void StartHack()
    {
        HackManager.Instance.InitializeHacking(gameObject, icon, _difficultyLevel);
    }

}
