using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Control : MonoBehaviour
{
    public Text Menu_Text;

    void Start()
    {
      

        Menu_Text = GameObject.Find("Menu_Text").GetComponent<Text>();
        


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
        Menu_Text.text = "<color=Yellow>나가기</color>";

    }
    void OnPointerUp(PointerEventData data)
    {
        Menu_Text.text = "<color=White>나가기</color>";
        SceneManager.LoadScene("Game_Logo");

  
    }


}
