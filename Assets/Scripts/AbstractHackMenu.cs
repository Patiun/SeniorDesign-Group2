using UnityEngine;
using System.Collections;

public abstract class AbstractHackMenu : MonoBehaviour
{

    public abstract void NotifyHackStatus(bool status);
    public virtual void Reset() { }
}
