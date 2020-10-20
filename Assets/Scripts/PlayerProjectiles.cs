using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerProjectiles : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifespan = 2.0f;
    public float damage = 10f;

    [NonSerialized] public Vector2 initialSpeed;
    
    private GameObject _aim;
    private Vector2 direction;
    private Rigidbody2D _body;
    //private GameObject _player;
    //private GameObject _player;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _aim = GameObject.Find("PlayerAimSprite");
        //_player = GameObject.Find("Player");
    }

    public void SetInitialSpeed(Vector2 playerSpeed)
    {
        initialSpeed = playerSpeed;
    }
    public void Start()
    {
        direction = _aim.transform.position - transform.position;
        _body.velocity = direction * speed + initialSpeed;
        
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());

        if (other.gameObject.tag == gameObject.tag)
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
