using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldColor : MonoBehaviour
{
    private EnemyAI _enemyAI;
    private ParticleSystem _particleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemyAI = transform.GetComponentInParent<EnemyAI>();
        _particleSystem = GetComponent<ParticleSystem>();
        
        var main = _particleSystem.main;

        if (_enemyAI.redShield)
        {
            main.startColor = new Color(255, 0, 0, 1);
        }

        if (_enemyAI.blueShield)
        {
            main.startColor = new Color(0, 0, 255, 1);
        }

        if (!_enemyAI.redShield && !_enemyAI.blueShield)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
