using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase Instance;
    public bool Count = false;
    private void Awake()
    {
        Instance = this;

    }

    public List<Item>itemDB = new List<Item>();
    [Space(20)]
    public GameObject FieldItemPrefab;
    public Vector2[] pos;

   

    private void Update()
    {
        
        Item_Create();

    }

    void Item_Create()
    {
        if (Count == false &&((SceneManager.GetActiveScene().name == "Alvide's_Ship_1")
        || (SceneManager.GetActiveScene().name == "Alvida's_Ship_2")
        || (SceneManager.GetActiveScene().name == "Alvida's_Ship_3")))
        {
            Count = true;
            for (int i = 0; i < 3; i++)
            {
                GameObject go = Instantiate(FieldItemPrefab, pos[i], Quaternion.identity);
                go.GetComponent<FieldItem>().SetItem(itemDB[Random.Range(0, 3)]);
            }

        }
        if ((SceneManager.GetActiveScene().name == "Game_Option")
            || (SceneManager.GetActiveScene().name == "Game_Logo"))
        {
            Count = false;


        }
    }



}
