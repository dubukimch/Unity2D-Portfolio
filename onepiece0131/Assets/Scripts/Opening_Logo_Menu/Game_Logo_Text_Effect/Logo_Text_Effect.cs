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
        Start_text.text = "<color=yellow>게임 시작</color>";
        
        SceneManager.LoadScene("Alvide's_Ship_1");
    }

    public void Start_OffClick()
    {
        Start_text.text = "<color=White>게임 시작</color>";

    }

    public void Option_OnClick()
    {
        Option_text.text = "<color=yellow>게임 옵션</color>";
        SceneManager.LoadScene("Game_Option");


    }
    public void Option_OffClick()
    {
        Option_text.text = "<color=white>게임 옵션</color>";

    }

    public void Exit_OnClick()
    {
        Exit_text.text = "<color=yellow>게임 나가기</color>";
        Application.Quit();
    }
    public void Exit_OffClick()
    {
        Option_text.text = "<color=white>게임 나가기</color>";

    }


}
