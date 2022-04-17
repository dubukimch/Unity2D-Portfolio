using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logo_Text_Effect : MonoBehaviour
{

    public Text Start_text;
    public Text Option_text;
    public Text Exit_text;




    public void Start_OnClick()
    {
        Start_text.text = "<color=yellow>���� ����</color>";
        
        SceneManager.LoadScene("Alvide's_Ship_1");
    }

    public void Start_OffClick()
    {
        Start_text.text = "<color=White>���� ����</color>";

    }

    public void Option_OnClick()
    {
        Option_text.text = "<color=yellow>���� �ɼ�</color>";
        SceneManager.LoadScene("Game_Option");


    }
    public void Option_OffClick()
    {
        Option_text.text = "<color=white>���� �ɼ�</color>";

    }

    public void Exit_OnClick()
    {
        Exit_text.text = "<color=yellow>���� ������</color>";
        Application.Quit();
    }
    public void Exit_OffClick()
    {
        Option_text.text = "<color=white>���� ������</color>";

    }


}
