using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private float _rotSpeed = 5f;


    private void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 rotation = new Vector3(-yMov, xMov, 0f) * _rotSpeed;

        transform.rotation = (transform.rotation * Quaternion.Euler(rotation));
    }
}
