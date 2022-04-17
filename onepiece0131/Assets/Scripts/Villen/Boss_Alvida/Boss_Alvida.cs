using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss_Alvida : MonoBehaviour
{
    enum EnemyState
    {
        Stance,
        Walk_Attack,
        Die

    }
    EnemyState Alvida_State;


    public GameObject Critical_Effect;
    public GameObject Normal_Demage;

    public GameObject Attack_Zone; 

    public float Speed = 1;

    public Slider Alvida_Hp_Bar;

    public float Alvida_Hp = 1f;

    public float Enemy_Attack_Demage_Value = 100f;



    public float AttackDistance = 5f;

    public float FindDistance = 300f;

    public float Attack_Judgment = 0;

    public float Distance_Judgment = 0;

    float Player_Distance;
    
    float Die_thrust = 1f;

    float Walk_Attack_thrust = -1f;

    public bool fight_result = false;


    SpriteRenderer sr;
    Animator ani;

    Vector2 dir;
    Rigidbody2D rb;
    GameObject player;

    void Start()
    {
        Alvida_State = EnemyState.Stance;

        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Start_condition();
        Attack_Zone.SetActive(false);

    }


    void Update()
    {
        if(Alvida_Hp <0)
        Alvida_State = EnemyState.Die;


        switch (Alvida_State)
        {
            case EnemyState.Stance:
                Stance();
                break;

            case EnemyState.Walk_Attack:
                Walk_Attack();
                break;

            case EnemyState.Die:
                Die();
                break;
        }


    }

    public void Start_condition()
    {
        try
        {
            player = GameObject.FindWithTag("Player");
            dir = transform.position - player.transform.position;
            Player_Distance = Vector2.Distance(transform.position, player.transform.position);

        }
        catch (NullReferenceException ex)
        {

        }


        if (Player_Distance < FindDistance)
        {
            if (dir.x > 0)
            {
                sr.flipX = true;
                Attack_Zone.transform.localScale = new Vector2(1f, 1f);
            }
            else if (dir.x < 0)
            {
                sr.flipX = false;
                Attack_Zone.transform.localScale = new Vector2(-1f, 1f);

            }
        }

    }

    void Stance()
    {

        Start_condition();

        if (Player_Distance < AttackDistance)
        {
            Alvida_State = EnemyState.Walk_Attack;

        }
            ani.SetTrigger("Stance");

    }
    void Walk_Attack()
    {
        if (Player_Distance < AttackDistance)
        {
            Start_condition();
            ani.SetTrigger("Walk_Attack");
            StartCoroutine(Walk_Attack_Delay());
            Attack_Judgment = 1;
        }
        else if (Player_Distance > AttackDistance)
        {
       
            Alvida_State = EnemyState.Stance;
        }
    }

    IEnumerator Walk_Attack_Delay()
    {
        dir.y = 0;
        rb.AddForce(dir * Walk_Attack_thrust);
        yield return new WaitForSeconds(3f);
    }

    void Die()
    {
        ani.SetTrigger("Die");
        fight_result = true;
        Thrust_Die();
        Destroy(gameObject, 2f);
    }

    public void Thrust_Die()
    {
        Start_condition();
        rb.gravityScale = 0.01f;
        rb.AddForce(dir * Die_thrust);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Normal_Demage")
        {
 

            Alvida_Hp -= 5f * Time.deltaTime;
            Alvida_Hp_Bar.value = Alvida_Hp;
        }
        else if (collision.gameObject.tag == "Critical_Demage")
        {
            Alvida_Hp -= 5f;
            Alvida_Hp_Bar.value = Alvida_Hp;
        }
    }
 
    void Alvida_Attack()
    {
        if (Attack_Judgment == 1)
        {
            GameManager.Instance.Villen_Demage = Enemy_Attack_Demage_Value;
            StartCoroutine(Alvida_Attack_Delay());
        }
    }

    IEnumerator Alvida_Attack_Delay()
    {
        Attack_Zone.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Attack_Zone.SetActive(false);
    }
    public void Alvida_Attack_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song116_Alvida_Attack_Sound", 2f);

    }
}
