using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalancaNave : MonoBehaviour
{
    [SerializeField] Slider slider = default;
    [SerializeField] SpaceShipController spaceShip = default;
    [SerializeField] float thrusterForce = 250f;

    private AudioSource fly;

    private bool isPlaying = false;

    private void Start()
    {
        fly = GetComponent<AudioSource>();
    }

    public void OnSliderChanged(float value)
    {
        if (SpaceShipManager.Instance.HaveFuel)
        {
            switch (value)
            {
                case 1:
                    //Debug.Log("Velocidad de 1");
                    spaceShip.TurnOffContrains();
                    spaceShip.ShipForce(thrusterForce / 3);
                    PlayAudio();
                    break;

                case 2:
                    //Debug.Log("Velocidad de 2");
                    spaceShip.TurnOffContrains();
                    spaceShip.ShipForce(thrusterForce / 2);
                    PlayAudio();
                    break;

                case 3:
                    spaceShip.TurnOffContrains();
                    spaceShip.ShipForce(thrusterForce / 1);
                    PlayAudio();
                    break;

                case 0:
                    spaceShip.ShipForce(0);
                    spaceShip.ShipForceNegative(0);
                    spaceShip.TurnOnContrains();
                    fly.Stop();
                    isPlaying = false;
                    break;
            }
        }
    }

    private void PlayAudio()
    {
        if(!isPlaying)
        {
            fly.Play();
            isPlaying = true;
        }
    }

    public void ResetPalanca()
    {
        slider.value = 0;
    }
}
