﻿using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour
{

    private Animator m_animator;
    public Rigidbody2D banditBody;
    private Sensor_Bandit m_groundSensor;
    private bool m_combatIdle = false;
    private bool m_isDead = false;

    public Vector2 playerPosition;
    Vector2 velocity;
    Vector2 input = new Vector2();
    public float movementSpeed = 1;
    float attackTime = .6f;
    public bool canMove;
    public bool canAttack;
    

    // Use this for initialization
    void Start()
    {
        MapGenerator map = GameObject.Find("MapGenerator").GetComponent<MapGenerator>();
        m_animator = GetComponent<Animator>();        
        playerPosition = map.randomStartingLocation;
        transform.position = playerPosition;
        canMove = true;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        MapGenerator map = GameObject.Find("MapGenerator").GetComponent<MapGenerator>();
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetMouseButtonDown(0))
        {
            canMove = false;
        }

        if (canMove)
        {
            // -- Handle input and movement --
            
            Vector2 direction = input.normalized;
            velocity = direction * movementSpeed;

            // Swap direction of sprite depending on walk direction
            if (input.x > 0)
                transform.localScale = new Vector3(-0.8f, 0.8f, 1.0f);
            else if (input.x < 0)
                transform.localScale = new Vector3(0.8f, 0.8f, 1.0f);

            // Move
            banditBody.velocity = new Vector2(velocity.x, velocity.y);
        }




            // -- Handle Animations --

            /*
            //Death
            if (Input.GetKeyDown("e")) {
                if(!m_isDead)
                    m_animator.SetTrigger("Death");
                else
                    m_animator.SetTrigger("Recover");

                m_isDead = !m_isDead;
            }

            //Hurt
            else if (Input.GetKeyDown("q"))
                m_animator.SetTrigger("Hurt");
            */

            //Attack
        
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
            banditBody.velocity = new Vector2(0, 0);
        }

            /*
            //Change between idle and combat idle
            else if (Input.GetKeyDown("f"))
                m_combatIdle = !m_combatIdle;

            //Jump
            else if (Input.GetKeyDown("space") && m_grounded) {
                m_animator.SetTrigger("Jump");
                m_grounded = false;
                m_animator.SetBool("Grounded", m_grounded);
                m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
                m_groundSensor.Disable(0.2f);
            }
            */

            //Run
            else if ((Mathf.Abs(input.x) > Mathf.Epsilon || Mathf.Abs(input.y) > Mathf.Epsilon) && canMove == true)
                m_animator.SetInteger("AnimState", 2);

            //Combat Idle
            else if (m_combatIdle)
                m_animator.SetInteger("AnimState", 1);

            //Idle
            else
                m_animator.SetInteger("AnimState", 0);
        
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Exit")
        {
            enabled = false;
            MapGenerator map = GameObject.Find("MapGenerator").GetComponent<MapGenerator>();
           
            map.GenerateNewMap();
            
            


        }
    }

    IEnumerator Attack()
    {
        canMove = false;
        m_animator.SetTrigger("Attack");
        canAttack = false;

        yield return new WaitForSeconds(attackTime);
        canAttack = true;
        canMove = true;

    }
}
