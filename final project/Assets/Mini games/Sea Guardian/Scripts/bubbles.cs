using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles : MonoBehaviour
{
    private void Start()
    {
        bb();
        StartCoroutine(spawnBubbles());
    }
    void bb()
    {
        foreach (Transform item in transform)
        {
            item.GetComponent<ParticleSystem>().Stop();
        }
        ParticleSystem a = transform.GetChild(Random.Range(0, transform.childCount)).GetComponent<ParticleSystem>();
        a.Play();
        a = transform.GetChild(Random.Range(0, transform.childCount)).GetComponent<ParticleSystem>();
        a.Play();
    }
    IEnumerator spawnBubbles()
    {
        yield return new WaitForSeconds(10f);
        bb();
        StartCoroutine(spawnBubbles());
    }
}
