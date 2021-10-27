using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static public Transform ambient, player, interactions;
    private void Start()
    {
        ambient = transform.GetChild(0);
        player = transform.GetChild(1);
        interactions = transform.GetChild(2);

        StepSounds();
    }
    //Player
    static public void StepSounds()
    {
        GameObject Sound = new GameObject();
        Sound.transform.parent = player;
        AudioSource ASound = Sound.AddComponent<AudioSource>();
        ASound.clip = Resources.Load("Sounds/Player/Step1") as AudioClip;
        ASound.pitch = Random.Range(0.9f, 1.2f);
        ASound.Play();
        Sound.AddComponent<AudiosDefault>();
    }
    #region Enviroment
    //nameOfDoorSound = End, Close, Open, Locked
    static public void Door(string nameOfDoorSound,Vector3 position)
    {
        GameObject Sound = new GameObject();
        Sound.transform.position = position;
        Sound.transform.parent = player;
        AudioSource ASound = Sound.AddComponent<AudioSource>();
        ASound.spatialBlend = 1;
        ASound.clip = Resources.Load("Sounds/Enviroment/Door/Door" + nameOfDoorSound) as AudioClip;
        ASound.pitch = Random.Range(0.9f, 1.2f);
        ASound.Play();
        Sound.AddComponent<AudiosDefault>();
    }
    #endregion
}
