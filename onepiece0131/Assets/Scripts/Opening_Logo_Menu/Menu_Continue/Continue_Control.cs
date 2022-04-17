using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Continue_Control : MonoBehaviour
{
    public Text Continue_Text;

    void Start()
    {


        Continue_Text = GameObject.Find("Continue_Text").GetComponent<Text>();
  
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
        Continue_Text.text = "<color=Yellow>이어서 하기</color>";


    }
    void OnPointerUp(PointerEventData data)
    {
        Continue_Text.text = "<color=White>이어서 하기</color>";
        GameObject.FindWithTag("Menu_Continue_UI").SetActive(false);

    }


}
