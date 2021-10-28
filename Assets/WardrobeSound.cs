using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeSound : MonoBehaviour
{
    public void PlayJumpscare()
    {
        MusicManager.JumpScare();
    }
    public void OpenWardrobe()
    {
        MusicManager.Door("Open", transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("Open", true);
        }
    }
}
