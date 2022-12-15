using UnityEngine;

public class BirdRadius : MonoBehaviour
{
    [SerializeField, Range(0, 40)] private int radius;

    void Start()
    {
        transform.position = new Vector3(transform.position.x + radius, transform.position.y, transform.position.z);
    }
}