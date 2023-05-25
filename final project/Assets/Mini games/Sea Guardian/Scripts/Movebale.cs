using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movebale : MonoBehaviour
{
    [SerializeField] float maxUp, minUp,rightSpeed,upSpeed;
    float initialMax, initialMin;

    public void setMaxs()
    {
        initialMax = maxUp;
        initialMin = minUp;
    }
    int a = 1;
    public int b=1;
    public virtual void Move()
    {
        if (transform.position.y > maxUp)
            a = -1;
        else if (transform.position.y < minUp)
            a = 1;
        
        transform.Translate((Vector2.right*b * upSpeed + a * Vector2.up * rightSpeed) * Time.deltaTime);
    }
    public virtual IEnumerator changeM()
    {
        yield return new WaitForSeconds(2.5f);
        maxUp = initialMax + Random.Range(-1f, 1f);
        minUp = initialMin + Random.Range(-1f, 1f);
        StartCoroutine(changeM());
    }
}
