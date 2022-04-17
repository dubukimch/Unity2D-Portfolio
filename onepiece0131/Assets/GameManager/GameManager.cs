using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool Basic_Punch_Value = true;
    public bool Basic_Kick_Value = true;
    public bool Gomu_Raple_Value = false;
    public bool Gomu_Bazooka_Value = false;
    public bool Gomu_Gatling_Value = false;
    public bool Gomu_Spear_Value = false;
    public bool Gomu_Ax_Value = false;
    public bool Gomu_Balloon_Value = false;




    public static GameManager Instance;

    public Transform pos;

    public int GameContro_Count_Value;

    public float Player_Hp = 1f;
    public float experience;
    public int Hit_Count = 0;
    public int Hit_Score = 0;
    public int Kill_Count = 14;
    public int Kill_Score = 0;
    public int Boss_Kill = 1;
    public int Boss_Score = 500;
    public int Total_Score = 0;
    GameObject Villen;
    public float Villen_Demage = 0;

    GameObject player;
    GameObject soundmanager;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }



    void Start()
    {

    }
    void Update()
    {
        Game_Score();
        Inventory_Active();

        Player_Camera_Instance(); 


        Monster_Attack_Demage();
    }


  void Player_Camera_Instance()
    {
        if (((SceneManager.GetActiveScene().name == "Alvide's_Ship_1")
           || (SceneManager.GetActiveScene().name == "Alvida's_Ship_2")
           || (SceneManager.GetActiveScene().name == "Alvida's_Ship_3")))
           {
            int Player_Count;
            GameObject[] Player_count = GameObject.FindGameObjectsWithTag("Player");

            Player_Count = Player_count.Length;


            if (Player_Count < 1)
            {

                player = Resources.Load<GameObject>("Player");
                GameObject go = Instantiate(player, pos.position, Quaternion.identity);
                GameObject.Find("CM").GetComponent<CinemachineVirtualCamera>().Follow = go.transform;
            }
        }
    }
    void SoundManager_Instance()
    {
        int SoundManager_Count;
        GameObject[] SoundManager_count = GameObject.FindGameObjectsWithTag("SoundManager");

        SoundManager_Count = SoundManager_count.Length;

        if (SoundManager_Count < 1)
        {
            soundmanager = Resources.Load<GameObject>("SoundManager");
            GameObject so = Instantiate(soundmanager, transform.position, Quaternion.identity);
            
        }

    }
    void Monster_Attack_Demage()
    {
            try
            {
                 Player_Hp -= (Villen_Demage * Time.deltaTime);
                
            
                if (Villen_Demage > 0)
                 {
                        Hit_Count += 10;
                        Villen_Demage = 0;
                 }
            }

            catch(NullReferenceException ex)
            {
            }

      
    }

   

    public void Game_Score()
    {
        
        Hit_Score = ((int)Hit_Count / 10)*(100);
        Kill_Score = Kill_Count * 1000;
        Boss_Score = Boss_Kill * 5000000;
        Total_Score = Kill_Score + Boss_Score + Hit_Score; 
    }

    public void Inventory_Active()
    {

        if (((SceneManager.GetActiveScene().name == "Alvide's_Ship_1")
           || (SceneManager.GetActiveScene().name == "Alvida's_Ship_2")
           || (SceneManager.GetActiveScene().name == "Alvida's_Ship_3")))
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if ((SceneManager.GetActiveScene().name == "Game_Option")
            || (SceneManager.GetActiveScene().name == "Game_Logo"))
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            Hit_Count = 0;
        }
       
    }
}
