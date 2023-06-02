using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer1 : MonoBehaviour
{

    public Text text;
    public bool Finish;
    public static float time;
    public MoveController MoveController;
    public SwipeManager1 SwipeManager1;

    void Start()
    {
        SwipeManager1 = FindObjectOfType<SwipeManager1>();
        MoveController = FindObjectOfType<MoveController>();
        time = 60;
        Finish = false;
    }

    void Update()
    {

        if (SwipeManager1.s == true)
        {
            time -= Time.deltaTime;
            text.text = "" + Mathf.Round(time);

            if (time <= 10)
            {
                text.color = Color.red;
            }
            }
            if (time <= 0)
            {

                text.text = "0";
                Finish = true;

            }
        


    }

}
