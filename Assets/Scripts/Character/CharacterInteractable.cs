using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractable : MonoBehaviour
{
    [SerializeField] float radius = 2f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckInteractablesItems();
            //Random.Range(0, 1);
        }

        //CheckInteractablesItemsForSlider();
    }

    private void CheckInteractablesItems()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Item"))
            {
                Debug.Log("Entro");
                if (InventoryManager.Instance.CanTakeItems)
                {
                    int useOrNot = Random.Range(0, 2);
                    if (useOrNot > 0)
                        InventoryManager.Instance.MinusBaya();

                    hitCollider.GetComponent<IInteractable>().OneUse();
                }
            }
            else if(hitCollider.CompareTag("Bayas"))
            {
                hitCollider.GetComponent<IInteractable>().OneUse();
            }
        }
    }

    //private void CheckInteractablesItemsForSlider()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

    //    foreach(var hitCollider in hitColliders)
    //    {
    //        if(hitCollider.CompareTag("Item"))
    //        {
    //            FindObjectOfType<SliderManager>().TurnOnSlider();
    //        }
    //    }
    //}
}
