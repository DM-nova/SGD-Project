using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{

    public int[] time;

    public float ZombiesNumber = 10;
    public GameObject Zombie;
    Life Life;
    Timer Timer;
    MoveController MoveController;

    void Start()
    {
        Life = FindObjectOfType<Life>();
        MoveController = FindObjectOfType<MoveController>();
        for (int i = 0;i<time.Length;i++)
        {
            Invoke("ZombiesSpawn", time[i]);
        }
    }

    void ZombiesSpawn()
    {
        
            if ((Life.HouseLife > 0)&&(Timer.time > 0)&&(MoveController.go==true))
            {
                Instantiate(Zombie, transform.position, Zombie.transform.rotation);
            }

    }

}
