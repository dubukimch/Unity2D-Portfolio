using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{

    float time;

    void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - time);


        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time);
            if (time < 1f)
            {
                time = 0f;
            }
        }
    }


}
