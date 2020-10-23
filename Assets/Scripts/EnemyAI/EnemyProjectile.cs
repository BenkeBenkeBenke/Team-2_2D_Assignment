using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 1f;
    public float lifespan = 2.0f;
    public float damage = 10f;

     public Vector2 initialSpeed;

    private GameObject _aim;
    private Vector2 direction;
    private Rigidbody2D _body;
    //private GameObject _player;
    //private GameObject _player;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _aim = GameObject.Find("Player");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());
        /*
        if (other.gameObject.tag == gameObject.tag)
        {
            Destroy(other.gameObject);
        }
        */
        Destroy(gameObject);
    }

}
