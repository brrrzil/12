using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private  GameObject Button, Text, Light;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        StartCoroutine(startAppearance());    
    }

    private IEnumerator startAppearance()
    {
        yield return new WaitForSeconds(3);
        Text.SetActive(true);
        yield return new WaitForSeconds(2);
        Button.SetActive(true);
    }

    private IEnumerator ClickStartCoroutine()
    {
        audioSource.PlayOneShot(audioClip);
        Light.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    public void ClickStartButton()
    {
        StartCoroutine(ClickStartCoroutine());
    }
}