using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Whole_Valume_Control : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    public AudioSource audio_Effect;
    public AudioSource audio_BGM;

   
    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) 
            masterMixer.SetFloat("Master", -80);
        else 
            masterMixer.SetFloat("Master", sound);

    }


    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }


    public void onPointerDown()
    {
       
        audio_Effect.enabled = true;
        audio_BGM.enabled = true;
    }

    public void onPointerUp()
    {
        audio_Effect.enabled = false;
        audio_BGM.enabled = false;

    }
}
