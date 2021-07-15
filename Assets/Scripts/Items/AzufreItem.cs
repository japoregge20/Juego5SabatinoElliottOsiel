using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AzufreItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 3;
    [SerializeField] AudioSource hammer = default;
    [SerializeField] AudioSource hammerFinal = default;
    //[SerializeField] Slider azufreSlider = default;

    private int currentUsos = 0;

    public void Apply()
    {
        InventoryManager.Instance.TakeAzufre();
        hammerFinal.Play();

        //Destroy(this.gameObject);
    }

    public int CurrentUsos()
    {
        return currentUsos;
    }

    public void OneUse()
    {
        currentUsos++;
        FindObjectOfType<SliderManager>().AddSliderValue(currentUsos);
        hammer.Play();

        if (currentUsos >= usos)
        {
            Apply();
            currentUsos = 0;
        }
    }
}
