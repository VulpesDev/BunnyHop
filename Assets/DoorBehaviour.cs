using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] bool locked;
    bool canSoundEnd = true, canSoundClose = false, closed = true;
    float zRotation;
    void Update()
    {
        zRotation = Mathf.Rad2Deg * transform.localRotation.z;


        if((zRotation > 16f || zRotation < -16f) && canSoundEnd)
        {
            MusicManager.Door("End", transform.position);
            canSoundEnd = false;
        }
        else if ((zRotation < 16f && zRotation >0f) || (zRotation > -16f && zRotation < 0f))
        {
            canSoundEnd = true;
        }
        if(zRotation > -0.5f && zRotation < 0.5f)
        {
            if (canSoundClose)
            {
                closed = true;
                MusicManager.Door("Close", transform.position);
            }
            canSoundClose = false;
        }
        else
        {
            closed = false;
            canSoundClose = true;
        }

        if(closed)
            GetComponent<Rigidbody>().isKinematic = true;
        else
            GetComponent<Rigidbody>().isKinematic = false;
    }
    public void OpenDoor()
    {
        if(!locked)
        {
            MusicManager.Door("Open", transform.position);
            closed = false;
        }
        else
        {
            MusicManager.Door("Locked", transform.position);
        }
    }

}
