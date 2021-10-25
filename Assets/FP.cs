using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP : MonoBehaviour
{
    //tripping + creepy zvuk
    //creepy zvuci na interactibles
    //klatene nagore - nadolu            V

    Rigidbody rb;
    float horizontal, vertical;
    float speed = 1.4f, baseSpeed;
    float dirSpeedMod = 2f;

    GameObject cam;
    Vector3 camStartPos;

    [SerializeField] float upWalkEffect = 0.2f, downWalkEffect = 2f;
    float metersToSkip = 0.2f, timeForStep;
    float lastTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        baseSpeed = speed;

        cam = transform.GetChild(0).gameObject;
        camStartPos = cam.transform.position;
        timeForStep = metersToSkip / speed;
        lastTime = Time.time;
    }
    void Update()
    {
        Movement(); // Movement of Player
        StepSim(); // Simulating Steps
    }

    void StepSim()
    {
        if (vertical != 0 || horizontal != 0)
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
        if(Mathf.Abs(lastTime - Time.time) <= 0.01)
        {
            Debug.Log("Contact");
            
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
            speed = baseSpeed;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, transform.forward.z * speed);
        }
        if (vertical <= -0.5f) // client is pressing "s"
        {
            //Move backwards
            speed = baseSpeed;
            speed /= dirSpeedMod;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -transform.forward.z * speed);
        }

        if (horizontal >= 0.5f) // client is pressing "d"
        {
            //Move right
            speed = baseSpeed;
            speed /= dirSpeedMod;
            rb.velocity = new Vector3(transform.right.x * speed, rb.velocity.y, rb.velocity.z);
        }
        if (horizontal <= -0.5f) // client is pressing "a"
        {
            //Move left
            speed = baseSpeed;
            speed /= dirSpeedMod;
            rb.velocity = new Vector3(-transform.right.x * speed, rb.velocity.y, rb.velocity.z);
        }
    }
}
