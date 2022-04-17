using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack4 : MonoBehaviour
{
    public GameObject Player_1;
    public GameObject Demage_Effect;
    public int Effect_Count = 1;

    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {

           
            if (Player_1.GetComponent<Player_ray>().attack4 == true)
            {
               

                if (Effect_Count == 1)
                {
                    GameObject go = Instantiate(Demage_Effect, transform.position, Quaternion.identity);
                    Destroy(go, 1);
                }
                Effect_Count = 0;

            }

            else
            {
                Effect_Count = 1;
            }
        
        }
    }
}
