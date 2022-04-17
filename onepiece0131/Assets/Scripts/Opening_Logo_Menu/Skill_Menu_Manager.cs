using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Skill_Menu_Manager : MonoBehaviour
{
    public Text Basic_Punch_text;
    public Text Basic_Punch_Value_text;
    public Text Basic_Kick_text;
    public Text Basic_Kick_Value_text;
    public Text Gomu_Raple_text;
    public Text Gomu_Raple_Value_text;
    public Text Gomu_Bazooka_text;
    public Text Gomu_Bazooka_Value_text;
    public Text Gomu_Gatling_text;
    public Text Gomu_Gatling_Value_text;
    public Text Gomu_Spear_text;
    public Text Gomu_Spear_Value_text;
    public Text Gomu_Ax_text;
    public Text Gomu_Ax_Value_text;
    public Text Gomu_Balloon_text;
    public Text Gomu_Balloon_Value_text;

    bool Basic_Punch_Value = true;
    bool Basic_Kick_Value = true;
    bool Gomu_Raple_Value = false;
    bool Gomu_Bazooka_Value = false;
    bool Gomu_Gatling_Value = false;
    bool Gomu_Spear_Value = false;
    bool Gomu_Ax_Value = false;
    bool Gomu_Balloon_Value = false;
    void Start()
    {

        Basic_Punch_text.text = "<color=White> �⺻ ������</color>";     
        Basic_Punch_Value_text.text = "<color=White> ���� </color>";
        Basic_Kick_text.text = "<color=White> �⺻ ������</color>";      
        Basic_Kick_Value_text.text = "<color=White> ���� </color>";
        Gomu_Raple_text.text = "<color=Red> �� ������ </color>";       
        Gomu_Raple_Value_text.text = "<color=Red> �Ұ��� </color>";
        Gomu_Bazooka_text.text = "<color=Red> �� ����ī </color>";     
        Gomu_Bazooka_Value_text.text = "<color=Red> �Ұ��� </color>";
        Gomu_Gatling_text.text = "<color=Red> �� ��Ʋ�� </color>";     
        Gomu_Gatling_Value_text.text = "<color=Red> �Ұ��� </color>";
        Gomu_Spear_text.text = "<color=Red> �� â </color>";           
        Gomu_Spear_Value_text.text = "<color=Red> �Ұ��� </color>";
        Gomu_Ax_text.text = "<color=Red> �� ���� </color>";           
        Gomu_Ax_Value_text.text = "<color=Red> �Ұ��� </color>";
        Gomu_Balloon_text.text = "<color=Red> �� ǳ�� </color>";      
        Gomu_Balloon_Value_text.text = "<color=Red> �Ұ��� </color>";

    }

    void Update()
    {
        Player_Skill_Status();
        if (Gomu_Raple_Value == true)
        {
            Gomu_Raple_text.text = "<color=White> �� ������ </color>";
            Gomu_Raple_Value_text.text = "<color=White> ���� </color>";
        }

        if(Gomu_Bazooka_Value == true)
        {
            Gomu_Bazooka_text.text = "<color=White> �� ����ī </color>";
            Gomu_Bazooka_Value_text.text = "<color=White> ���� </color>";
        }

        if(Gomu_Gatling_Value == true)
        {
            Gomu_Gatling_text.text = "<color=White> �� ��Ʋ�� </color>";
            Gomu_Gatling_Value_text.text = "<color=White> ���� </color>";
        }

        if (Gomu_Spear_Value == true)
        {
            Gomu_Spear_text.text = "<color=White> �� â </color>";
            Gomu_Spear_Value_text.text = "<color=White> ���� </color>";
        }
        if (Gomu_Ax_Value == true)
        {
            Gomu_Ax_text.text = "<color=White> �� ���� </color>";
            Gomu_Ax_Value_text.text = "<color=White> ���� </color>";
        }
        if (Gomu_Balloon_Value == true)
        {
            Gomu_Balloon_text.text = "<color=White> �� ǳ�� </color>";
            Gomu_Balloon_Value_text.text = "<color=White> ���� </color>";
        }
    }

    public void Player_Skill_Status()
    {

        Basic_Punch_Value = GameManager.Instance.Basic_Punch_Value;
        Basic_Kick_Value = GameManager.Instance.Basic_Kick_Value;
        Gomu_Raple_Value = GameManager.Instance.Gomu_Raple_Value;
        Gomu_Bazooka_Value = GameManager.Instance.Gomu_Bazooka_Value;
        Gomu_Gatling_Value = GameManager.Instance.Gomu_Gatling_Value;
        Gomu_Spear_Value = GameManager.Instance.Gomu_Spear_Value;
        Gomu_Ax_Value = GameManager.Instance.Gomu_Ax_Value;
        Gomu_Balloon_Value = GameManager.Instance.Gomu_Balloon_Value;

    }


}
