using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BruteForcePuzzle : MonoBehaviour
{
    [SerializeField]
    private Image bar;
    [SerializeField]
    private Text msg;
    [SerializeField]
    private int size;

    private int count;

        // Use this for initialization
    void Start()
    {
        msg.text = string.Format("Brute Forcing (0/{0})", size);
        count = 0;
    }

    private void FixedUpdate()
    {
        if (count >= size)
        {
            HackManager.Instance.FinishHacking(true);
            Reset();
        }
        else if (Input.anyKey && !Input.GetMouseButton(0) && !Input.GetMouseButton(0) && !Input.GetKey(KeyCode.Escape) && !Input.GetKey(KeyCode.Space))
        {
            count++;
            msg.text = string.Format("Brute Forcing ({0}/{1})", count, size);
            bar.fillAmount = (float)count / (float)size;
        }
    }

    private void Reset()
    {
        bar.fillAmount = 0;
        count = 0;
        msg.text = string.Format("Brute Forcing (0/{0})", size);
        gameObject.SetActive(false);
    }
}
