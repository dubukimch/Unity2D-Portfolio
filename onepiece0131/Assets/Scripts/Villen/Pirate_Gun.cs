using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pirate_Gun : MonoBehaviour
{

    enum EnemyState
    {
        Stance,
        Walk,
        Attack,
        Die



    }
    
    EnemyState Gun_State; 
    
    float findDistance = 20f; 
   
    Transform player;  
   
    float attackDistance = 4f;  
   
    float moveSpeed = 5f;  
   
    float currentTime = 0;  
    
    float attackDelay = 10f; 
   


    public float attackPower = 5f;  
    
    public float Monster_Hp = 1; 

    Animator ani;

    public GameObject Bullet;

    public Slider Monster_Hp_Bar;

    public Transform Gun_Pos_Left;
    public Transform Gun_Pos_Right;

    public GameObject Normal_Effect;
    SpriteRenderer sr;

    Vector2 dir;

    Rigidbody2D rb;

    public float Critical_Nuckback_Thrust = 3f;
    bool Critical_Nuckback_Judgement = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Gun_State = EnemyState.Stance;
        ani = GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        try
        {
            player = GameObject.FindWithTag("Player").transform;
            dir = player.transform.position - transform.position;
            findDistance = Vector2.Distance(transform.position, player.position);
            dir.y = 0;
        }

        catch (NullReferenceException ex)
        {

        }

    }
    void Update()
    {
        if (Critical_Nuckback_Judgement == true)
        {
      
           
            rb.AddForce(-dir * Critical_Nuckback_Thrust);
        }
        Distance_Judgment_();
            if (Monster_Hp < 0)
                Gun_State = EnemyState.Die;

            switch (Gun_State)
            {
                case EnemyState.Stance:
                    stance();
                    break;
                case EnemyState.Walk:
                    Walk();
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
                case EnemyState.Die:
                    Die();
                    break;
            }
    }

        void stance()
        {
     

        try
        {
                player = GameObject.FindWithTag("Player").transform;

                if(findDistance < 20f)
                {
                    Gun_State = EnemyState.Walk;  
                }

            }

            catch (NullReferenceException ex)
            {
             
            }

       

        }
        void Walk()
        {
       

        if (findDistance > attackDistance)
            {
                stance();
            }
            else
            {
                Gun_State = EnemyState.Attack;
            }
        }
        void Attack()
        {
        if (findDistance < attackDistance)

        {


            currentTime += Time.deltaTime;
           if (currentTime > attackDelay && ( dir.x >1f || dir.x < -1f) )
           {
                        currentTime = 0;
                        ani.SetTrigger("Attack");
                        if (sr.flipX == false)
                            Instantiate(Bullet, Gun_Pos_Left.position, Quaternion.identity);
                        else if (sr.flipX == true)
                    Instantiate(Bullet, Gun_Pos_Right.position, Quaternion.identity);

            }

        }
            else
            {
                Gun_State = EnemyState.Walk;
                currentTime = attackDelay;
            }
        }

        void Die()
        {
            ani.SetTrigger("Die");
            Destroy(gameObject, 1f);

         }
    void Distance_Judgment_()
    {
        try
        {
            player = GameObject.FindWithTag("Player").transform;

            findDistance= Vector2.Distance(transform.position, player.position);
            dir = player.transform.position - transform.position;
            dir.y = 0;
            if (dir.x < -1f)
            {
                sr.flipX = false;
            }
            else if (dir.x > 1f)
            {
                sr.flipX = true;
            }

        }
        catch (NullReferenceException ex)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Villen_Zone")
        {
            Gun_State = EnemyState.Stance;
        }
        if (collision.gameObject.tag == "Normal_Demage")
        {
            Monster_Hp -= 5f * Time.deltaTime;
            Monster_Hp_Bar.value = Monster_Hp;
           
        }

        else if (collision.gameObject.tag == "Critical_Demage"
            || collision.gameObject.layer == LayerMask.NameToLayer("Field_Trap"))
        {
            Monster_Hp -= 5f;
            Monster_Hp_Bar.value = Monster_Hp;
            Critical_Nuckback_Judgement = true;

        }
    }


    void FixedUpdate()
    {
    }


    private void OnCollisionEnter2D(Collision2D col)
        {


            if (col.gameObject.tag == "Enemy")
            {
                moveSpeed = moveSpeed * -1;
            }
            if (col.gameObject.tag == "Attack")
            {          
                Monster_Hp -= 5f * Time.deltaTime;
                Monster_Hp_Bar.value = Monster_Hp;
         
            }
        }

    public void Pirate_Gun_Attack_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song112_Pirate_Gun_Attack_Sound", 1f);

    }
    
    public void Pirate_Gun_Die_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song205_Pirate_Gun_Die_Sound", 2f);

    }




}

