using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_2_Left_Potal : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
            SceneManager.LoadScene("Alvide's_Ship_1");
    }
}
