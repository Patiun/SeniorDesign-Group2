using UnityEngine;
using System.Collections;

public class DestroyWord : MonoBehaviour
{
    [SerializeField]
    private WordManager manager;

    private void OnTriggerEnter(Collider other)
    {
        manager.IncrementFailWord(other.gameObject);
        Destroy(other.gameObject);
    }
}
