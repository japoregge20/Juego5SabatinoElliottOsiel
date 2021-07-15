using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 2f;
    //[SerializeField] float shipMinimumClose = 1f;

    private Vector3 rotationInput;
    private Vector3 rotationVelocity;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FeetOnTheGround();

        float h = Input.GetAxisRaw("Horizontal");

        rotationInput = new Vector3(0f, h, 0f);
        rotationVelocity = rotationInput * rotationSpeed;

        CharacterMovement();

        //if(Input.GetKey(KeyCode.E) && ShipIsClose())
        //{
        //    GoIn();
        //}
    }

    public void GoIn()
    {
        GravityManager.Instance.QuitAliceGravity();

        Destroy(this.gameObject);
    }

    //private bool ShipIsClose()
    //{
    //    float distance = Vector3.Distance(FindObjectOfType<SpaceShipController>().transform.position, this.transform.position);

    //    if(distance <= shipMinimumClose)
    //    {
    //        return true;
    //    }

    //    return false;
    //}

    private void CharacterMovement()
    {
        transform.Rotate(rotationVelocity);

        //rb.velocity = transform.forward + movementVelocity;

        if(Input.GetKey(KeyCode.W)) { transform.Translate(new Vector3(0, 0, speed * Time.deltaTime)); }
        if(Input.GetKey(KeyCode.S)) { transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime)); }
    }

    private void FeetOnTheGround()
    {
        transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation;
    }
}
