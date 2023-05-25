using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public float SunsNumber = 3;
    public GameObject Sun;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(SunsNumber);
            GameObject go = Instantiate(Sun,transform.position + Vector3.up * Random.Range(0f,1f) +Vector3.left * Random.Range(-1f,1f),Sun.transform.rotation);
            Destroy(go, 10);
        }
    }


}
