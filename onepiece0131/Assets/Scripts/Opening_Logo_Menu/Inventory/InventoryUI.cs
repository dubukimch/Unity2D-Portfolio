using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    

    Inventory inven;

    public GameObject inventoryPanel;
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;
    public List<Item> items = new List<Item>();

    private void Start()
    {
        initialize();
     
    }

    
    private void SlotChange(int val)
    {

        for (int i = 0; i < slots.Length; i++)
        {

            slots[i].slotnum = i;
            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }
    }


    private void Update()
    {
        int count;
        initialize();

        if (GameObject.FindWithTag("Player").GetComponent<Inventory>().items.Count >= items.Count)
        {
            items = GameObject.FindWithTag("Player").GetComponent<Inventory>().items;
            count = items.Count;


        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    public void AddSlot()
    {
     
            inven.SlotCnt++;
     

    }

    void RedrawSlotUI()
    {
        for (int i =0; i<slots.Length;i++)
        {
            slots[i].RemoveSlot();

        }
        for (int i=0;i<inven.items.Count;i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UpdateSlotUI();
        }


    }

    void initialize()
    {
        try
        {
            inven = Inventory.instance;
            slots = slotHolder.GetComponentsInChildren<Slot>();
            inven.onSlotCountChange += SlotChange;
            inven.onChangeItem += RedrawSlotUI;
            inventoryPanel.SetActive(activeInventory);

        }
        catch (NullReferenceException ex)
        {

        }

        




    }

}