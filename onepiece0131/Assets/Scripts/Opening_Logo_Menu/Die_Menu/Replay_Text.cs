using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Replay_Text : MonoBehaviour
{
    public Text Replay_text;

    void Start()
    {


        Replay_text = GameObject.Find("RePlay_Text").GetComponent<Text>();

        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();

        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();

        entry_PointerDown.eventID = EventTriggerType.PointerDown;

        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);

        EventTrigger.Entry entry_PointerUp = new EventTrigger.Entry();

        entry_PointerUp.eventID = EventTriggerType.PointerUp;

        entry_PointerUp.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerUp);


    }


    void OnPointerDown(PointerEventData data)
    {
        Replay_text.text = "<color=Yellow>다시 하기</color>";


    }
    void OnPointerUp(PointerEventData data)
    {
        Replay_text.text = "<color=White>다시 하기</color>";
        GameManager.Instance.Player_Hp = 1.0f;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Alvide's_Ship_1");
        GameObject.FindWithTag("Die_Menu_UI").SetActive(false);

    }

}
