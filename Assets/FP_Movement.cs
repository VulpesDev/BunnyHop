using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Movement : FP
{
    [Header("Movement Settings")]
    float horizontal, vertical;
    [SerializeField] float acc = 5f, maxSpeed = 1.4f, baseSpeed, timeModifier = 100f;
    float dirSpeedMod = 2f;

    Vector3 camStartPos;

    [Header("Walk_Sim Settings")]
    [SerializeField] float upWalkEffect = 0.05f, downWalkEffect = 0.2f;
    float metersToSkip = 0.5f, timeForStep; // 0,2f
    float lastTime;
    Vector3 lastPos, currentPos;

    void Start()
    {

        baseSpeed = maxSpeed;

        camStartPos = cam.transform.position;
        timeForStep = metersToSkip / maxSpeed;
        lastTime = Time.time;
        currentPos = transform.position; lastPos = currentPos;

    }
    void Update()
    {
        Movement(); // Movement of Player
        StepSim(); // Simulating Steps
    }
    bool goUp = false;
    void StepSim()
    {
        currentPos = transform.position;
        //if (Mathf.Abs(rb.velocity.x) >= 0.001f || Mathf.Abs(rb.velocity.z) >= 0.001f)
        //{
        //    if (Mathf.Abs(lastTime - Time.time) >= timeForStep) // If the timer goes over the time limit
        //    {

        //        cam.transform.position += new Vector3(0, upWalkEffect * Time.deltaTime, 0); // moving up
        //        Invoke("ReturnToTime", 0.2f);
        //    }
        //    else if (cam.transform.position.y > camStartPos.y)
        //    {
        //        cam.transform.position -= new Vector3(0, downWalkEffect * Time.deltaTime, 0); // moving down (reseting)
        //    }
        //}
        //else if (cam.transform.position.y > camStartPos.y)  // If not moving
        //{
        //    cam.transform.position -= new Vector3(0, downWalkEffect * Time.deltaTime, 0); // reset
        //}
        if (Mathf.Abs(rb.velocity.x) >= 0.001f || Mathf.Abs(rb.velocity.z) >= 0.001f)
        {
            if (Mathf.Abs(currentPos.x - lastPos.x) >= metersToSkip || Mathf.Abs(currentPos.z - lastPos.z) >= metersToSkip)
            {
                goUp = false;
                MusicManager.StepSounds();
                lastPos = currentPos;
            }
        }
        else
        {
            goUp = false;
        }
        if (goUp)
        {
            cam.transform.position += new Vector3(0, upWalkEffect * Time.deltaTime, 0);
        }
        else
        {
            if (cam.transform.position.y > camStartPos.y)
                cam.transform.position -= new Vector3(0, downWalkEffect * Time.deltaTime, 0);
            else
                goUp = true;
        }

    }
    //void ReturnToTime()
    //{
    //    lastTime = Time.time; // reset the stepsim timer
    //}
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
