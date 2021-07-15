using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGround : MonoBehaviour
{
    private SpaceShipController spaceShip;

    private void Start()
    {
        spaceShip = FindObjectOfType<SpaceShipController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            spaceShip.IsOnGround(true);
            FindObjectOfType<PalancaNave>().ResetPalanca();
            SpaceShipManager.Instance.Damage(Random.Range(1, 4));
            SpaceShipManager.Instance.FuelUse(Random.Range(1, 4));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            spaceShip.IsOnGround(false);
        }
    }
}
