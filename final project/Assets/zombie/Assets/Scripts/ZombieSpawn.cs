using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{

    public int[] time;

    public float ZombiesNumber = 10;
    public GameObject Zombie;

    void Start()
    {
        for (int i = 0;i<time.Length;i++)
        {
            Invoke("ZombiesSpawn", time[i]);
        }
    }

    void ZombiesSpawn()
    {
        Instantiate(Zombie, transform.position, Zombie.transform.rotation);
    }

}
