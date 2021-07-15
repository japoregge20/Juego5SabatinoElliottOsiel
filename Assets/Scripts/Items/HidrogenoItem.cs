using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidrogenoItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 3;
    [SerializeField] AudioSource hidrogeno = default;
    [SerializeField] AudioSource bubble = default;

    private int currentUsos = 0;

    public void Apply()
    {
        //Debug.Log("Se uso item");
        InventoryManager.Instance.TakeHidrogeno();
        hidrogeno.Play();

        //Destroy(this.gameObject);
    }

    public void OneUse()
    {
        currentUsos++;
        FindObjectOfType<SliderManager>().AddSliderValue(currentUsos);
        bubble.Play();

        if (currentUsos >= usos)
        {
            Apply();
            currentUsos = 0;
        }
    }

    public int CurrentUsos()
    {
        return currentUsos;
    }
}
