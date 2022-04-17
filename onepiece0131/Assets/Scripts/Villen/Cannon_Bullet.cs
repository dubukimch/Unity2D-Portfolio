using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon_Bullet : MonoBehaviour
{
    public float Speed = 1.0f;
    public float Enemy_Attack_Demage_Value = 10.0f;
    public GameObject effect;
    GameObject player;
    public float thrust = 1.0f;
    Rigidbody2D rb;

    Vector2 dir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        try
        {
            player = GameObject.FindWithTag("Player");
            dir = player.transform.position - transform.position;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("포탄 플레이어 찾기 시도!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("총알맞음");
            Destroy(gameObject);
            GameManager.Instance.Villen_Demage = Enemy_Attack_Demage_Value;
        }
        else
        {
            GameManager.Instance.Villen_Demage = 0;
        }
        if (collision.tag == "Ground" ) 
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }


    }

    private void FixedUpdate()
    {
        StartCoroutine("gravity_Scale_Time");
    }

    IEnumerator gravity_Scale_Time()
    {
        rb.AddForce(dir * thrust);
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(-dir * thrust);
    }

    private void OnDestroy()
    {
        GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
        SoundManager.Instance.PlaySFXSound("song201_Cannon_Bullet_Effect_Sound", 1f);

        Destroy(go, 1);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject,1f);
    }
    
}
