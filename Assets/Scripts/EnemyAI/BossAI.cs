using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private EnemyAI enemyAiScript;
    public float bossHealth;
    public GameObject EnemyToSpawn;
    public Transform EnemySpawn;
    public GameObject SpawnEffect;
    public float spawnTimer;
    public float specialAttackTimer;

    private bool redShield;
    private bool blueShield;

    private bool cooling;
    private float intTimer;

    void Awake()
    {
        intTimer = spawnTimer;

        enemyAiScript = GetComponentInParent<EnemyAI>();
        redShield = enemyAiScript.redShield;
        blueShield = enemyAiScript.blueShield;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyAiScript.Boss)
        {
            enemyAiScript.health = bossHealth;

            BossLogic();
        }
        
    }

    void BossLogic()
    {
        if(bossHealth <= 50f)
        {
            Heal();
        }

        else if(bossHealth <= 50f)
        {
            SuperAttack();
        }

        if(bossHealth <= 90)
        {
            SwitchShields();
        }

        if (cooling)
        {
            Cooldown();
            
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

    }

    public void Heal()
    {

    }

    public void SwitchShields()
    {

    }


    void Cooldown()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && cooling && enemyAiScript.attackMode)
        {
            cooling = false;
            spawnTimer = intTimer;
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
