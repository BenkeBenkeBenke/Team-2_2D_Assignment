using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    private EnemyAI enemyAiscript;

    public bool inRange;
    private void Awake()
    {
        enemyAiscript = GetComponentInParent<EnemyAI>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag ("Player"))
        {
            gameObject.SetActive(false);
            enemyAiscript.target = col.transform;
            enemyAiscript.inRange = true;
            enemyAiscript.hotZone.SetActive(true);
            inRange = true;
        }
    }

    public void Hej()
    {

    }
}
