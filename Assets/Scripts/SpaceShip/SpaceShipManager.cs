using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpaceShipManager : MonoBehaviour
{
    [SerializeField] int fuel = 5;
    [SerializeField] int life = 5;
    [SerializeField] GameObject humo = default;
    [SerializeField] TMP_Text fuelAmountText = default;
    [SerializeField] TMP_Text lifeAmountText = default;

    private int currentFuel;
    private int currentLife;

    public bool HaveFuel => haveFuel;

    private bool haveFuel = true;

    public static SpaceShipManager Instance;
    private void Awake()
    {
        // I will check if I am the first singletong
        if (Instance == null)
        {
            // ... since i am the one, I declare myself as the one
            Instance = this;

            // ... and I will live forever
            DontDestroyOnLoad(this);

        }
        else
        {
            // I am not the one... I will walk to the eternal darkness
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        currentFuel = 1;
        currentLife = life;

        fuelAmountText.text = currentFuel + "/" + fuel;
        lifeAmountText.text = currentLife + "/" + life;
    }

    public void Damage(int amount)
    {
        currentLife -= amount;

        if (currentLife > 0)
        {
            //currentLife--;
            lifeAmountText.text = currentLife + "/" + life; 

            if(currentLife <= 3)
            {
                humo.SetActive(true);
            }
        }
        else if(currentLife <= 0)
        {
            //Muerte sceneManager
            FindObjectOfType<WinManager>().GameOver();
        }
    }

    public void Cure()
    {
        if(currentLife < life)
        {
            if (InventoryManager.Instance.IsEnoughMetal())
            {
                currentLife += InventoryManager.Instance.UseMetalInShip(currentLife);
            }

            lifeAmountText.text = currentLife + "/" + life;

            if (currentLife > 3)
            {
                humo.SetActive(false);
            }
        }
    }

    public void FuelUse(int amount)
    {
        currentFuel -= amount;

        if(currentFuel > 0)
        {
            fuelAmountText.text = currentFuel + "/" + fuel;
            //Debug.Log("Tiene Combustible");
        }
        else if(currentFuel <= 0)
        {
            //No Mover
            currentFuel = 0;
            //Debug.Log("No tiene combustible");
            fuelAmountText.text = currentFuel + "/" + fuel;
            Damage(1);
            haveFuel = false;
        }
    }

    public void FillFuel()
    {
        if (currentFuel < fuel)
        {
            if (InventoryManager.Instance.IsEnoughAzufreAndHidrogeno())
            {
                int i = InventoryManager.Instance.UseFuelInShip(currentFuel);
                currentFuel += i;
            }
            Debug.Log(currentFuel);
            //currentFuel = fuel;

            fuelAmountText.text = currentLife + "/" + life;

            if (currentFuel > 0)
            {
                haveFuel = true;
            }
        }
    }
}
