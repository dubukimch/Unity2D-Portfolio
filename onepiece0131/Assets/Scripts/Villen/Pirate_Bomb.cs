using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pirate_Bomb : MonoBehaviour
{
    enum EnemyState 
    {
        Stance,
        Attack,
        Die
    }
    EnemyState Pirate_Bomb_State;
    SpriteRenderer sr;
    public GameObject Bomb;
    float Bomb_Throw_Power= 15f;
    int Bomb_Scope;
    public Slider Monster_Hp_Bar;
    public float Monster_Hp = 1f;
    public float Enemy_Attack_Demage_Value = 1f;
    Transform player;
    Vector2 dir;
    Quaternion rot;
    Rigidbody2D rg;
    Animator ani;
    CapsuleCollider2D cap;

    void Start()
    {
        intialize();

        cap = GetComponent<CapsuleCollider2D>();

        sr = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
        rg.gravityScale = 0;

        ani = GetComponent<Animator>();
       
        if(player != null)
            Pirate_Bomb_State = EnemyState.Stance;
         

       
    }
    void Update()
    {
        intialize();

        if (Monster_Hp < 0 || transform.position.y < 5f)
            Pirate_Bomb_State = EnemyState.Die;

        switch (Pirate_Bomb_State)
        {
            case EnemyState.Stance:
                Stance();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
    }
    void intialize()
    {

        try
        {
            player = GameObject.FindWithTag("Player").transform;
            dir = player.transform.position - transform.position;
        }
        catch (NullReferenceException ex)
        {

        }

    }
    void Stance()
    {
        ani.SetTrigger("Bomb_Stance");

        try
        {
            if (Vector2.Distance(player.transform.position, transform.position) >= 3f && dir.x < 0 && sr.flipX == false)
            {
                Pirate_Bomb_State = EnemyState.Attack;
            }
            else if (Vector2.Distance(player.transform.position, transform.position) >= 3f && dir.x > 0 && sr.flipX == true)
            {
                Pirate_Bomb_State = EnemyState.Attack;

            }
        }
        catch(NullReferenceException ex)
        {

        }
    }
    void Attack()
    {
        int Cannon_Bullet_Count;
        GameObject[] Cannon_Bullet_count = GameObject.FindGameObjectsWithTag("Bomb");

        Cannon_Bullet_Count = Cannon_Bullet_count.Length;

            if (Cannon_Bullet_Count < 1)
            {
                ani.SetTrigger("Bomb_Attack");
                GameObject Bomb_clone = Instantiate(Bomb, transform.position, rot);
                Pirate_Bomb_State = EnemyState.Stance;
                transform.Translate(Vector2.down* 3f * Time.deltaTime);

        }

        else
            {
                Pirate_Bomb_State = EnemyState.Stance;

            }
        
    }
    void Die()
    {
        ani.SetTrigger("Bomb_Die");
        rg.gravityScale = 1;
        cap.isTrigger = false;
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        }
    }

    public void Pirate_Bomb_Attack_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song315_Pirate_Bomb_Attack_Sound", 1f);

    }
   

    public void Pirate_Bomb_Die_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song206_Pirate_Bomb_Die_Sound", 1f);

    }
}
