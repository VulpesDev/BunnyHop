using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
    public static int zonesPassed = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(name == "BattleHorn")
            {
                if(zonesPassed == 0)
                MusicManager.BattleHorn();
                zonesPassed++;
            }
        }
    }
}
