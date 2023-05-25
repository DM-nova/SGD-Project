using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController1 : MonoBehaviour
{
    float speed = 5;
    float rotationSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager1.levelStarted)
            return;
        if (PlayerManager1.gameOver)
            return;
        transform.Translate(0, 0, speed * Time.deltaTime);
        if(Touchscreen.current != null)
        {
            Vector2 delta = Touchscreen.current.primaryTouch.delta.ReadValue();
            transform.Rotate(0, 0, delta.x * rotationSpeed);
        }
      
    }
}
