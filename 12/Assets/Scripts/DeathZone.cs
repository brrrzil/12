using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Hero"))
        {
            audioSource.PlayOneShot(clip);
            StartCoroutine(deathCourutine());
        }
    }

    private IEnumerator deathCourutine()
    {
        Light.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}