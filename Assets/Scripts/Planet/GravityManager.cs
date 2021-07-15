using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public bool IsOnPLanet => isOnPlanet;

    private GameObject planet = default;
    private GameObject spaceShip = default;
    private GameObject alicePrefab = default;

    private bool isOnPlanet = false;
    //private bool aliceIsOut = false;

    public static GravityManager Instance;

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
        Physics.gravity = Vector3.zero;
    }

    private void Update()
    {
        if(isOnPlanet && alicePrefab == null)
        {
            ShipGravity();
        }

        if(alicePrefab != null)
        {
            AliceGravity();
        }
    }

    private void ShipGravity()
    {
        Physics.gravity = planet.transform.position - spaceShip.transform.position;
    }

    private void AliceGravity()
    {
        Physics.gravity = planet.transform.position - alicePrefab.transform.position;
    }

    public void SetGravity(GameObject planetGravity, GameObject spaceShipGravity)
    {
        isOnPlanet = true;

        planet = planetGravity;
        spaceShip = spaceShipGravity;
    }

    public void SetZeroGravity()
    {
        isOnPlanet = false;
        Physics.gravity = Vector3.zero;
    }

    public void SetAliceGravity(GameObject alice)
    {
        //aliceIsOut = true;
        alicePrefab = alice;
    }

    public void QuitAliceGravity()
    {
        alicePrefab = null;
    }
}
