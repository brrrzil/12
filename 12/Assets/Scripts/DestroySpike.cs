using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DestroySpike : MonoBehaviour
{
    [SerializeField] private GameObject PressEPanel, Light;
    [SerializeField] private TMP_Text SpikesLeftText;
    [SerializeField] Animation AnimCollapse;

    static public int spikesLeft = 4;
    private bool canDestroy = false;
    private GameObject SpikeToDestroy;
    private Animation AnimToDestroy;
    private int IntToDestroy;

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.E) && canDestroy) DestroyThisSpike();
        SpikesLeftText.text = $@"Destroy {spikesLeft} magic spikes";
    }

    private void OnTriggerEnter(Collider other)
    {
        PressEPanel.SetActive(true);
        canDestroy = true;
        SpikeToDestroy = transform.parent.gameObject;
        AnimToDestroy = transform.parent.GetComponent<Animation>();
        IntToDestroy = System.Int32.Parse(transform.parent.name);
    }

    private void OnTriggerExit(Collider other)
    {
        PressEPanel.SetActive(false);
        canDestroy = false;
    }

    private void DestroyThisSpike()
    {
        spikesLeft--;

        if (spikesLeft == 0)
        {
            SpikesLeftText.gameObject.SetActive(false);
            AnimCollapse.Play();
        }

        canDestroy = false;
        //AnimToDestroy.Play($@"DestroySpike{IntToDestroy}");
        Destroy(transform.parent.gameObject);
        PressEPanel.SetActive(false);
        canDestroy = false;
    }
}