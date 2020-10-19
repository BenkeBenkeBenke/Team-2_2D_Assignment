using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private EnemyAI enemyAiScript;
    private bool inRange;
    private Animator anim;


    
    
    
    
    void Awake()
    {
        enemyAiScript = GetComponentInParent<EnemyAI>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack"))
        {
            enemyAiScript.Flip();
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyAiScript.triggerArea.SetActive(true);
            enemyAiScript.inRange = false;
            enemyAiScript.SelectTarget();
        }
    }
}
