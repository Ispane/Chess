using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealthBar : MonoBehaviour
{
    public UnitBase unit;
    public Slider slider;
    public Text unitName;
    public Text unitHealth;

    private double fill;

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;

        fill = Convert.ToDouble(unit.Health) / Convert.ToDouble(unit.MaxHealth);
        slider.value = (float)fill;

        unitName.text = unit.Name;
        unitHealth.text = unit.Health + " / " + unit.MaxHealth.ToString();
    }
}
