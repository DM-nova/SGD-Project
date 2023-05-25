using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseHPbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float CurrentHouseHealth;
    public float MaxHouseHealth = 10f;
    Life Life;

    
    private void Start()
    {
        Life = FindObjectOfType<Life>();
    }

    private void Update()
    {
        CurrentHouseHealth = Life.HouseLife;
        slider.value = CurrentHouseHealth / MaxHouseHealth;
    }
}
