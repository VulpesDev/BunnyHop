using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Movement : FP
{
    [Header("Movement Settings")]
    float horizontal, vertical;
    [SerializeField]float acc = 5f, maxSpeed = 1.4f, baseSpeed, timeModifier = 100f;
    float dirSpeedMod = 2f;

    Vector3 camStartPos;
    
    [Header("Walk_Sim Settings")]
    [SerializeField] float upWalkEffect = 0.2f, downWalkEffect = 2f;
    float metersToSkip = 0.2f, timeForStep;
    float lastTime;

    void Start()
    {

        baseSpeed = maxSpeed;

        camStartPos = cam.transform.position;
        timeForStep = metersToSkip / maxSpeed;
        lastTime = Time.time;
    }
    void Update()
    {
        Movement(); // Movement of Player
        StepSim(); // Simulating Steps
    }

    void StepSim()
    {
        if (Mathf.Abs(rb.velocity.x) >= 0.001f || Mathf.Abs(rb.velocity.z) >= 0.001f)
        {
            if (Mathf.Abs(lastTime - Time.time) >= timeForStep) // If the timer goes over the time limit
            {
                cam.transform.position += new Vector3(0, upWalkEffect * Time.deltaTime, 0); // moving up
                Invoke("ReturnToTime", 0.2f);
            }
            else if (cam.transform.position.y > camStartPos.y)
            {
                cam.transform.position -= new Vector3(0, downWalkEffect * Time.deltaTime, 0); // moving down (reseting)
            }
        }
        else if (cam.transform.position.y > camStartPos.y)  // If not moving
        {
            cam.transform.position -= new Vector3(0, downWalkEffect * Time.deltaTime, 0); // reset
        }
        if (Mathf.Abs(lastTime - Time.time) <= 0.01)
        {

            // Play step sound HERE (Could have problems with timing and/or multiple plays at once)
        }
    }
    void ReturnToTime()
    {
        lastTime = Time.time; // reset the stepsim timer
    }
    void Movement()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (vertical >= 0.5f) // client is pressing "w"
        {
            //Move forwards
            maxSpeed = baseSpeed;

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(transform.forward * acc * Time.deltaTime * timeModifier);
        }
        if (vertical <= -0.5f) // client is pressing "s"
        {
            //Move backwards
            maxSpeed = baseSpeed;
            maxSpeed /= dirSpeedMod;

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(-transform.forward * acc * Time.deltaTime * timeModifier);
        }

        if (horizontal >= 0.5f) // client is pressing "d"
        {
            //Move right
            maxSpeed = baseSpeed;
            maxSpeed /= dirSpeedMod;

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(transform.right * acc * Time.deltaTime * timeModifier);
        }
        if (horizontal <= -0.5f) // client is pressing "a"
        {
            //Move left
            maxSpeed = baseSpeed;
            maxSpeed /= dirSpeedMod;

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(-transform.right * acc * Time.deltaTime * timeModifier);
        }
    }
}
