using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    //SERIALIZED PROPERTIES
    [SerializeField] float strafeThrust = 100f;
    [SerializeField] float mainThrust = 15f;
    [SerializeField] float rollAngle = .5f;

    //FIXED PROPERTIES
    internal Vector3 rollAxis = new Vector3(0f, 0f, 1f);
    //GENERAL VARIABLES
    Rigidbody rigidbody;
    //ENUMS
    enum KeyAction
    {        
        Forward = KeyCode.W,
        Backward = KeyCode.S,
        StrafeLeft = KeyCode.A,
        StrafeRight = KeyCode.D
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerInput();
    }

    void HandlePlayerInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
        Movement();
    }
    void Movement()
    {
        OnInputRoll();
        OnInputLinearMovement();
        OnInputStrafe();
    }

    private void OnInputRoll()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Roll(rollAngle);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Roll(-rollAngle);
        }
        else
        {

        }
    }

    private void Roll(float rollAngle)
    {        
        transform.Rotate(rollAxis, rollAngle);
    }

    private void OnInputLinearMovement()
    {
        if (Input.GetKey((KeyCode)KeyAction.Forward))
        {
            LinearMovement(Vector3.forward);
        }
        else if (Input.GetKey((KeyCode)KeyAction.Backward))
        {
            LinearMovement(Vector3.back);
        }
        else
        {

        }
    }
    private void LinearMovement(Vector3 direction)
    {
        rigidbody.AddRelativeForce(direction * mainThrust);
    }

    private void OnInputStrafe()
    {

        if (Input.GetKey((KeyCode)KeyAction.StrafeLeft))
        {
            Strafe(Vector3.left);
        }
        else if (Input.GetKey((KeyCode)KeyAction.StrafeRight))
        {
            Strafe(Vector3.right);
        }
        else 
        {

        }
    }

    private void Strafe(Vector3 direction)
    {
        rigidbody.freezeRotation = true;//manual rotation
        float strafeThisFrame = strafeThrust * Time.deltaTime;
        float maxStrafeVelocity = strafeThisFrame * 10;
        rigidbody.AddRelativeForce(direction * maxStrafeVelocity);
    }

}
