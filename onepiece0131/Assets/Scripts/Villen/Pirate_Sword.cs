using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pirate_Sword: MonoBehaviour
{
    enum EnemyState
    {
        Stance,
        Walk,
        Attack,
        Die
    }

    EnemyState Sword_State;

    SpriteRenderer sr;
    Animator ani;
    public GameObject Critical_Effect;
    public GameObject Normal_Effect;

    public float Speed = 1;

    bool fadein = false;

    float time = 0;

    float thrust = 1f;

    Transform player;

    public Slider Monster_Hp_Bar;

    public float Monster_Hp=1f;

    public float Enemy_Attack_Demage_Value = 1f;


 
    public float AttackDistance = 2f;

 
    public float FindDistance = 30f;

    public float Attack_Judgment = 0;

    public float Distance_Judgment = 0;

    Vector2 dir;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Sword_State = EnemyState.Stance;
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();

        try
        {
            player = GameObject.FindWithTag("Player").transform;

            Distance_Judgment = Vector2.Distance(transform.position, player.position);
            dir = (player.transform.position - transform.position).normalized;

        }
        catch (NullReferenceException ex)
        {

        }

    }

    void Update()
    {
       
            Distance_Judgment_();

        if (Monster_Hp < 0)
            Sword_State = EnemyState.Die; 

       

            switch (Sword_State)
            {
                case EnemyState.Stance:
                    Stance();
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

    void Stance()
    {
        if (Distance_Judgment < AttackDistance)
        {
            Sword_State = EnemyState.Attack;

        }
        else  if (Distance_Judgment < FindDistance)
        {
            Sword_State = EnemyState.Walk;
        }
        
    }

    void Walk()
    {

        if(Distance_Judgment < AttackDistance)
        {
            ani.SetBool("Walk", false);
            Sword_State = EnemyState.Attack;

        }

        else if(Distance_Judgment > AttackDistance)
        {
            ani.SetBool("Walk", true);

            if (dir.x < 0)
            {
                
                sr.flipX = false;
                dir.y = 0;
                transform.Translate(dir* Speed * Time.deltaTime);
               
            }
            if (dir.x > 0)
            {
                sr.flipX = true;
                dir.y = 0;
                transform.Translate(dir* Speed * Time.deltaTime);
                
            }
        }
    }


        void Attack()
    
        {

            if (Distance_Judgment < AttackDistance)

                ani.SetBool("Attack", true);

            else if (Distance_Judgment > AttackDistance)
            {
                ani.SetBool("Attack", false);
                Sword_State = EnemyState.Stance;

            }
        }
    
    void Die()
    {
        ani.SetTrigger("Die");
        Thrust_Die();

        Destroy(gameObject, 1f);

    }

    public void Thrust_Die()
    {
        Distance_Judgment_();
        dir.x *= -1;
        dir.y = 0;
        rb.gravityScale = 0.01f;
        
        rb.AddForce(dir * thrust);

    }


    void Distance_Judgment_()
    {
            try
            {
                player = GameObject.FindWithTag("Player").transform;

                Distance_Judgment = Vector2.Distance(transform.position, player.position);
                dir = (player.transform.position - transform.position).normalized;

            }
        catch (NullReferenceException ex)
            {
              

            }
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Villen_Zone") 
        {
            Sword_State = EnemyState.Stance;
        }
        if (collision.gameObject.tag == "Normal_Demage")
        {
            
            Monster_Hp -= 5f * Time.deltaTime;
            Monster_Hp_Bar.value = Monster_Hp;
        }
        if (collision.gameObject.tag == "Critical_Demage" 
            || collision.gameObject.layer == LayerMask.NameToLayer("Field_Trap"))
        {
         
            Monster_Hp -= 5f;
            Monster_Hp_Bar.value = Monster_Hp;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack_Judgment = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack_Judgment = 0;
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Speed = Speed * -1;
        }
    }
  
    public void Attack_Zone_ActiveFalse()
    {
        transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled =true;
    }

    public void Attack_Zone_ActiveTrue()
    {
        transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Sword_Attack()
    {
        if(Attack_Judgment == 1)
            GameManager.Instance.Villen_Demage = Enemy_Attack_Demage_Value;
        else
            GameManager.Instance.Villen_Demage = 0;

        Attack_Judgment = 0;
    }


    public void Pirate_Sword_Attack_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song444_Pirate_Sword_Attack_Sound", 1f);

    }
    public void Pirate_Sword_Die_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song111_Pirate_Sword_Die_Sound", 2f);

    }

}
