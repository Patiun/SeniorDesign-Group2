using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMenu : AbstractHackMenu
{
    
    public GameObject _cameraObject;
    [SerializeField]
    private float _distruptTimer = 5;
    [SerializeField]
    private PuzzleDifficultiesLevel level;

    private bool _enable;


    private void Start()
    {
        _enable = false;

        if (_cameraObject == null)
            Debug.LogWarningFormat("The icon '%s' do not have a camera object attached to it.", gameObject.name);
    }


    /// <summary>
    /// View only what the camera see. This is without any controls or interactions.
    /// </summary>
    public void View()
    {
        GameObject cameraFace = _cameraObject.transform.Find("CameraFace").gameObject;

        if (cameraFace == null)
            Debug.LogErrorFormat("Cannot find camera face game object from '%s'", _cameraObject.name);
        else
        {
            Debug.Log(cameraFace.name);
            GameObject cameraObj = cameraFace.transform.Find("Camera").gameObject;
            if (cameraObj == null)
                Debug.LogErrorFormat("Cannot find Camera game object from '%s'", _cameraObject.name);
            else
            {
                CameraManager.Instance.SwitchCamera(cameraObj);
            }
        }

    }

    public void TakeControl()
    {
        _cameraObject.GetComponent<LookAtPlayer>().enabled = false;
        _cameraObject.GetComponent<CameraControl>().enabled = true;
        View();
    }

    public void DisableFunctionality()
    {
        _cameraObject.GetComponent<LookAtPlayer>().enabled = false;
        _cameraObject.transform.Find("CameraFace").Find("Spotlight").gameObject.SetActive(false);
    }

    public void EnableFunctionality()
    {
        _cameraObject.GetComponent<LookAtPlayer>().enabled = true;
        _cameraObject.transform.Find("CameraFace").Find("Spotlight").gameObject.SetActive(true);
    }

    public void TemporaryDisrupt()
    {
        DisableFunctionality();
        Invoke("EnableFunctionality", _distruptTimer);

    }

    public void Hack()
    {
        HackManager.Instance.InitializeHacking(this, level);
    }

#region Enable or Disable Methods
    /// <summary>
    /// Switch out the menu listing based on the enable or disable.
    /// Disable will only show the button itself as everything is locked down
    /// </summary>
    public void ToggleEnable()
    {
        if(_enable)
        {
            ActivateFullMenu();
            EnableFunctionality();
        }
        else
        {
            DeactivateFullMenu();
            DisableFunctionality();
        }
    }

    private void DeactivateFullMenu()
    {
        GameObject view = transform.Find("ViewButton").gameObject;
        GameObject enableDisable = transform.Find("EnableDisableButton").gameObject;
        GameObject takeControl = transform.Find("TakeControlButton").gameObject;
        GameObject distrupt = transform.Find("DistruptButton").gameObject;

        if (view != null)
            view.SetActive(false);

        if (enableDisable != null)
        {
            Text enable = enableDisable.transform.Find("Text").GetComponent<Text>();
            enable.text = "Enable";
            _enable = true;
        }

        if (takeControl != null)
            takeControl.SetActive(false);

        if (distrupt != null)
            distrupt.SetActive(false);
    }

    /// <summary>
    /// After it is hack, display these menu options
    /// </summary>
    private void ActivateFullMenu()
    {
        GameObject view = transform.Find("ViewButton").gameObject;
        GameObject enableDisable = transform.Find("EnableDisableButton").gameObject;
        GameObject takeControl = transform.Find("TakeControlButton").gameObject;
        GameObject distrupt = transform.Find("DistruptButton").gameObject;

        if (view != null)
            view.SetActive(true);

        if (enableDisable != null)
        {
            enableDisable.SetActive(true);

            Text enable = enableDisable.transform.Find("Text").GetComponent<Text>();
            enable.text = "Disable";
            _enable = false;

        }
        if (takeControl != null)
            takeControl.SetActive(true);

        if (distrupt != null)
            distrupt.SetActive(true);

    }
    #endregion

    /// <summary>
    /// to be called only once after successful hack. To be called from the puzzle function
    /// </summary>
    public void DisplayFullWtihoutHackMenu()
    {
        GameObject hack = transform.Find("HackButton").gameObject;

        if (hack != null)
            hack.SetActive(false);

        ActivateFullMenu();
        GameObject parent = transform.parent.gameObject;
        parent.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public override void NotifyHackStatus(bool status)
    {
        if(status)
        {
            DisplayFullWtihoutHackMenu();
        }
    }
}
