using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinYellow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(60 * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoins");
            PlayerManager.numberOfyellowCoins += 1;
            Debug.Log("blue");
            Destroy(gameObject);
        }
    }
}