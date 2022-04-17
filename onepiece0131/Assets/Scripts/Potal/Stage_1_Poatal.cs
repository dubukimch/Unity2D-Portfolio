using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_1_Poatal : MonoBehaviour
{
    public GameObject BackGround;

  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Player" )
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        int Enemy_Count;
        GameObject[] Enemy_count = GameObject.FindGameObjectsWithTag("Enemy");

        Enemy_Count = Enemy_count.Length;

        if (Enemy_Count < 1)
            SceneManager.LoadScene("Alvida's_Ship_2");
    }
}
