using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimEvents : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject Light;
 
    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    public void PlayCollapse()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void WinEvent()
    {
        StartCoroutine(WinGame());
    }

    private IEnumerator WinGame()
    {
        Light.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}