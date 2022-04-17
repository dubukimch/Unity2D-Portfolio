using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Opening_Skip : MonoBehaviour
{
 
    float time;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("Game_Logo");
        }
        else
        {
            StartCoroutine(auto_Start());
        }

        if (time < 0.5f)
        {
            GetComponent<Text>().color = new Color(255, 255, 255, 1 - time);


        }
        else
        {
            GetComponent<Text>().color = new Color(255, 255, 255, time);
            if(time <1f)
            {
                time = 0f;
            }
        }

        time += Time.deltaTime; 
    }

    IEnumerator auto_Start()
    {
        yield return new WaitForSeconds(261f);
        SceneManager.LoadScene("Game_Logo");

    }


}
