using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class CameraRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(-4f * Time.deltaTime, 0, 0);
    }
}
