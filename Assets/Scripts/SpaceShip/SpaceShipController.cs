using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 0f;
    [SerializeField] float thrusterForceNegative = 0f;
    [SerializeField] float tiltingForce = 10f;
    [SerializeField] float limitVelocity = 5f;
    [SerializeField] GameObject alice = default;
    [SerializeField] GameObject spawnAlice = default;
    [SerializeField] GameObject spaceShipPreffab = default;

    private Vector3 rotationInput;
    private Vector3 rotationVelocity;

    private float currentThrusterForce;

    private bool shipOnGround = false;
    private bool shipDesaccelerate = false;

    public bool ShipOnGround => shipOnGround;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!InOutShipManager.Instance.IsAliceOut)
        {
            FeetOnTheGround();
        }

        if(!GravityManager.Instance.IsOnPLanet)
        {
            SpaceRotation();
        }

        //if(Input.GetKey(KeyCode.E) && shipOnGround && !InOutShipManager.Instance.IsAliceOut)
        //{
        //    GoOut();
        //}
    }

    private void FixedUpdate()
    {
        if (!InOutShipManager.Instance.IsAliceOut)
        {
            //if (Input.GetKey(KeyCode.U))
            //{
            //    UpForce();
            //}

            //if (Input.GetKey(KeyCode.J))
            //{
            //    DownForce();
            //}

            UpForce();
            DownForce();

            //if (shipDesaccelerate)
            //{
            //    ForceDesaccelerate();
            //}
        }
    }

    public void GoOut()
    {
        Instantiate(alice, spawnAlice.transform.position, Quaternion.identity);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.freezeRotation = true;
    }

    public void ResetConstraints()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.freezeRotation = true;
    }

    private void SpaceRotation()
    {
        float tiltX = Input.GetAxisRaw("Horizontal");
        float tiltZ = Input.GetAxisRaw("Vertical");

        rotationInput = new Vector3(tiltZ, 0f, -tiltX);
        rotationVelocity = rotationInput.normalized * tiltingForce;

        if(!Mathf.Approximately(tiltX, 0f) || !Mathf.Approximately(tiltZ, 0f))
        {
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationVelocity);

            transform.Rotate(rotationVelocity);
        }
    }

    private void UpForce()
    {
        //rb.AddRelativeForce(Vector3.up * currentThrusterForce * Time.deltaTime);
        if(GravityManager.Instance.IsOnPLanet)
        {
            rb.AddRelativeForce(Vector3.up * currentThrusterForce * Time.deltaTime);
        }
        else if(rb.velocity.y < limitVelocity && rb.velocity.y > -limitVelocity && rb.velocity.x < limitVelocity && rb.velocity.x > -limitVelocity && rb.velocity.z < limitVelocity && rb.velocity.z > -limitVelocity)
        {
            rb.AddRelativeForce(Vector3.up * currentThrusterForce * Time.deltaTime);
        } 
    }

    private void DownForce()
    {
        rb.AddRelativeForce(-Vector3.up * thrusterForceNegative * Time.deltaTime);
    }

    public void ShipForce(float value)
    {
        //thrusterForce = value;
        currentThrusterForce = value;
    }

    public void ShipForceNegative(float value)
    {
        thrusterForceNegative = value;
    }

    private void FeetOnTheGround()
    {
        transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation;
    }

    public void IsOnGround(bool ground)
    {
        shipOnGround = ground;
    }

    public void TurnOnContrains()
    {
        shipDesaccelerate = true;

        StartCoroutine(Desaccelerate());

        //rb.constraints = RigidbodyConstraints.FreezePosition;
        //rb.freezeRotation = true;
    }

    public void TurnOffContrains()
    {
        shipDesaccelerate = false;

        rb.constraints = RigidbodyConstraints.None;
        rb.freezeRotation = true;
    }

    IEnumerator Desaccelerate()
    {
        yield return new WaitForSeconds(1);

        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.freezeRotation = true;
    }

    public void RotateShipInAtmosphere()
    {
        //spaceShipPreffab.transform.DORotate(new Vector3(0f, -90f, 0f), 1f, RotateMode.Fast);
        if(!InOutShipManager.Instance.IsAliceOut)
            spaceShipPreffab.transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation;
    }

    public void RotateShipOutAmosphere()
    {
        //spaceShipPreffab.transform.DORotate(new Vector3(0f, -90f, 90f), 1f, RotateMode.Fast);
        spaceShipPreffab.transform.localEulerAngles = new Vector3(0f, -90f, 90);
    }

    private void ForceDesaccelerate()
    {
        currentThrusterForce -= Time.deltaTime * 0.2f;

        if(currentThrusterForce <= 0)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.freezeRotation = true;
        }
    }
}
