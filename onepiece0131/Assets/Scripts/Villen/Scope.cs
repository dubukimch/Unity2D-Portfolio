using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public int Scope_Value = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scope_Value = 0;
        if (collision.gameObject.tag == "Player")
        {
            
            Scope_Value = 1;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            Scope_Value = 0;
        }
    }
}
