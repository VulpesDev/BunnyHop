using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
    bool horn, violin, laugh, change, door, door2;
    [SerializeField]GameObject room1, room2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (name == "BattleHorn" && !horn)
            {
                MusicManager.BattleHorn();
                horn = true;
            }
            if (name == "ScaryViolinShort" && !violin)
            {
                MusicManager.ScaryViolinsShort();
                violin = true;
            }
            if (name == "ClownLaugh" && !laugh)
            {
                MusicManager.ClownLaugh();
                laugh = true;
            }
            if (name == "ChangeRoom" && !change)
            {
                room1.SetActive(false);
                room2.SetActive(true);
            }
            if(name == "DoorStart" && !door)
            {
                Debug.Log("DoorSound");
                MusicManager.Door("End", GameObject.FindGameObjectWithTag("Player").transform.position);
                Invoke("DoorSound", 2f);
                door = true;
            }
            if (name == "DoorStart2" && !door2)
            {
                GameObject.Find("Footsteps").GetComponent<AudioSource>().enabled = true;
                GameObject.Find("Footsteps").transform.GetChild(0).gameObject.SetActive(true);
                door2 = true;
            }
        }
    }
    void DoorSound()
    {
        MusicManager.Door("Close", GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
