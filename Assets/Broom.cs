using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("BroomRoom"))
        {
            MusicManager.BroomFall(transform.position);
        }
    }
}
