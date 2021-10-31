using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MenuManager : MonoBehaviour
{
    AudioMixer mixer;
    private void Start()
    {
        mixer = Resources.Load("Sounds/Master") as AudioMixer;
        SetVolume();
        SetSensitivity();
    }
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    float sliderValue;
    [SerializeField] Slider musicSlider;
    public void SetVolume()
    {
        sliderValue = musicSlider.value;
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    float sensValue;
    [SerializeField] Slider sensSlider;
    public void SetSensitivity()
    {
        sensValue = sensSlider.value;
        FP_Aim.mouseSensitivity = sensValue;
    }
}
