using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Life : MonoBehaviour
{
    public int HouseLife = 10;
    public GameObject Panel,Panel1;
    public Timer Timer;
    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D housecol)
    {
        if ((HouseLife > 0) && (Timer.time > 0))
        {
            if (housecol.CompareTag("Zombie"))
            {
                HouseLife = HouseLife - 1;

            }
            if (housecol.CompareTag("Zombiev2"))
            {
                HouseLife = HouseLife - 2;
                print("You will die");
            }
        }
    }

    void Update()
    {
       if ((HouseLife == 0) && (Timer.Finish == false))
        {
            HouseLife = 0;
            Panel.SetActive(true);
        }
        else if ((HouseLife > 0) && (Timer.Finish == true))
        {
            Panel1.SetActive(true);
            //Timer.Finsih = false;
        }
      
        /*if (Timer.time > 0f)
        {
            if (HouseLife == 0)
                Debug.Log("you lose");

        }
        else if (Timer.time == 0f) 
        {
            if (HouseLife > 0)
                Panel1.SetActive(true);
                //print("You Win");
        }*/

    }
   
}
