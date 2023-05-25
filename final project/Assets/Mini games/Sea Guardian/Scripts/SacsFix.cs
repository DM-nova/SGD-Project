using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacsFix : MonoBehaviour
{
    GameManager manager;
    

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TurtuleCanHit s = collision.GetComponent<TurtuleCanHit>();
        if (s != null)
            s.getDestroyed();

        TurtuleMvt turtule = collision.GetComponent<TurtuleMvt>();
        if (turtule) Destroy(turtule.gameObject);




    }
}
