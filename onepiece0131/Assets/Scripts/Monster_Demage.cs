using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Demage : MonoBehaviour
{

   //public float Monster_Attack_Demage_Value;

    void Start()
    {
       // Monster_Attack_Demage_Value;
    }

    void Update()
    {
        //player_damage();

       //if(Monster_Attack_Demage_Value > 0)
       //Debug.Log("Monster_Demage ��ũ��Ʈ ���� Monster_Attack_Demage_Value ���� : " + Monster_Attack_Demage_Value);



    }


    //public void Monster_Attack_Damage(float Monster_Attack_Demage_Value)
    //{
    //    if (Monster_Attack_demage > 0)
    //    {
    //        Debug.Log("Villen_Demage : " + Monster_Attack_demage);
    //        //Debug.Log("�÷��̾� ü�� : " + Player_Hp);
    //        Monster_Attack_demage = 0;

    //    }
    //    //Villen = GameObject.FindWithTag("Enemy"); //Villen.GetComponent<Villen2>().Player_Demage;
    //    //Villen_Demage = Villen.GetComponent<Villen2>().Player_Demage;
    //    Monster_Attack_demage = ((Monster_Attack_Demage_Value) / 100) * Time.deltaTime;
    //    //Player_Hp = Player_Hp / 100;
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           //Monster_Attack_Demage_Value =0.5f;
            //Debug.Log("Monster_Demage ��ũ��Ʈ ���� Monster_Attack_Demage_Value ���� : " + Monster_Attack_Demage_Value);
           // Destroy(gameObject);
        }
        else
        {
          //  Monster_Attack_Demage_Value = 0.0f;

        }
    }

}
