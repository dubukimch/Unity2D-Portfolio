using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Effect_Valume_Control : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;
   

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) 
            masterMixer.SetFloat("Effect", -80);
        else 
            masterMixer.SetFloat("Effect", sound);

    }


    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

    void Start()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;

    }

    public void onPointerDown()
    {
        gameObject.GetComponent<AudioSource>().enabled = true;
    }
    public void onPointerUp()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;

    }
}
