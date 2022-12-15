using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{

    [RequireComponent(typeof(Rigidbody))]

    public class ShipController : MonoBehaviour
    {
        [SerializeField, Range(1, 10)] private int speed = 2;
        [SerializeField] private GameObject Player, target;
        private Rigidbody playerRigidbody;
        private Vector3 moveTowards;


#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues()
        {
            speed = 2;
        }
#endif

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            moveTowards = target.transform.position - playerRigidbody.transform.position;
            
            playerRigidbody.AddForce(moveTowards * vertical * speed, ForceMode.Force);
            Player.transform.Rotate(0, horizontal, 0);
        }
    }
}