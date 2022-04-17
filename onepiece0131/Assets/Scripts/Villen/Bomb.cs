using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Speed = 1.0f;
    public float Bomb_Demage = 0.5f;
    public GameObject effect;
    GameObject player;
    public float thrust = 20.0f;
    public Rigidbody2D rb;
    Vector2 dir;
    float distance;

    float Enemy_Attack_Demage_Value = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        try
        {
            player = GameObject.FindWithTag("Player");
            dir = player.transform.position - transform.position;
            dir.y = 0;
            distance = Vector2.Distance(transform.position, player.transform.position);

        }
        catch (NullReferenceException ex)
        {
        }
        Destroy(gameObject,5f);


        thrust = thrust * (distance / 15);





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
        SoundManager.Instance.PlaySFXSound("song118_Pirate_Bomb_Effect_Sound", 1f);
        Bomb_Demage_judgement();
        Destroy(go, 1f);
    }

    public void Pirate_Bomb_Effect_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song118_Pirate_Bomb_Effect_Sound", 1f);

    }

    public void Bomb_Demage_judgement()
    {
        try
        {
            player = GameObject.FindWithTag("Player");
            dir = player.transform.position - transform.position;
            distance = Vector2.Distance(transform.position, player.transform.position);
        }
        catch (NullReferenceException ex)
        {
        }

        if(distance<1f)
            GameManager.Instance.Villen_Demage = Enemy_Attack_Demage_Value;

    }

}
