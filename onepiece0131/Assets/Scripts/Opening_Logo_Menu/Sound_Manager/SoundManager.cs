using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    int count = 0;

    public AudioMixer masterMixer;
    public Slider MASTERaudioSlider;
    public Slider BGMaudioSlider;
    public Slider SFXaudioSlider;

    private AudioSource bgmPlayer;
    private AudioSource sfxplayer;

    public float masterVolumeMASTER = 1f;
    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;

    [SerializeField]
    public AudioClip SkillMasterBgmAudioClip;

    [SerializeField]
    public AudioClip LogoBgmAudioClip;
    [SerializeField]
    public AudioClip mainBgmAudioClip;
    [SerializeField]
    public AudioClip adventureBgmAudioClip;
    [SerializeField]
    private AudioClip[] sfxAudioClips;

    Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>();


    bool sfxPlayer_Value = false;

    public float MASTERsound = 1f;
    public float BGMsound = 1f;
    public float SFXsound = 1f;


    public bool MASTER_IsOn = true;
    public bool BGM_IsOn = true;
    public bool SFX_IsOn  = true;

    public bool Skill_Master_BGM = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this.gameObject);

        bgmPlayer = GameObject.Find("BGMSoundPlayer").GetComponent<AudioSource>();
        sfxplayer = GameObject.Find("SFXSoundPlayer").GetComponent<AudioSource>();

        foreach (AudioClip audioclip in sfxAudioClips)
        {
            audioClipsDic.Add(audioclip.name, audioclip);
        }
    }
    public void bgmSoundStop()
    {
        bgmPlayer.Stop();
    }
    public void PlaySFXSound(string name, float volume = 1f)
    {
        if(audioClipsDic.ContainsKey(name) == false)
        {
            return;
        }
        sfxplayer.PlayOneShot(audioClipsDic[name],volume*masterVolumeSFX);
    }

    public void PlayerBGMSound(float volume =1f)
    {
        bgmPlayer.loop = true;
        bgmPlayer.volume = volume * masterVolumeBGM;
        if ((Skill_Master_BGM == false)
            &&((SceneManager.GetActiveScene().name == "Alvide's_Ship_1")
            || (SceneManager.GetActiveScene().name == "Alvida's_Ship_2")
            || (SceneManager.GetActiveScene().name == "Alvida's_Ship_3")))
        {
            if (bgmPlayer.clip == mainBgmAudioClip)
            {
                return;
            }
            else
            {
                sfxplayer.enabled = true;
                sfxplayer.clip = null;

                bgmPlayer.clip = mainBgmAudioClip;
                bgmPlayer.Play();

            }
        }
        if ((Skill_Master_BGM == false)
            && SceneManager.GetActiveScene().name == "Adventure")
        {
            if (bgmPlayer.clip == adventureBgmAudioClip)
            {
                return;
            }
            else
            {
                bgmPlayer.clip = adventureBgmAudioClip;
                bgmPlayer.Play();
            }
        }
        if ((Skill_Master_BGM == false)
            && (SceneManager.GetActiveScene().name == "Game_Logo")
             || (SceneManager.GetActiveScene().name == "Game_Option"))
        {
            if (bgmPlayer.clip == LogoBgmAudioClip)
            {
                return;
            }
            else
            {
                bgmPlayer.clip = LogoBgmAudioClip;
                bgmPlayer.Play();
                sfxplayer.enabled = false;

            }


        }
        if (Skill_Master_BGM == true)
        {
            if (bgmPlayer.clip == SkillMasterBgmAudioClip)
            {
                return;
            }
            else
            {
                bgmPlayer.clip = SkillMasterBgmAudioClip;
                bgmPlayer.Play();
                

            }
        }

    }
    void Start()
    {
        PlaySFXSound("song108_Jump_Sound", 0.5f);
        sfxplayer.loop = true;
        
    }
    private void Update()
    {
      
            try
            {
                MASTERaudioSlider = GameObject.Find("Whole_Sound_Slider").GetComponent<Slider>();
                BGMaudioSlider = GameObject.Find("BGM_Sound_Slider").GetComponent<Slider>();
                SFXaudioSlider = GameObject.Find("Effect_Sound_Slider").GetComponent<Slider>();
                MASTER_IsOn = GameObject.Find("Whole_Sound_Toggle").GetComponent<Toggle>().isOn;
                BGM_IsOn = GameObject.Find("BGM_Sound_Toggle").GetComponent<Toggle>().isOn;
                SFX_IsOn = GameObject.Find("Effect_Sound_Toggle").GetComponent<Toggle>().isOn;
 

        }
        catch (NullReferenceException ex)
            {

            }

        PlayerBGMSound();
    }


    public void AudioControl()
    {
        MASTERsound = MASTERaudioSlider.value;
        BGMsound = BGMaudioSlider.value;
        SFXsound = SFXaudioSlider.value;


        if (MASTERsound == -40f)
            masterMixer.SetFloat("Master", -80);
        else
            masterMixer.SetFloat("Master", MASTERsound);

        if (SFXsound == -40f)
            masterMixer.SetFloat("BGM", -80);
        else
            masterMixer.SetFloat("BGM", BGMsound);

        if (BGMsound == -40f)
            masterMixer.SetFloat("Effect", -80);
        else
            masterMixer.SetFloat("Effect", SFXsound);
    }



    public void MasteronPointerDown()
    {
        sfxplayer.clip = sfxAudioClips[2];
        sfxplayer.Play();
        sfxplayer.enabled = true;
        sfxplayer.loop = true;

    
    }

    public void MasteronPointerUp()
    {
       

        sfxplayer.enabled = false;
       

    }
    public void BGMonPointerDown(){ }
    public void BGMonPointerUp() { }


    public void SFXonPointerDown()
    {
       
        sfxplayer.clip = sfxAudioClips[2];
        sfxplayer.Play();
        sfxplayer.enabled = true;
  

    }
    public void SFXonPointerUp()
    {
        sfxplayer.enabled = false;

    }

}
