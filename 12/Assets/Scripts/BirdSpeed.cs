using UnityEngine;

public class BirdSpeed : MonoBehaviour
{
    [SerializeField, Range(1, 3)] private float speed;

    void Update()
    {
        transform.Rotate(0, -speed/3, 0);
    }
}