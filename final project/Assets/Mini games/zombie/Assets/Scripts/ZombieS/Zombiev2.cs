using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombiev2 : MonoBehaviour
{

    public int Life = 10;
    public float speed;
    public LayerMask layerPlant;
    public float cadence = 1f;
    float x = 0;



    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, .5f,layerPlant);
        if (hit.collider != null)
        {
            x += Time.deltaTime;
            if (x > cadence)
            {
                x = 0;
                hit.collider.SendMessage("Kill");
            }
        }
        else
        {
            x = 0;
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Life= Life -2;
            Destroy(col.gameObject);

            if (Life <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (col.CompareTag("House"))
        {
            Destroy(gameObject);
            print("You lost");
        }
    }
    
}
