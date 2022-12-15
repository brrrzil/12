using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BarScores
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Image BarImg;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private GameObject Light, Ship;
        [SerializeField] private int nextLevel;
        [SerializeField, Range(0, 1)] static public float scores;
        //static public float scores;

        void Start()
        {
            BarImg = GetComponent<Image>();
            scores = 0.5f;
        }

        void Update()
        {
            scores -= 0.0005f;
            BarImg.fillAmount = scores;

            if (scores <= 0) LoseGame();
            if (scores >= 1) WinGame();
        }

        private void WinGame()
        {
            StartCoroutine(WinCoroutine());
            scores = 1f;
        }

        private void LoseGame()
        {
            StartCoroutine(LoseCoroutine());
        }

        private IEnumerator WinCoroutine()
        {
            audioSource.PlayOneShot(audioClip);
            Light.SetActive(true);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(nextLevel);
        }

        private IEnumerator LoseCoroutine()
        {
            yield return new WaitForSeconds(1f);
            audioSource.PlayOneShot(audioClip);
            Light.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            scores = 0.5f;
        }
    }
}