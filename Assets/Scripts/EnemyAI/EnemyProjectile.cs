using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float dieTime, damage;
    public GameObject diePerfect;
    public bool redMissile;
    public bool blueMissile;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (redMissile)
        {
            if (col.gameObject.CompareTag("Blue"))
            {
                col.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (blueMissile)
        {
            if (col.gameObject.CompareTag("Red"))
            {
                col.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(damage);

                Destroy(gameObject);
            }
        }
        
        Destroy(gameObject);
        */
       
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);

        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
