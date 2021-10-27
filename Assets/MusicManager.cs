using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //ADD scare meter a.k.a. if scare meter is 1, volume of heartbeat is 1. Different sounds add scare points

    static public Transform ambient, player, interactions;
    static public AudioSource heartBeat;

    private float volDownSpeed = 0.05f;

    public static MusicManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        ambient = transform.GetChild(0);
        player = transform.GetChild(1);
        interactions = transform.GetChild(2);
        heartBeat = GameObject.Find("HeartBeat").GetComponent<AudioSource>();
    }
    private void Update()
    {
        HeartBeatUpdate();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Clown();
        }
    }

    #region Player
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
    private void HeartBeatUpdate()
    {
        heartBeat.volume -= volDownSpeed * Time.deltaTime;
    }

    public static IEnumerator AddScarePoints(float count, float timeSecs)
    {
        yield return new WaitForSeconds(timeSecs);
        heartBeat.volume += count;
    }

    #endregion

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

    #region Ambient
    static public void Clown()
    {
        GameObject Sound = new GameObject();
        Sound.transform.parent = player;
        AudioSource ASound = Sound.AddComponent<AudioSource>();
        ASound.spatialBlend = 1;
        ASound.clip = Resources.Load("Sounds/Ambient/ClownLaugh") as AudioClip;
        ASound.pitch = Random.Range(0.9f, 1.2f);
        instance.StartCoroutine(AddScarePoints(0.5f, 0.5f));
        ASound.Play();
        Sound.AddComponent<AudiosDefault>();
    }
    static public void BattleHorn()
    {
        GameObject Sound = new GameObject();
        Sound.transform.parent = player;
        AudioSource ASound = Sound.AddComponent<AudioSource>();
        ASound.clip = Resources.Load("Sounds/Ambient/BattleHorns") as AudioClip;
        ASound.pitch = Random.Range(0.9f, 1.2f);
        instance.StartCoroutine(AddScarePoints(0.3f, 1f));
        ASound.Play();
        Sound.AddComponent<AudiosDefault>();
    }
    #endregion
}
