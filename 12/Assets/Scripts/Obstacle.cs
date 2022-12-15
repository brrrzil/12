using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    IEnumerator finish()
    {
        yield return new WaitForSeconds(2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Ship"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(FinishCoroutine());
        }        
    }

    public IEnumerator FinishCoroutine()
    {
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(audioClip);
        Light.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}