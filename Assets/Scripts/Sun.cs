using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpaceShip"))
        {
            FindObjectOfType<WinManager>().GameOver();
        }
    }
}
