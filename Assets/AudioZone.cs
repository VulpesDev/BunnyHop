using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
    bool horn, violin, laugh, change;
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
        }
    }
}
