using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{

    [SerializeField] Transform bg1,bg2;
    Vector2 initialBg1, initialBg2;

    void Start()
    {
        initialBg1 = bg1.position;
        initialBg2 = bg2.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "idk")
            collision.transform.position = initialBg1;
        else if(collision.tag == "idk1")
            collision.transform.position = initialBg2;

    }
    
}
