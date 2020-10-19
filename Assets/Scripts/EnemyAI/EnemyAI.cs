﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region Public Variables
    public bool RangedAI;

    public float health;
    public bool blueShield;
    public bool redShield;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    public Transform target;
    public bool inRange;
    public Transform MissileSpawn;
    public GameObject Missile;
    public float MissleSpeed;

    public Transform leftLimit;
    public Transform rightLimit;

    public GameObject hotZone;
    public GameObject triggerArea;

    #endregion

    #region Private Variables

    private Animator anim;
    private float distance;
    private bool attackMode;
    
    private bool cooling;
    private float intTimer;
    #endregion

    
    void Awake()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!attackMode)
        {
            Move();
        }
        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            SelectTarget();
        }

    

        if(inRange)
        {

            AILogic();
        }
    }

    void AILogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance > attackDistance)
        {
            
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPostion = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);

        if (RangedAI)
        {
            GameObject newMissile = Instantiate(Missile, MissileSpawn.position, Quaternion.identity);

            newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(MissleSpeed * moveSpeed * Time.fixedDeltaTime, 0f);
        }

        TriggerCooling();

    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

 
    void Cooldown()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    public void EnemyTakeDamage(float damage)
    {
       
            health = health - damage;
            if (health <= 0)
            {
                Die();
            }
        
    }

    public void  Die()
    {
        Destroy(gameObject);
    }
}
