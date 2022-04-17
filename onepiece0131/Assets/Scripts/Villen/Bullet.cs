using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 1.0f;
    public float Enemy_Attack_Demage_Value = 5f;
    public GameObject effect;
    float Bullet_direction=0;
    Transform player;  

    Vector2 dir;
    void Start()
    {

        try
        {
            player = GameObject.FindWithTag("Player").transform;
            dir = (player.transform.position - transform.position).normalized;
            dir.y = 0;
          
        }

        catch (NullReferenceException ex)
        {
        }

        if (dir.x < 0)
            Bullet_direction = 1;
        else if (dir.x > 0)
            Bullet_direction = 2;

    }

    void Update()
    {
        if(Bullet_direction == 1)
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        else if (Bullet_direction == 2)
            transform.Translate(Vector2.right * Speed * Time.deltaTime);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.Instance.Villen_Demage = Enemy_Attack_Demage_Value;

        }
        else
        {
            GameManager.Instance.Villen_Demage = 0.0f;
        }

        if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
       
    }


    private void OnDestroy()
    {
        GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
        SoundManager.Instance.PlaySFXSound("song115_Pirate_Gun_Bullet_Effect_Sound", 1f);
        Destroy(go, 1);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
   
}
