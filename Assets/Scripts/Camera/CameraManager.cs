using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //Este scrip sirve administara los tipo de movimiento de la camara del jugador, es decir cuando a donde esta mirando  y en que direccion y esta en conjunto con la scrip llamada Camara target que es donde la camara sigue al jugador 
    [SerializeField] CinemachineVirtualCamera thirdPerson = default;
    [SerializeField] CinemachineVirtualCamera topDownShip = default;
    [SerializeField] CinemachineVirtualCamera topDownAlice = default;
    [SerializeField] GameObject cameraTarget = default;
    [SerializeField] SpaceShipController spaceShip = default;
    [SerializeField] GameObject nave = default;

    private bool thirdPersonCamera = true;
    private bool isOnShip = true;

    private GameObject camObj;
    private CinemachineBrain cBrain;

    public static CameraManager Instance;

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
    //Las camaras del juego funcionan con cinemachine
    private void Start()
    {
        camObj = GameObject.FindWithTag("MainCamera");

        cBrain = camObj.GetComponent<CinemachineBrain>();
    }

    public void SwitchPriotiry()
    {
        if(thirdPersonCamera)
        {
            thirdPerson.Priority = 0;
            topDownShip.Priority = 1;
        }
        else
        {
            thirdPerson.Priority = 1;
            topDownShip.Priority = 0;
            cameraTarget.GetComponent<CameraTarget>().ChangeCamera(spaceShip.transform);
        }
        thirdPersonCamera = !thirdPersonCamera;
    }
    //Cuando te bajas de la nave estaras con el personaje Alice y podres ir a los alrededores de los planetas
    public void ChangeCameraShipAndAlice()
    {
        if(isOnShip)
        {
            topDownShip.Priority = 0;
            topDownAlice.Priority = 1;
            cBrain.m_WorldUpOverride = FindObjectOfType<CharacterControler>().transform;
            cameraTarget.GetComponent<CameraTarget>().ChangeCamera(FindObjectOfType<CharacterControler>().transform);
        }
        else
        {
            topDownShip.Priority = 1;
            topDownAlice.Priority = 0;
            cBrain.m_WorldUpOverride = nave.transform;
            cameraTarget.GetComponent<CameraTarget>().ChangeCamera(spaceShip.transform);
        }

        isOnShip = !isOnShip;
    }
}
