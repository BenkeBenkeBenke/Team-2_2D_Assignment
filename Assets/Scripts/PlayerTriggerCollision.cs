using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour
{
    public bool isOnStairs;

    public Collider2D _thisStairCollider;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        //_playerHealth = gameObject.GetComponent<PlayerHealth>();
        _playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "StairTriggerArea" || other.gameObject.tag == "StairTriggerTop")
        {
            _thisStairCollider = other.transform.parent.Find("StairCollider").GetComponent<Collider2D>();
            
            if (other.gameObject.tag == "StairTriggerArea")
            {
                isOnStairs = true;
            }

            if (other.gameObject.tag == "StairTriggerTop")
            {
                _thisStairCollider.enabled = true;
                isOnStairs = true;
            }
        }
        
        if (other.gameObject.tag == "Red" || other.gameObject.tag == "Blue")
        {
            _playerHealth.TakeDamage(1);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "StairTriggerArea")
        {
            Debug.Log("Exit Stair");
            isOnStairs = false;
            _thisStairCollider.enabled = false;
        }
    }

    public void UseStair(bool StairActive)
    {
        if (isOnStairs == true)
        {
            _thisStairCollider.enabled = StairActive;    
        }
    }
}
