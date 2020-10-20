using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private EnemyAI enemyAiScript;
    public float bossHealth;
    public GameObject EnemyToSpawn;
    public Transform EnemySpawn;
    public Transform EnemySpawn2;
    public GameObject SpawnEffect;
    public float spawnTimer;
    public float healTimer;
    public float specialAttackTimer;
    public float tauntTimer;
    public float shieldTimer;
    public float healAmount;

    private bool redShield;
    private bool blueShield;
    private bool setBossHealth = true;

    private bool cooling;
    private float intTimer;


    private bool coolingHeal;
    private float intHealTimer;

    private bool coolingSpeical;
    private float intSpecialTimer;

    private bool coolingShield;
    private float intShieldTimer;

    private bool coolingTaunt;
    private float intTauntTimer;

    void Awake()
    {
        intTimer = spawnTimer;

        intHealTimer = healTimer;
        intSpecialTimer = specialAttackTimer;
        intShieldTimer = shieldTimer;
        intTauntTimer = tauntTimer;
        
        enemyAiScript = GetComponentInParent<EnemyAI>();
        redShield = enemyAiScript.redShield;
        blueShield = enemyAiScript.blueShield;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyAiScript.Boss)
        {
            
            if (setBossHealth)
            {
                enemyAiScript.health = bossHealth;
                setBossHealth = false;
            }
            

            BossLogic();
        }
        
    }

    void BossLogic()
    {
        if(enemyAiScript.health <= 50f && coolingHeal == false)
        {
            Heal();
        }

        else if(bossHealth <= 50f && coolingSpeical == false)
        {
            SuperAttack();
        }

        if(enemyAiScript.health <= 90 && coolingShield == false)
        {
            SwitchShields();
        }

        if(bossHealth <= 70f && cooling == false)
        {
            SpawnEnemies();
        }

        if(bossHealth <= 90 && coolingTaunt == false)
        {
            Taunt();
        }

        if (cooling)
        {
            CooldownSpawn();
            
        }

        if (coolingHeal)
        {
            CooldownHeal();
        }

        if (coolingShield)
        {
            CooldownShield();
        }
        if (coolingSpeical)
        {
            CooldownSpecialAttack();
        }

        if (coolingTaunt)
        {
            CooldownTaunt();
        }




    }


    public void SpawnEnemies()
    {
        spawnTimer = intTimer;

        GameObject newEnemy = Instantiate(EnemyToSpawn, EnemySpawn.position, Quaternion.identity);
        GameObject spawnEffect = Instantiate(SpawnEffect, EnemySpawn.position, Quaternion.identity);

        TriggerCooling();

    }

    public void SuperAttack()
    {
        specialAttackTimer = intSpecialTimer;

        TriggerSpecial();

    }

    public void Heal()
    {
        healTimer = intHealTimer;
        enemyAiScript.EnemyHeal(healAmount);
        TriggerHeal();
    }

    public void SwitchShields()
    {
        shieldTimer = intShieldTimer;

        if (enemyAiScript.blueShield)
        {
            enemyAiScript.blueShield = false;
            enemyAiScript.redShield = true;
        }

        else if (enemyAiScript.redShield)
        {
            enemyAiScript.redShield = false;
            enemyAiScript.blueShield = true;
        }

        TriggerShield();

    }

    public void Taunt()
    {
        tauntTimer = intTauntTimer;


        TriggerTaunt();

    }


    void CooldownSpawn()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && cooling && enemyAiScript.attackMode)
        {
            cooling = false;
            spawnTimer = intTimer;
        }
    }

    void CooldownHeal()
    {
        healTimer -= Time.deltaTime;
        if (healTimer <= 0 && coolingHeal && enemyAiScript.attackMode)
        {
            coolingHeal = false;
            healTimer = intHealTimer;
        }
    }

    void CooldownSpecialAttack()
    {
        specialAttackTimer -= Time.deltaTime;
        if (specialAttackTimer <= 0 && coolingSpeical && enemyAiScript.attackMode)
        {
            coolingSpeical = false;
            specialAttackTimer = intSpecialTimer;
        }
    }

    void CooldownTaunt()
    {
        tauntTimer -= Time.deltaTime;
        if (tauntTimer <= 0 && coolingTaunt && enemyAiScript.attackMode)
        {
            coolingTaunt = false;
            tauntTimer = intTauntTimer;
        }
    }

    void CooldownShield()
    {
        shieldTimer -= Time.deltaTime;
        if (shieldTimer <= 0 && coolingShield && enemyAiScript.attackMode)
        {
            coolingShield = false;
            shieldTimer = intShieldTimer;
        }
    }



    public void TriggerCooling()
    {
        cooling = true;
    }

    public void TriggerHeal()
    {
        coolingHeal = true;
    }

    public void TriggerSpecial()
    {
        coolingSpeical = true;
    }

    public void TriggerTaunt()
    {
        coolingTaunt = true;
    }

    public void TriggerShield()
    {
        coolingShield = true;
    }


}
