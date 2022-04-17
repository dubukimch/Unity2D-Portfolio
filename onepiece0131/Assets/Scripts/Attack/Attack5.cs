using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack5 : MonoBehaviour
{

    float Attack_Distance;
    float Attack_limit_Distance = 3f;

    public GameObject Player_1;
    public GameObject Demage_Effect;
    public int Effect_Count = 1;
    float Speed = 10f;
    Transform player;
    PolygonCollider2D poly;

    void Start()
    {
        poly = GetComponent<PolygonCollider2D>();
        poly.isTrigger = true;
    }
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        try
        {
            player = GameObject.FindWithTag("Player").transform;

            Attack_Distance = Vector2.Distance(transform.position, player.position);

        }
        catch (NullReferenceException ex)
        {
            

        }

        if (Attack_Distance > Attack_limit_Distance)
            Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
     
        if (col.gameObject.tag == "Enemy")
        {

          
            if (Player_1.GetComponent<Player_ray>().attack5 == true)
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

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            poly.isTrigger = false;
        }
    }

}
