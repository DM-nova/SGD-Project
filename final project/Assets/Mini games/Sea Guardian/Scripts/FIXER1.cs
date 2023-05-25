using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIXER1 : MonoBehaviour
{
    TurtuleMvt t;
     AudioSource eating;
    
    private void Awake()
    {
        t = transform.parent.GetComponent<TurtuleMvt>();
        eating = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision) // when the tutrte hit somthing 
    {
        TurtuleCanHit hitable = collision.transform.GetComponent<TurtuleCanHit>();
        if (hitable != null)
        {
            eating.Play();
            if (hitable is Sac)
            {
                t.BOOM.Play();
                
            }
                
            hitable.hit(t);

        }

    }
    
}
