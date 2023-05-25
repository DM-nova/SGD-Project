using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    public static CameraShakeController instance;
    private float shakeTime, shakePower, shakeFadeTime, shakeRotation;
    //public float shakeRotationMultiplayer;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;

            float Xamount = Random.Range(-1, 1) * shakePower;
            float Yamount = Random.Range(-1, 1) * shakePower;

            transform.position += new Vector3(Xamount, Yamount, 0);

            shakePower = Mathf.MoveTowards(shakePower, 0, shakeFadeTime * Time.deltaTime);
            //shakeRotation = Mathf.MoveTowards(shakeRotation, 0, shakeFadeTime * shakeRotationMultiplayer * Time.deltaTime);
        }
        else
        {
            //transform.position = new Vector3(0, 0, -10);
        }
        //transform.rotation = Quaternion.Euler(0, 0, shakeRotation * Random.Range(-1, 1));
    }

    public void StartShake(float lengh, float power)
    {
        shakeTime = lengh;
        shakePower = power;

        shakeFadeTime = power / lengh;
        //shakeRotation = power * shakeRotationMultiplayer;
    }


}
