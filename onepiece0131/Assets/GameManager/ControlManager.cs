using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private Object gameControlRef;

    private void Awake()
    {
        gameControlRef = Resources.Load("Prefabs/GameControl");
        
        if(GameControl.control == null)
        {

            Instantiate(gameControlRef);
        }

        Destroy(gameObject);
    }
}
