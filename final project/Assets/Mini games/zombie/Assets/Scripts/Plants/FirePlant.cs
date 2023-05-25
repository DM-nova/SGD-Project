using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlant : MonoBehaviour
{

    public float Cadence = 3;
    public GameObject Bullet;
    public Transform Fire;
    public float speed = 10;
    


    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(Cadence);


            RaycastHit2D hit = Physics2D.Raycast(Fire.position,Vector3.right,12 );
            if (hit.collider != null)
            {
                GameObject go = Instantiate(Bullet, Fire.position, Bullet.transform.rotation) as GameObject;
                go.GetComponent<Rigidbody2D>().velocity = Fire.right * speed;
                Destroy(go, 10);
            }
            
        }
    }
}
