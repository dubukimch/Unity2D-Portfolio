using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SFXToggleAudio_Control : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Toggle>().isOn= SoundManager.Instance.SFX_IsOn;

        Toggle toggle = gameObject.GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { SFXToggleAudioVolume(); });

    }

    public void SFXToggleAudioVolume()
    {

        GameObject.FindWithTag("SFXSound").GetComponent<AudioSource>().mute
            = GameObject.FindWithTag("SFXSound").GetComponent<AudioSource>().mute == false ? true : false;
    }

}
