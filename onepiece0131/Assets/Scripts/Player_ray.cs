using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_ray : MonoBehaviour
{
    public GameObject Attack1;
    public GameObject Attack4;
    public GameObject Attack5;
    public GameObject Attack10;
    public GameObject Attack11;
    public GameObject Attack12;


    public GameObject Vazooka;
    float Attack_Gauge_Value = 0;

    public Slider Attack_Gauge;
    public Canvas Attack_Gauge_Canvas;
    Canvas attack_guage_canvas;
    public GameObject Gauge_Pos;

    public float moveSpeed = 5.0f;
    public float JumpSpeed = 0;
    public int Jump_Status = 0;

    public bool attack1 = true;
    public bool attack11 = true;

    public bool attack4 = false;
    public bool attack5 = false;
    public bool vazooka = false;
    public float Hp_Value;

    public float gValue_11 = 0.0f;
    public float gValue_12 = 0.0f;

    Animator ani;

    AudioSource ad;
    Rigidbody2D rig2d;
    PolygonCollider2D Attack1_Poly2d;
    PolygonCollider2D Attack4_Poly2d;
    PolygonCollider2D Attack5_Poly2d;
    PolygonCollider2D Attack10_Poly2d;
    PolygonCollider2D Attack11_Poly2d;
    PolygonCollider2D Attack12_Poly2d;

    SpriteRenderer sr;

    public GameObject Skill_Menu;
    public GameObject Menu_Continue;
    public GameObject Die_Menu;

    public Image Player_Hp_Bar_Image;

    Vector2 dir;
    public float Critical_Demage_Thrust = 300f;

    bool Move_Possible = true;
    bool Attack_Possible = true;

    bool Skill_Menu_State = false;
    bool Menu_Continue_State = false;
    bool Die_Menu_State = false;


    bool Nuckback_Judgement = false;

    float Nuckback_Thrust = 2f;

    GameObject Critical_Monster_Attack_Object;
    
    public bool Basic_Punch_Value = true;
    public bool Basic_Kick_Value = true;
    public bool Gomu_Raple_Value = false;
    public bool Gomu_Bazooka_Value = false;
    public bool Gomu_Gatling_Value = false;
    public bool Gomu_Spear_Value = false;
    public bool Gomu_Ax_Value = false;
    public bool Gomu_Balloon_Value = false;

    public bool Gomu_Balloon_Possible = false;

    void Start()
    {
        ani = GetComponent<Animator>();

        ad = GetComponent<AudioSource>();

        rig2d = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        Critical_Monster_Attack_Object = null;

        Attack1_Poly2d = Attack1.GetComponent<PolygonCollider2D>();
        Attack4_Poly2d = Attack4.GetComponent<PolygonCollider2D>();
        Attack5_Poly2d = Attack5.GetComponent<PolygonCollider2D>();
        Attack10_Poly2d = Attack10.GetComponent<PolygonCollider2D>();
        Attack11_Poly2d = Attack11.GetComponent<PolygonCollider2D>();
        Attack12_Poly2d = Attack12.GetComponent<PolygonCollider2D>();

    }

    void Update()
    {
        Inventory_Active();
        Player_Hp_Bar();
        Player_Menu_Continue();
        Player_Skill_Status();
        Player_Skill_Menu();
        Player_Die();
        if (Move_Possible == true)
            Player_Move();

        if (Attack_Possible == true)
            Player_Attack();
    }

    public void Jump_Cancel()
    {

        Debug.DrawRay(rig2d.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rig2d.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if (rig2d.velocity.y < 0)
        {
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 5.7f)
                {
                    ani.SetBool("jump", false);
                    Jump_Status = 0;
                }
            }
        }

    }

    public void Player_Skill_Status()
    {

        Basic_Punch_Value = GameManager.Instance.Basic_Punch_Value;
        Basic_Kick_Value = GameManager.Instance.Basic_Kick_Value;
        Gomu_Raple_Value = GameManager.Instance.Gomu_Raple_Value;
        Gomu_Bazooka_Value = GameManager.Instance.Gomu_Bazooka_Value;
        Gomu_Gatling_Value = GameManager.Instance.Gomu_Gatling_Value;
        Gomu_Spear_Value = GameManager.Instance.Gomu_Spear_Value;
        Gomu_Ax_Value = GameManager.Instance.Gomu_Ax_Value;
        Gomu_Balloon_Value = GameManager.Instance.Gomu_Balloon_Value;

    }




    public void Player_Hp_Bar()
    {
        Hp_Value = GameManager.Instance.Player_Hp;
        Player_Hp_Bar_Image.fillAmount = Hp_Value;
    }

    public void Player_Die()
    {
        if (Hp_Value <= 0)
        {
            ani.SetTrigger("Player_Die");
            Die_Menu.SetActive(true);
            Die_Menu_State = true;
            Time.timeScale = 0.0f;
        }
        else if(Hp_Value > 0)
        {
            Time.timeScale = 1.0f;

        }

    }


    public void Player_Skill_Menu()
    {
        if (Input.GetKeyDown(KeyCode.K) && Skill_Menu_State == false)
        {
            Skill_Menu.SetActive(true);
            Skill_Menu_State = true;
        }

        else if (Input.GetKeyDown(KeyCode.K) && Skill_Menu_State == true)
        {
            Skill_Menu.SetActive(false);
            Skill_Menu_State = false;
        }
    }
    public void Player_Menu_Continue()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Menu_Continue_State == false)
        {
            Menu_Continue.SetActive(true);
            Menu_Continue_State = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && Menu_Continue_State == true)
        {
            Menu_Continue.SetActive(false);
            Menu_Continue_State = false;
        }
    }

    public void Player_Move()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.PlaySFXSound("song108_Jump_Sound", 0.5f);

            Jump_Status = 1;
        }

        if (Jump_Status == 1)
        {
            ani.SetBool("Jump", true);
            if (JumpSpeed < 6f)
                JumpSpeed += 0.1f;

            moveY = JumpSpeed * Time.deltaTime;
            rig2d.gravityScale = 0;

            if (Jump_Status == 1 && JumpSpeed >= 6f)
            {
                Jump_Status = 0;
                rig2d.gravityScale = 1;
                JumpSpeed = 0;

            }
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            Attack_Possible = false;

            if (Input.GetAxis("Horizontal") >= 0.1f && Input.GetKey(KeyCode.RightArrow))
            {
                ani.SetBool("Right", true);
                sr.flipX = false;

            }
            else
            {

                ani.SetBool("Right", false);
            }


            if (Input.GetAxis("Horizontal") <= -0.1f && Input.GetKey(KeyCode.LeftArrow))
            {

                ani.SetBool("Left", true);
                sr.flipX = true;
            }
            else
            {

                ani.SetBool("Left", false);
            }

        }
        else if (Input.GetAxis("Horizontal") == 0 && Jump_Status == 0)
        {
            Attack_Possible = true;
        }


        Vector2 vec = new Vector2(moveX, moveY);
        transform.Translate(vec);
    
}

    public void Player_Attack()
    {
        if ((Input.GetKeyDown(KeyCode.Z) && Basic_Punch_Value == true) && attack1 == true)
        {
            ani.SetBool("Attack1", true);
            Attack1_Poly2d.isTrigger = false;
            attack1 = false;
            attack11 = true;

            rig2d.bodyType = RigidbodyType2D.Static;
            GameObject go = Instantiate(Attack1, transform.position, Quaternion.identity);
            Move_Possible = false;

        }

        if ((Input.GetKeyUp(KeyCode.Z) && Basic_Punch_Value == true) && attack1 == false)
        {
            ani.SetBool("Attack1", false);
           
            attack1 = true;
            Attack1_Poly2d.isTrigger = true;
            rig2d.bodyType = RigidbodyType2D.Dynamic;
            Move_Possible = true;
            gValue_11 = 0;
        }
      

        else if (Input.GetKey(KeyCode.Z) && Gomu_Gatling_Value == true && attack11 == true)
        {
            gValue_11 += 1f*Time.deltaTime;

            if (gValue_11 >= 1 && Gomu_Gatling_Value == true)
            {
                Attack11_Poly2d.isTrigger = false;
                ani.SetBool("Attack11", true);
                StartCoroutine("ReStart");
                gValue_11 = 0;
                ani.SetBool("Attack1", false);
                attack11 = false;

            }
        }
            


        if (Input.GetKey(KeyCode.X) && Basic_Kick_Value == true )
        {
            ani.SetBool("Kick", true);
        }
        else if (Input.GetKeyUp(KeyCode.X) && Basic_Kick_Value == true)
        {
            ani.SetBool("Kick", false);
        }

        if (Input.GetKeyDown(KeyCode.X) && JumpSpeed >= 1.0f && Gomu_Spear_Value == true && Input.GetKey(KeyCode.DownArrow))
        {
            ani.SetBool("Attack10", true);
            Attack10_Poly2d.isTrigger = false;
        }
        else
        {
            ani.SetBool("Attack10", false);
            Attack10_Poly2d.isTrigger = true;
        }

        if (Input.GetKeyDown(KeyCode.X) && Gomu_Ax_Value == true && Input.GetKey(KeyCode.UpArrow))
        {
            ani.SetBool("Attack5", true);
            attack5 = true;
            rig2d.bodyType = RigidbodyType2D.Static;
            GameObject go = Instantiate(Attack5, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyUp(KeyCode.X) )
        {
            ani.SetBool("Attack5", false);
            int Normal_Demage_Count;
            GameObject[] Normal_Demage_count = GameObject.FindGameObjectsWithTag("Attack");

            Normal_Demage_Count = Normal_Demage_count.Length;
            if(Normal_Demage_Count < 1)
                attack5 = false;
            rig2d.bodyType = RigidbodyType2D.Dynamic;
        }



        if (Input.GetKeyDown(KeyCode.C) && gValue_12 == 0 && Gomu_Raple_Value == true)
        {
            ani.SetBool("Attack4", true);
            gValue_12 += 0.001f;
            StartCoroutine("ReStart");
            attack4 = true;
            rig2d.bodyType = RigidbodyType2D.Static;
        }
        else if (Input.GetKey(KeyCode.C) && gValue_12 > 0 && Gomu_Raple_Value == true)
        {
            gValue_12 += 0.001f;
            if (gValue_12 >= 1f)
            {
                ani.SetBool("Attack12", true);
                StartCoroutine("ReStart");
            }
        }
        else
        {
            ani.SetBool("Attack4", false);
            gValue_12 = 0;
            attack4 = false;
            rig2d.bodyType = RigidbodyType2D.Dynamic;
        }


        if (Input.GetKey(KeyCode.LeftControl) && Gomu_Bazooka_Value == true) 
        {
            Move_Possible = false;
            Attack_Gauge.gameObject.SetActive(true);
            ani.SetBool("Vazooka_Ready", true);
            Attack_Gauge.value += 0.01f;

            if (Attack_Gauge.value >= 1f)
            {
                Attack_Gauge.value = 1f;
            }
        }
        else
        {
            ani.SetBool("Vazooka_Ready", false);

            if (Attack_Gauge.value < 1)
            {
                Attack_Gauge.value -= 0.02f;
                if (Attack_Gauge.value <= 0)
                {
                    Attack_Gauge.value = 0;
                    Attack_Gauge.gameObject.SetActive(false);
                    Move_Possible = true;

                }
            }

        }



        if (Input.GetKeyUp(KeyCode.LeftControl) && (Attack_Gauge.value >= 1) && Gomu_Bazooka_Value == true)
        {
            Move_Possible = false;

            Debug.Log(Attack_Gauge.value);

            ani.SetBool("Vazooka_Play", true);
            GameObject go = Instantiate(Vazooka, transform.position, Quaternion.identity);
            vazooka = true;
            Attack_Gauge.value -= 0.02f;


        }
        else if (Attack_Gauge.value <= 0 && Gomu_Bazooka_Value == true)
        {
            ani.SetBool("Vazooka_Play", false);
            vazooka = false;

        }
        if (Input.GetKey(KeyCode.LeftAlt) && Gomu_Balloon_Value == true)
        {
            Move_Possible = false;
            ani.SetBool("Balloon_Start", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftAlt) && Gomu_Balloon_Value == true)
        {

            ani.SetBool("Balloon_Start", false);
            ani.SetBool("Balloon_End", false);

            Move_Possible = true;


        }




    }


    IEnumerator ReStart()
    {
        yield return new WaitForSeconds(0.5f);
        if (gValue_11 >= 1f)
        {
            gValue_11 = 0;
            ani.SetBool("Attack11", false);
            Attack11_Poly2d.isTrigger = true;

        }
        if (gValue_12 >= 1f)
        {
            gValue_12 = 0;
            ani.SetBool("Attack12", false);
        }
        if (Jump_Status == 0)
        {
            ani.SetBool("Attack11", false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            ani.SetBool("Jump", false);
            Jump_Status = 0;
            rig2d.gravityScale = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster_Attack_Critical")
            || collision.gameObject.layer == LayerMask.NameToLayer("Field_Trap"))
        {
            ani.SetBool("Right",false);
            ani.SetBool("Left",false);
            ani.SetBool("Jump", false);
            Jump_Status = 0;
            JumpSpeed = 0;
            ani.SetTrigger("Down");
            SoundManager.Instance.PlaySFXSound("song615_Player_Down_Sound(2)", 1f);
            StartCoroutine(Demage_Delay());
            Critical_Monster_Attack_Object = collision.gameObject;
            rig2d.gravityScale = 1;

        }
    }

    IEnumerator Demage_Delay()
    {
        Nuckback_Judgement = true;
        Attack_Possible = false;
        Move_Possible = false;
        yield return new WaitForSeconds(2f);
        Attack_Possible = true;
        Move_Possible = true;
        Nuckback_Judgement = false;
    }

    public void Inventory_Active()
    {
        if(GameObject.FindWithTag("GameManager").transform.GetChild(1).gameObject.activeSelf == true
            || GameObject.FindWithTag("GameManager").transform.GetChild(2).gameObject.activeSelf == true)
        {
            gameObject.GetComponent<Inventory>().enabled = true;

        }

        else if (GameObject.FindWithTag("GameManager").transform.GetChild(1).gameObject.activeSelf == false
           || GameObject.FindWithTag("GameManager").transform.GetChild(2).gameObject.activeSelf == false)
        {
            gameObject.GetComponent<Inventory>().enabled = false;
        }
    }

}

