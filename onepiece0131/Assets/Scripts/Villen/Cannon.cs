using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    enum EnemyState
    {
        Stance,
        Low_Attack,
        Middle_Attack,
        High_Attack,
        Die
    }

    EnemyState Cannon_State;

    int Low_Scope;
    int Middle_Scope;
    int High_Scope;

    Animator anim;
    public GameObject Cannon_Bullet;

    public Transform Cannon_Low_Pos;
    public Transform Cannon_Middle_Pos;
    public Transform Cannon_High_Pos;

    GameObject player;

    Vector2 dir;
   

    void Start()
    {
        try
        {
            player = GameObject.FindWithTag("Player");
            Vector2 dir = player.transform.position - transform.position;

        }
        catch (NullReferenceException ex)
        {
        }


        Cannon_State = EnemyState.Stance;

        Low_Scope = transform.Find("Cannon_Low_Scope").GetComponent<Scope>().Scope_Value;
        Middle_Scope = transform.Find("Cannon_Middle_Scope").GetComponent<Scope>().Scope_Value;
        High_Scope = transform.Find("Cannon_High_Scope").GetComponent<Scope>().Scope_Value;
        anim = GetComponent<Animator>();

     

       

    }

    void Update()
    {
        try
        {
            player = GameObject.FindWithTag("Player");
            dir = player.transform.position - transform.position;
           
        }
        catch (NullReferenceException ex)
        {
        }
        Low_Scope = transform.Find("Cannon_Low_Scope").GetComponent<Scope>().Scope_Value;
        Middle_Scope = transform.Find("Cannon_Middle_Scope").GetComponent<Scope>().Scope_Value;
        High_Scope = transform.Find("Cannon_High_Scope").GetComponent<Scope>().Scope_Value;
       
            

            switch (Cannon_State)
        {
             


             
            case EnemyState.Stance:
                Stance();
               
                break;
            case EnemyState.Low_Attack:
                Low_Attack();
                break;
            case EnemyState.Middle_Attack:
                Middle_Attack();
                break;
            case EnemyState.High_Attack:
                High_Attack();


                break;
            case EnemyState.Die:
                Die();

                break;
        }


    }
    void Stance()
    {
        anim.SetTrigger("Cannon_Stance");

        int Cannon_Bullet_Count;
        GameObject[] Cannon_Bullet_count = GameObject.FindGameObjectsWithTag("Cannon_Bullet");

        Cannon_Bullet_Count = Cannon_Bullet_count.Length;
      

        if (Cannon_Bullet_Count < 1 && 
            dir.x< -3f)
        {
            if (Low_Scope == 1)
            {

                Cannon_State = EnemyState.Low_Attack;
                Low_Scope = 0;
            }
            else if (Middle_Scope == 1)
            {

                Cannon_State = EnemyState.Middle_Attack;
                Middle_Scope = 0;

            }
            else if (High_Scope == 1)
            {

                Cannon_State = EnemyState.High_Attack;
                High_Scope = 0;

            }
        }
        else
            Cannon_State = EnemyState.Stance;

    }

    void Low_Attack()
    {

        anim.SetTrigger("Cannon_Low_Attack");
        Cannon_State = EnemyState.Stance;
        GameObject Cannon_Bullet_clone = Instantiate(Cannon_Bullet, Cannon_Low_Pos.position, Quaternion.identity);

    }
    void Middle_Attack()
    {

        anim.SetTrigger("Cannon_Middle_Attack");
        Cannon_State = EnemyState.Stance;
        GameObject Cannon_Bullet_clone = Instantiate(Cannon_Bullet, Cannon_Middle_Pos.position, Quaternion.identity);

    }

    void High_Attack()
    {

        anim.SetTrigger("Cannon_High_Attack");
        Cannon_State = EnemyState.Stance;
        GameObject Cannon_Bullet_clone = Instantiate(Cannon_Bullet, Cannon_High_Pos.position, Quaternion.identity);

    }

    void Die()
    {
        anim.SetTrigger("Cannon_Die");
        Cannon_State = EnemyState.Stance;

    }

   
    public void Cannon_Attack_Sound()
    {
        SoundManager.Instance.PlaySFXSound("song215_Cannon_Attack_Sound", 1f);

    }
    
}
