using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fml : MonoBehaviour
{
    [SerializeField] float speed;
    private void FixedUpdate()
    {
        foreach (Transform item in transform)
        {
            item.Translate(Vector2.right * -speed * Time.deltaTime);
        }
    }
}
