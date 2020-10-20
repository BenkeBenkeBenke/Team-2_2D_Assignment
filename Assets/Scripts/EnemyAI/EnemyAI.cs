using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    #region Public Variables
    public bool RangedAI;
    public bool Boss;
    public bool StaticAI;
    public bool Civilian;
    public bool Bomber;

    public float health;
    public float Hitpoints;
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
    public EnemyHealthbar Healthbar;
    public GameObject deathFireAnimation;
    public GameObject redShieldArt;
    public GameObject blueShieldArt;

    #endregion

    #region Private Variables

    private Animator anim;
    private float distance;
    public bool attackMode;
    
    private bool cooling;
    private float intTimer;
    private Transform Player;
    #endregion

    
    void Awake()
    {
        Hitpoints = health;
        SelectTarget();
        intTimer = timer;
        anim = this.gameObject.transform.GetChild(1).GetComponent<Animator>();
        Healthbar.SetHealth(Hitpoints, health);
        Player = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.SetHealth(Hitpoints, health);

        if (!attackMode && !StaticAI)
        {
            Move();
        }

        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            SelectTarget();
        }

        if(inRange)
        {

            AILogic();
        }

        if (blueShield)
        {
            blueShieldArt.SetActive(true);
            redShieldArt.SetActive(false);
        }

        if (redShield)
        {
            redShieldArt.SetActive(true);
            blueShieldArt.SetActive(false);
        }
    }

    void AILogic()
    {
        distance = Vector2.Distance(transform.position, Player.position);

        if(distance > attackDistance)
        {
            StopAttack();
            anim.SetBool("Walk", true);
        }
        else if(attackDistance >= distance && cooling == false && Civilian == false && Bomber == false)
        {
            Attack();
        }

        else if(0.3 >= distance && Civilian == false && Bomber == true)
        {
            Die();
            Bomber = false;
        }

        if (cooling)
        {
            Cooldown();
        }
    }

    void Move()
    {
        anim.SetBool("Walk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            Vector2 targetPostion = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("Attack1", true);
        anim.SetBool("Walk", false);

        if (RangedAI)
        {

            GameObject newMissile = Instantiate(Missile, MissileSpawn.position, Quaternion.identity);

            newMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(MissleSpeed * moveSpeed * Time.fixedDeltaTime, 0f);
        }


        TriggerCooling();

    }

    public void StopAttack()
    {
        cooling = false;
        attackMode = false;
        inRange = false;
        anim.SetBool("Attack1", false);
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
        anim.SetBool("TakeHit", true);

        health = health - damage;
            Healthbar.SetHealth(Hitpoints, health);
        if (health <= 0)
            {
                Die();
            }
        
    }

    public void EnemyHeal(float healamount)
    {
        if (!Boss)
        {
            health = health + healamount;
            if (health >= 100)
            {
                
                    health = 100;
                
            }
        }
        else if (Boss)
        {
            health = health + healamount;
         
        }
      
    }

    public void  Die()
    {
        GameObject fireAnim = Instantiate(deathFireAnimation, transform.position, Quaternion.identity);
        anim.SetBool("Dead", true);
        Destroy(gameObject);
    }
}
