using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TierraItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 1;
    [SerializeField] GameObject arbusto = default;
    [SerializeField] GameObject baya = default;
    [SerializeField] float segundosParaAparecerArbusto = 1f;
    [SerializeField] float segundosParaAparecerBaya = 1f;

    private int currentUsos = 0;

    public void Apply()
    {
        //Debug.Log("Se uso item");
        InventoryManager.Instance.UseSemilla();

        //Destroy(this.gameObject);
        StartCoroutine(ActivateArbusto());
    }

    public int CurrentUsos()
    {
        throw new System.NotImplementedException();
    }

    public void OneUse()
    {
        currentUsos++;
        //Debug.Log(currentUsos);

        if (currentUsos >= usos)
        {
            Apply();
        }
    }

    public void RespwanBaya()
    {
        StartCoroutine(ActivateBaya());
    }

    IEnumerator ActivateArbusto()
    {
        yield return new WaitForSeconds(segundosParaAparecerArbusto);

        arbusto.SetActive(true);
        baya.SetActive(true);
    }

    IEnumerator ActivateBaya()
    {
        yield return new WaitForSeconds(segundosParaAparecerBaya);

        baya.SetActive(true);
    }
}
