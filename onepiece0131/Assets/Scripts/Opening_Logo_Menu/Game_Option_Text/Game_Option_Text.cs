using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Option_Text : MonoBehaviour
{
    public Text Exit_text;
    public void Exit_OnClick()
    {
        Exit_text.text = "<color=yellow>옵션 나가기</color>";

        SceneManager.LoadScene("Game_Logo");
    }
    public void Exit_OffClick()
    {
        Exit_text.text = "<color=White>옵션 나가기</color>";

    }
}
