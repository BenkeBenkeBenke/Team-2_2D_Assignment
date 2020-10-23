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
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (enemyAiScript.redShield)
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

        else if (enemyAiScript.blueShield)
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
