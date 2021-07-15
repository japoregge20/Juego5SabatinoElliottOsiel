using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] Slider slider = default;
    [SerializeField] Button fillFuel = default;
    [SerializeField] Button fixShip = default;

    public void TurnOnSlider(int amount)
    {
        slider.gameObject.SetActive(true);
        slider.value = amount;
    }

    public void TurnOffSlider()
    {
        slider.gameObject.SetActive(false);
    }

    public void AddSliderValue(int amount)
    {
        slider.value = amount;
    }

    public void TurnOnFix()
    {
        fillFuel.gameObject.SetActive(true);
        fixShip.gameObject.SetActive(true);
    }

    public void TurnOffFix()
    {
        fillFuel.gameObject.SetActive(false);
        fixShip.gameObject.SetActive(false);
    }
}
