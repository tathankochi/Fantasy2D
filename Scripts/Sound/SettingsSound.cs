using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSound : MonoBehaviour
{
    private AudioSource soundBG;
    private AudioSource soundRemain;
    [SerializeField]
    private Slider sliderBG;
    [SerializeField]
    private Slider sliderRemain;
    [SerializeField]
    private Toggle toggleBG;
    [SerializeField]
    private Toggle toggleRemain;
    // Start is called before the first frame update
    void Start()
    {
        soundBG = GameObject.Find("soundBG").GetComponent<AudioSource>();
        soundRemain=GameObject.Find("soundRemain").GetComponent<AudioSource>();
        toggleBG.isOn = soundBG.mute;
        toggleRemain.isOn = soundRemain.mute;
        sliderBG.value = soundBG.volume;
        sliderRemain.value = soundRemain.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Toggle1()
    {
        soundBG.mute=toggleBG.isOn;
    }
    public void Toggle2()
    {
        soundRemain.mute = toggleRemain.isOn;
    }
    public void Slide1()
    {
        soundBG.volume= sliderBG.value;
    }
    public void Slide2()
    {
        soundRemain.volume = sliderRemain.value;
    }
}
