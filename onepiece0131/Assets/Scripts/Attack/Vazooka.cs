using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vazooka : MonoBehaviour
{
    GameObject player;


    public GameObject Critical_Demage_Effect;
    public int Effect_Count = 1;

    float Speed = 10f;

    Transform player_transfrom;

    float Attack_Distance;
    float Attack_limit_Distance = 2f;
    PolygonCollider2D poly;

    SpriteRenderer sr;
    void Start()
    {
        poly = GetComponent<PolygonCollider2D>();
        poly.isTrigger = true;
        try
        {
            player = GameObject.FindWithTag("Player");
            sr = player.GetComponent<SpriteRenderer>();
            Attack_Distance = Vector2.Distance(transform.position, player.transform.position);
        }
        catch (NullReferenceException ex)
        {
            
        }

    }



    void Update()
    {
        try
        {
            player = GameObject.FindWithTag("Player");
            Attack_Distance = Vector2.Distance(transform.position, player.transform.position);
            sr = player.GetComponent<SpriteRenderer>();

        }
        catch (NullReferenceException ex)
        {
          
        }

        if (sr.flipX == false)
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        else if (sr.flipX == true)
            transform.Translate(Vector2.left * Speed * Time.deltaTime);

        if (Attack_Distance > Attack_limit_Distance)
            Destroy(gameObject);



    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

                if (Effect_Count == 1)
                {
                    GameObject go = Instantiate(Critical_Demage_Effect, transform.position, Quaternion.identity);
                SoundManager.Instance.PlaySFXSound("song101_Critical_Effect_Sound", 1f);

                Destroy(go, 1);
                Effect_Count = 0;

            }
          
            else
            {
                Effect_Count = 1;

            }

        }
    }

}
