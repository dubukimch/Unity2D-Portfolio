using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion


    Item _item;
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    public List<Item> items;

    private int slotCnt;
    public int SlotCnt
    {
        get=>slotCnt;
        set
        {

            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    

    void Start()
       
    {
        try
        {
            items = GameObject.FindWithTag("UI").GetComponent<InventoryUI>().items;
        }
        catch(NullReferenceException ex)
        {

        }
            SlotCnt = 20;
    }

    public bool UpdateItem(Item _item)
    {
        if (items != null)
        {
            items.Add(_item);
            if (onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;   
    }



    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }





    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="FieldItem")
        {
            FieldItem fieldItem = collision.gameObject.GetComponent<FieldItem>();
            if (AddItem(fieldItem.GetItem()))
                fieldItem.DestroyItem();
        }
    }

}
