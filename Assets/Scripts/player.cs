using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float forwardInput;
    private float horizontalInput;
    public int speed;
    public int rotationspeed;

    public static player script;
    Rigidbody RB;
    public float carCurentSpeed;
    public float carMaxSpeed;

    public WheelCollider F_Left;
    public WheelCollider F_Right;
    public WheelCollider R_Left;
    public WheelCollider R_Right;

    public Transform F_LeftT;
    public Transform F_RightT;
    public Transform R_LeftT;
    public Transform R_RightT;
    // Start is called before the first frame update
    void Start()
    {
        script = this;
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        //transform.Rotate(Vector3.up * horizontalInput * rotationspeed * Time.deltaTime);
        Accelerate();
        Steer();
        WheelsUpdate();
    }

    private void Accelerate()
    {
        R_Left.motorTorque = forwardInput * speed;
        R_Right.motorTorque = forwardInput * speed;
        carCurentSpeed = RB.velocity.magnitude * 2f / carMaxSpeed;
    }


    private void Steer()
    {
        F_Left.steerAngle = horizontalInput * rotationspeed;
        F_Right.steerAngle = horizontalInput * rotationspeed;
    }

    private void WheelsUpdate()
    {
        GetSingleWheel(F_Left, F_LeftT);
        GetSingleWheel(F_Right, F_RightT);
        GetSingleWheel(R_Left, R_LeftT);
        GetSingleWheel(R_Right, R_RightT);
    }

    private void GetSingleWheel(WheelCollider wheel, Transform wheelPosition)
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        wheel.GetWorldPose(out pos, out rot);
        wheelPosition.position = pos;
        wheelPosition.rotation = rot;
    }

    
}
