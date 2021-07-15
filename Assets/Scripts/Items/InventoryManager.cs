using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Slider slider = default;
    //[SerializeField] int hidrogeno = 5;
    //[SerializeField] int metal = 5;
    //[SerializeField] int azufre = 5;
    [SerializeField] int bayas = 6;
    [SerializeField] TMP_Text bayasText = default;
    [SerializeField] TMP_Text hidrogenoText = default;
    [SerializeField] TMP_Text azufreText = default;
    [SerializeField] TMP_Text metalText = default;
    [SerializeField] TMP_Text semillaText = default;

    private int currentHidrogeno = 0;
    private int currentMetal = 0;
    private int currentAzufre = 0;
    private int currentBayas = 6;
    private int semillas = 50;

    private int currentSemillas = 50;

    private int maxItems = 5;

    public bool CanTakeItems => canTakeItems;

    private bool canTakeItems = true;

    public static InventoryManager Instance;

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
        bayasText.text = currentBayas + "/" + bayas;
        hidrogenoText.text = currentHidrogeno + "/" + maxItems;
        azufreText.text = currentAzufre + "/" + maxItems;
        metalText.text = currentMetal + "/" + maxItems;
        semillaText.text = currentSemillas + "/" + semillas;
    }

    public void TakeMetal()
    {
        if(currentMetal < maxItems)
        {
            currentMetal++;
            metalText.text = currentMetal + "/" + maxItems;
        }
    }

    public int UseMetalInShip(int life)
    {
        int amoun = 0;

        for(int i = currentMetal; i > 0; i--)
        {
            currentMetal--;
            metalText.text = currentMetal + "/" + maxItems;
            amoun++;
            
            if(amoun + life == 5)
            {
                break;
            }
        }

        return amoun;

        //if(currentMetal > 0)
        //{
        //    currentMetal--;
        //}
    }

    public bool IsEnoughMetal()
    {
        if (currentMetal > 0)
        {
            return true;
        }

        return false;
    }

    public void TakeHidrogeno()
    {
        if(currentHidrogeno < maxItems)
        {
            currentHidrogeno++;
            hidrogenoText.text = currentHidrogeno + "/" + maxItems;
        }
    }

    //public void UseHidrogeno()
    //{
    //    if (currentHidrogeno > 0)
    //    {
    //        currentHidrogeno--;
    //    }
    //}

    public void TakeAzufre()
    {
        if(currentAzufre < maxItems)
        {
            currentAzufre++;
            azufreText.text = currentAzufre + "/" + maxItems;
        }
    }

    //public void UseAzufre()
    //{
    //    if (currentAzufre > 0)
    //    {
    //        currentAzufre--;
    //    }
    //}

    public int UseFuelInShip(int fuel)
    {
        //int amount = currentAzufre - currentHidrogeno;
        int amount = 0;

        if(currentAzufre < currentHidrogeno)
        {
            for(int i = currentAzufre; i > 0; i--)
            {
                amount++;
                currentAzufre -= amount;
                currentHidrogeno -= amount;

                if (amount + fuel == 5)
                {
                    //currentAzufre -= amount;
                    //currentHidrogeno -= amount;
                    azufreText.text = currentAzufre + "/" + maxItems;
                    hidrogenoText.text = currentHidrogeno + "/" + maxItems;
                    //break;
                    return amount;
                }
            }
        }
        else if(currentHidrogeno < currentAzufre)
        {
            for (int i = currentHidrogeno; i > 0; i--)
            {
                amount++;
                currentAzufre -= amount;
                currentHidrogeno -= amount;

                if (amount + fuel == 5)
                {
                    //currentAzufre -= amount;
                    //currentHidrogeno -= amount;
                    azufreText.text = currentAzufre + "/" + maxItems;
                    hidrogenoText.text = currentHidrogeno + "/" + maxItems;
                    //break;
                    return amount;
                }
            }
        }
        else if(currentAzufre == currentHidrogeno)
        {
            for (int i = currentHidrogeno; i > 0; i--)
            {
                amount++;
                currentAzufre -= amount;
                currentHidrogeno -= amount;

                if (amount + fuel == 5)
                {
                    //currentAzufre -= amount;
                    //currentHidrogeno -= amount;
                    azufreText.text = currentAzufre + "/" + maxItems;
                    hidrogenoText.text = currentHidrogeno + "/" + maxItems;
                    //break;
                    return amount;
                }
            }
        }

        azufreText.text = currentAzufre + "/" + maxItems;
        hidrogenoText.text = currentHidrogeno + "/" + maxItems;

        return amount;

        //return amount;

        //for(int i = currentAzufre; i > 0; i--)
        //{
        //    currentAzufre--;
        //    azufreText.text = currentAzufre + "/" + maxItems;

        //    for (int j = 0; j > 0; j--)
        //    {
        //        currentHidrogeno--;

        //        amount++;

        //        if(currentHidrogeno <= 0)
        //        {
        //            break;
        //        }
        //        else if(amount + fuel == 5)
        //        {
        //            break;
        //        }
        //    }
        //}

    }

    public bool IsEnoughAzufreAndHidrogeno()
    {
        if (currentAzufre > 0 && currentHidrogeno > 0)
        {
            return true;
        }

        return false;
    }

    public bool EatBaya()
    {
        if(currentBayas < bayas)
        {
            currentBayas++;
            bayasText.text = currentBayas + "/" + bayas;
            canTakeItems = true;
            return true;
        }

        return false;
    }

    public void MinusBaya()
    {
        currentBayas--;

        if (currentBayas > 0)
        {
            bayasText.text = currentBayas + "/" + bayas;
        }
        else if(currentBayas <= 0)
        {
            //Muerte
            currentBayas = 0;
            bayasText.text = currentBayas + "/" + bayas;
            canTakeItems = false;
        }
    }

    public void UseSemilla()
    {
        if(semillas > 0)
        {
            currentSemillas--;
            semillaText.text = currentSemillas + "/" + semillas;
        }
    }

    public void ChangeSlider()
    {

    }
}
