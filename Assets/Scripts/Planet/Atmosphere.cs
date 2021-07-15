using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpaceShip"))
        {
            GravityManager.Instance.SetGravity(this.gameObject, other.gameObject);
            FindObjectOfType<SpaceShipController>().RotateShipInAtmosphere();
            CameraManager.Instance.SwitchPriotiry();
        }

        if(other.CompareTag("Player"))
        {
            GravityManager.Instance.SetAliceGravity(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("SpaceShip"))
        {
            CameraManager.Instance.SwitchPriotiry();
            GravityManager.Instance.SetZeroGravity();
            FindObjectOfType<PalancaNave>().ResetPalanca();
            FindObjectOfType<SpaceShipController>().RotateShipOutAmosphere();
        }
    }
}
