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
    [SerializeField] InputField sensInputField;
    public void SetSensitivity()
    {
        string content = sensInputField.text;
        content = content.Replace('.', ',');
        if(content == "" || content == ",")
        {
            content = "1";
        }
        sensValue = float.Parse(content);

        FP_Aim.mouseSensitivity *= sensValue;
    }
}
