using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyAI enemyAiScript;
    private PlayerProjectiles projectileScript;
    private bool redShield;
    private bool blueShield;
    void Awake()
    {
        enemyAiScript = GetComponentInParent<EnemyAI>();
        redShield = enemyAiScript.redShield;
        blueShield = enemyAiScript.blueShield;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (redShield)
        {
            if (col.gameObject.CompareTag("Red"))
            {

            }
            else if (col.gameObject.CompareTag("Blue"))
            {
                projectileScript = col.gameObject.GetComponent<PlayerProjectiles>();
                enemyAiScript.EnemyTakeDamage(projectileScript.damage);
            }
        }

        else if (blueShield)
        {
            if (col.gameObject.CompareTag("Blue"))
            {

            }

            else if (col.gameObject.CompareTag("Red"))
            {
                projectileScript = col.gameObject.GetComponent<PlayerProjectiles>();
                enemyAiScript.EnemyTakeDamage(projectileScript.damage);
            }

        }
        
    }
}
