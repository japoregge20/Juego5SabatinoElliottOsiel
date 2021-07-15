using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForSlider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            FindObjectOfType<SliderManager>().TurnOnSlider(other.GetComponent<IInteractable>().CurrentUsos());
        }

        if(other.CompareTag("SpaceShip"))
        {
            FindObjectOfType<SliderManager>().TurnOnFix();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            FindObjectOfType<SliderManager>().TurnOffSlider();
        }

        if (other.CompareTag("SpaceShip"))
        {
            FindObjectOfType<SliderManager>().TurnOffFix();
        }
    }
}
