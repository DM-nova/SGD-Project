using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHPbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float CurrentHealth;
    public float MaxHealth = 10f;
    Zombie Zombie;

    // Update is called once per frame
    private void Start()
    {
        //HealthBar=GetComponent<Image> ();
        Zombie = FindObjectOfType<Zombie>();
    }

    private void Update()
    {
        CurrentHealth = Zombie.Life;
        slider.value=CurrentHealth /MaxHealth;
    }
}
