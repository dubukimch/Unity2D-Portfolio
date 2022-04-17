using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class Skill_Video_Controllers : MonoBehaviour
{

    public GameObject myVideo;
    public VideoPlayer Basic_Punch_Video;
    public VideoPlayer Basic_Kick_Video;
    public VideoPlayer Gomu_Vazooka_Video;

 
    public VideoPlayer Basic_Ax_Video;
 

    private void Start()
    {
        myVideo.SetActive(false);
        Basic_Punch_Video.gameObject.SetActive(false);
        Basic_Kick_Video.gameObject.SetActive(false);

    }
    public void Basic_Punch_OnPlayVideo()
    {

        myVideo.SetActive(true);
        Basic_Punch_Video.gameObject.SetActive(true);
        Basic_Punch_Video.Play();
    }

    public void Basic_Punch_OnResetVideo()
    {
 
        Basic_Punch_Video.time = 0f;
        Basic_Punch_Video.gameObject.SetActive(false);
        myVideo.SetActive(false);
    }

    public void Basic_Kick_OnPlayVideo()
    {

        myVideo.SetActive(true);
        Basic_Kick_Video.gameObject.SetActive(true);
        Basic_Kick_Video.Play();
    }

    public void Basic_Kick_OnResetVideo()
    {

        Basic_Kick_Video.time = 0f;
        Basic_Kick_Video.gameObject.SetActive(false);
        myVideo.SetActive(false);
    }
    public void Gomu_Vazooka_OnPlayVideo()
    {
        myVideo.SetActive(true);
        Gomu_Vazooka_Video.gameObject.SetActive(true);
        Gomu_Vazooka_Video.Play();
    }
    public void Gomu_Vazooka_OnResetVideo()
    {
        Gomu_Vazooka_Video.time = 0f;
        Gomu_Vazooka_Video.gameObject.SetActive(false);
        myVideo.SetActive(false);
    }
 
    public void Basic_Ax_OnPlayVideo()
    {
        myVideo.SetActive(true);
        Basic_Ax_Video.gameObject.SetActive(true);

        Basic_Ax_Video.Play();
    }
    public void Basic_Ax_OnResetVideo()
    {
        Basic_Ax_Video.time = 0f;
        Basic_Ax_Video.gameObject.SetActive(false);
        myVideo.SetActive(false);
    }
}
