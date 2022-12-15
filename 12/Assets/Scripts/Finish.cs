using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour    
{
    [SerializeField] private GameObject Light;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int nextLevel;

    private void OnTriggerEnter(Collider other)        
    {
        if (other.CompareTag("Ship"))
        {
            StartCoroutine(FinishCoroutine());
        }
    }
    
    private IEnumerator FinishCoroutine()
    {
        audioSource.PlayOneShot(audioClip);
        Light.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextLevel);
    }
}