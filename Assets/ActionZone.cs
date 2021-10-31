using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionZone : MonoBehaviour
{
    bool change;
    [SerializeField] GameObject room1, room2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (name == "ChangeRoom" && !change)
            {
                room1.SetActive(false);
                room2.SetActive(true);
                change = true;
            }
        }
    }
}
