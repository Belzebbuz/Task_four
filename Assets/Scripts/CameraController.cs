using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float smoothing = 5f;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;


    void Update()
    {
        if (Player.Instance != null)
        {
            Vector3 pos = new Vector3(Player.Instance.transform.position.x, offsetY, Player.Instance.transform.position.z + offsetZ);
            transform.position = Vector3.Lerp(transform.position, pos, smoothing * Time.deltaTime);
        }
    }
}
