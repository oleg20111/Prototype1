using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float turnSpeed = 20f;
    private float speed;
    private float rpm;
    private Rigidbody playerRb;

    public List<WheelCollider> allWheels;
    public int wheelsOnGround;
    public float horsePower = 20;
    public GameObject centerOfMass;
    public TextMeshProUGUI spedometrText;
    public TextMeshProUGUI rpmText;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    private void Update()
    {
        if (IsOnGround())
        {
            MoveLogic();
            SpeedAndRPMText();
        }
    }

    private void MoveLogic()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }

    private void SpeedAndRPMText()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
        spedometrText.SetText("Speed: " + speed + "km/h");
    }

    private bool IsOnGround()
    {
        return true;
        /*wheelsOnGround = 0;
        foreach (WheelCollider whell in allWheels)
        {
            if (whell.isGrounded)
            {
                wheelsOnGround++;
                Debug.Log(wheelsOnGround);
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }*/
    }
}
