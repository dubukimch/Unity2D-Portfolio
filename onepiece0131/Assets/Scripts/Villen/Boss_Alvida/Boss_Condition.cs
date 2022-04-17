using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Boss_Condition : MonoBehaviour
{
    public GameObject Boss_Alvida;
    public Text Boss_alarm_text;
    public Text Game_Win_text;
    public Text Game_Lose_text;

    public Image Alvida_profile;
    public Slider Alvida_Hp_bar;



    public Camera playercamera;
    public Camera bosscamera;
    int Camera_Count = 0;
    bool Boss_Count = false;
    bool Boss_Camera_Count = true;
    bool Game_Win_Value = false;

    public GameObject Game_Win_Score_Canvas;
    public Image Game_Win_Score_Background;
    public Image Game_Win_Score_Result;
    public Text Game_Win_Hit_Score;
    public Text Game_Win_Kill_Score;
    public Text Game_Win_Boss_Score;
    public Text Game_Win_Total_Score;



    void Start()
    {
        Game_Win_Score_Result.enabled = false;

        Game_Win_Score_Canvas.SetActive(false);
       Boss_Alvida.SetActive(false);
        Boss_alarm_text.enabled = false;
        Alvida_Hp_bar.gameObject.SetActive(false);
        Alvida_profile.gameObject.SetActive(false);
        bosscamera.enabled = false;
        Game_Win_text.enabled=false;
    }

    void Update()
    {
        int Enemy_Count;
        GameObject[] Enemy_count = GameObject.FindGameObjectsWithTag("Enemy");
        Enemy_Count = Enemy_count.Length;

        int Boss_Count;
        GameObject[] Boss_count = GameObject.FindGameObjectsWithTag("Boss");
        Boss_Count = Boss_count.Length;

        int Player_Count;
        GameObject[] Player_count = GameObject.FindGameObjectsWithTag("Player");
        Player_Count = Player_count.Length;

        if (Enemy_Count <=0 && Boss_Count <=0 && Boss_Camera_Count == true)
        {
            if (Camera_Count == 0)
            {
                StartCoroutine(Boss_Camera_Effect());
            }

            StartCoroutine(Boss_Appear());
            Boss_Alvida.SetActive(true);
        }

        if (Enemy_Count <= 0 && Boss_Count <= 0 && Player_Count > 0 && Boss_Camera_Count == false && Game_Win_Value == false)
        {
            StartCoroutine(Game_Win());
        }
        if (Enemy_Count <= 0 && Boss_Count > 0 && Player_Count <= 0 && Boss_Camera_Count == false)
        {

        }


    }

    IEnumerator Boss_Camera_Effect()
    {
        playercamera.enabled = false;
        bosscamera.enabled = true;
        yield return new WaitForSeconds(1f);
        playercamera.enabled = true;
        bosscamera.enabled = false;
        Camera_Count = 1;

    }


    IEnumerator Boss_Appear()
{
    Boss_alarm_text.text = "<color=White>보스 알비다가 나타났습니다!!</color>";
    Boss_alarm_text.enabled = true;
    yield return new WaitForSeconds(0.5f);
    Boss_alarm_text.text = "<color=Red>보스 알비다가 나타났습니다!!</color>";
    Boss_alarm_text.enabled = true;
    yield return new WaitForSeconds(0.5f);
    Boss_alarm_text.text = "<color=White>보스 알비다가 나타났습니다!!</color>";
    Boss_alarm_text.enabled = true;
    yield return new WaitForSeconds(0.5f);
    Boss_alarm_text.text = "<color=Red>보스 알비다가 나타났습니다!!</color>";
    Boss_alarm_text.enabled = true;
    yield return new WaitForSeconds(0.5f);
    Boss_alarm_text.text = "<color=White>보스 알비다가 나타났습니다!!</color>";
    Boss_alarm_text.enabled = true;
    yield return new WaitForSeconds(0.5f);
    Boss_alarm_text.text = "<color=Red>보스 알비다가 나타났습니다!!</color>";
    Boss_alarm_text.enabled = true;
    yield return new WaitForSeconds(0.5f);
    Boss_alarm_text.enabled = false;
    Alvida_Hp_bar.gameObject.SetActive(true);
    Alvida_profile.gameObject.SetActive(true);
    Boss_Camera_Count = false;

    }

    IEnumerator Game_Win()
    {
        Game_Win_Value = true;

        Game_Win_text.text = "<color=White>보스 알비다를 쓰러트렸습니다!!</color>";
        Game_Win_text.enabled = true;
        yield return new WaitForSeconds(0.5f);

        Game_Win_text.text = "<color=Yellow>보스 알비다를 쓰러트렸습니다!!</color>";

        Game_Win_text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Game_Win_text.text = "<color=White>보스 알비다를 쓰러트렸습니다!!</color>";

        Game_Win_text.enabled = true;
        yield return new WaitForSeconds(0.5f);

        Game_Win_text.text = "<color=Yellow>보스 알비다를 쓰러트렸습니다!!</color>";
        Game_Win_text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Game_Win_text.text = "<color=White>보스 알비다를 쓰러트렸습니다!!</color>";
        Game_Win_text.enabled = true;
        yield return new WaitForSeconds(0.5f);

        Game_Win_text.text = "<color=Yellow>보스 알비다를 쓰러트렸습니다!!</color>";
        Game_Win_text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Game_Win_text.enabled = false;

            StartCoroutine(Game_Win_Score());

    }

    IEnumerator Game_Win_Score()
    {
        Game_Win_Score_Canvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        Game_Win_Kill_Score.text = "<color=White>쓰러트린 적의 점수 : </color>"+ GameManager.Instance.Kill_Score ;
        SoundManager.Instance.PlaySFXSound("song620_Score_Effect_Sound", 5f);

        yield return new WaitForSeconds(1.0f);
        Game_Win_Boss_Score.text = "<color=Yellow>쓰러트린 보스의 점수 : " + GameManager.Instance.Boss_Score + "</color>";
        SoundManager.Instance.PlaySFXSound("song620_Score_Effect_Sound", 5f);

        yield return new WaitForSeconds(1.0f);
        Game_Win_Hit_Score.text = "<color=Red>적에게 맞은 점수 : "+GameManager.Instance.Hit_Score * (-1) +"</color>";
        SoundManager.Instance.PlaySFXSound("song620_Score_Effect_Sound", 5f);

        yield return new WaitForSeconds(1.0f);
        Game_Win_Total_Score.text = "<color=White>총 점수 : </color>"+ GameManager.Instance.Total_Score;
        SoundManager.Instance.PlaySFXSound("song620_Score_Effect_Sound", 5f);

        yield return new WaitForSeconds(5.0f);
        SoundManager.Instance.PlaySFXSound("song402_Game_Win_Score_Result_Effect_Sound", 5f);
        Game_Win_Score_Result.enabled = true;

        yield return new WaitForSeconds(5.0f);
        Game_Win_Score_Canvas.gameObject.SetActive(false);

        Game_Win_text.text = "<color=White>5초 후 자동으로 게임 메뉴로 나가집니다!!</color>";
        Game_Win_text.enabled = true;
        yield return new WaitForSeconds(5f);
        Game_Win_text.enabled = false;
        GameObject.FindWithTag("GameManager").SetActive(false);
        SoundManager.Instance.Skill_Master_BGM = false;
        SceneManager.LoadScene("Game_Logo");
    }


}
