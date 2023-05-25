using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixer : MonoBehaviour
{
    [SerializeField] Transform follow;
    void Update()
    {
        transform.position = follow.position;
        transform.up = follow.up;
    }
}
