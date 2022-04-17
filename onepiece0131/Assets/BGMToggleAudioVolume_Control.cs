using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BGMToggleAudioVolume_Control : MonoBehaviour
{
    

    void Start()
    {
        Debug.Log("BGM 토글값 :" + gameObject.GetComponent<Toggle>().isOn);
        Debug.Log("매니저 BGM 토글값 :" + SoundManager.Instance.BGM_IsOn);

        gameObject.GetComponent<Toggle>().isOn = SoundManager.Instance.BGM_IsOn;

        Toggle toggle = gameObject.GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { BGMToggleAudioVolume(); });

    }

    public void BGMToggleAudioVolume()
    {
        GameObject.FindWithTag("BGMSound").GetComponent<AudioSource>().mute
            = GameObject.FindWithTag("BGMSound").GetComponent<AudioSource>().mute == false ? true : false;

    }
}
