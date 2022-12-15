using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs 
{
    [RequireComponent(typeof(Rigidbody))]

    public class SBShipController : MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private int speed = 2;
        [SerializeField] private Transform Camera;
        private Vector3 distance, movement;
        private Rigidbody playerRigidbody;

    #if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            speed = 2;
        }
#endif

        private void Awake()
        {
            distance = Camera.transform.position - transform.position;
            playerRigidbody = GetComponent<Rigidbody>();            
        }

        void Update()
        {
            Camera.position = transform.position + distance;

            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            movement = new Vector3(-vertical, 0, horizontal);

            MoveHero();
        }

        private void MoveHero()
        {
            playerRigidbody.AddForce(movement * speed * 5);
        }
    }
}
