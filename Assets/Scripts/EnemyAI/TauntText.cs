using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TauntText : MonoBehaviour
{
    public Vector3 Offset;
    public Text text;
    private EnemyAI enemyAiScript;
    void Awake()
    {
        enemyAiScript = GetComponentInParent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.gameObject.SetActive(enemyAiScript.Hitpoints > enemyAiScript.health  );
        text.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);


        
    }
}
