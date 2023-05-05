using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite carteAsigned;
    public int SunPrice ;
    public int life;

    void Kill()
    {
        life--;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
