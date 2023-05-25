using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHPbarv2 : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float CurrentHealth;
    public float MaxHealth = 10f;
    Zombiev2 Zombiev2;


    private void Start()
    {
        Zombiev2 = FindObjectOfType<Zombiev2>();
    }

    private void Update()
    {
        CurrentHealth = Zombiev2.Life;
        slider.value = CurrentHealth / MaxHealth;
    }
}
