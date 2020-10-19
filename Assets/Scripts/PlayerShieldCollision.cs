using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldCollision : MonoBehaviour
{

    public bool redShield;
    public float onCollisionAdd = 10f;
    
    private PlayerAttackResource _attackResource;

    private void Start()
    {
        _attackResource = gameObject.GetComponentInParent<PlayerAttackResource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Shield COllision");
        if (other.gameObject.tag == gameObject.tag)
        {
            if (redShield == true)
            {
                _attackResource.AddRedResource(onCollisionAdd);
            }

            if (redShield == false)
            {
                _attackResource.AddBlueResource(onCollisionAdd);
            }
            Destroy(other.gameObject);
        }
    }
}
