using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public Text text;
    public bool Finish;
    public static float time;
    public MoveController MoveController;





    void Start()
    {

        MoveController = FindObjectOfType<MoveController>();
        time = 60;
        Finish = false;
    }

    void Update()
    {
        if (MoveController.go == true)
        {
            time -= Time.deltaTime;
            text.text = "" + Mathf.Round(time);

            if (time <= 10)
            {
                text.color = Color.red;
            }

            if (Timer.time <= 0)
            {

                text.text = "0";
                Finish = true;

            }
        }

            
    }

}
