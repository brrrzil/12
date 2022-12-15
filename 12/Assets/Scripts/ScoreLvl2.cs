using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BarScores
{
    public class ScoreLvl2 : MonoBehaviour
    {
        [SerializeField] private GameObject Point;
        [SerializeField] private GameObject[] PointPositions;
        private int i = 0;


        void Start()
        {
            foreach (var e in PointPositions) e.SetActive(false);
            PointPositions[0].SetActive(true);

            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Equals("Ship"))
            {
                Bar.scores += 0.2f;

                PointPositions[i].SetActive(false);
                i++;
                if (i == PointPositions.Length - 1) i = 0;
                PointPositions[i].SetActive(true);
            }
        }

        void Update()
        {

        }
    }
}