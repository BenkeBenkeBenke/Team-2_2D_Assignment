using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10;

    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Die();    
        }
    }

    public void Die()
    {
        Debug.Log("YOU ARE NOW DEAD!!");
        gameObject.GetComponent<PlayerRespawn>().RespawnPlayer();
    }
}
