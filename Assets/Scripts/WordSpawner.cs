using UnityEngine;
using System.Collections;

public class WordSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject wordPrefab;
    [SerializeField]
    private Transform wordCanvas;

    [SerializeField]
    private float min;
    [SerializeField]
    private float max;

    public WordDisplay Spawn()
    {
        Vector3 rand = new Vector3(Random.Range(min, max), 0);

        GameObject word = Instantiate(wordPrefab, rand, Quaternion.identity, gameObject.transform);
        word.transform.localPosition = rand;
        WordDisplay wordDisplay = word.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
