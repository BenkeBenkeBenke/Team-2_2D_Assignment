using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerInputs : MonoBehaviour
{
    public GameObject projectileOrigin;
    public GameObject projectileRed;
    public GameObject projectileBlue;
    
    public float timeBetweenAttacks = 1.0f;
    private float timeSinceLastAttack;

    private PlayerMovement _movement;
    private Rigidbody2D _body;
    private Coroutine Attack01Coroutine;
    private Coroutine Attack02Coroutine;

    private bool jump = false;

    private PlayerShield _shield;
    
    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _body = GetComponent<Rigidbody2D>();
        _shield = GetComponent<PlayerShield>();
    }

    void Update()
    {
        //_movement.movementInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //_movement.MoveInDirection(Input.GetAxis("Horizontal"));
        
        if (Input.GetButtonDown("Jump"))
        {
            //_movement.MoveInDirection();
            jump = true;
        }
        if (Input.GetButtonDown("Attack01"))
        {
            StartAttack01();
        }
        if (Input.GetButtonUp("Attack01"))
        {
            StopAttack01();
        }
        
        if (Input.GetButtonDown("Attack02"))
        {
            StartAttack02();
        }
        if (Input.GetButtonUp("Attack02"))
        {
            StopAttack02();
        }

        if (Input.GetButtonDown("Shield01"))
        {
            
        }
        if (Input.GetButtonDown("Shield02"))
        {
            
        }
    }

    private void FixedUpdate()
    {
        _movement.MoveInDirection(Input.GetAxis("Horizontal"), jump);
        jump = false;
    }

    private void StartAttack01()
    {
        Attack01Coroutine = StartCoroutine(Attacking(Mathf.Max(0f, timeSinceLastAttack + timeBetweenAttacks - Time.time), projectileRed));
        
        //newProjectileRed.GetComponent<PlayerProjectile>().SetInitialSpeed(_movement.currentSpeed);
    }
    private void StopAttack01()
    {
        StopCoroutine(Attack01Coroutine);
    }
    
    private void StartAttack02()
    {
        Attack02Coroutine = StartCoroutine(Attacking(Mathf.Max(0f, timeSinceLastAttack + timeBetweenAttacks - Time.time), projectileBlue));
    }
    private void StopAttack02()
    {
        StopCoroutine(Attack02Coroutine);
    }
    
    IEnumerator Attacking(float startDelay, GameObject projectileType) {
        yield return new WaitForSeconds(startDelay);
        while (true) {
            //weaponParticleSystem.Play();

            FireProjectile(projectileType);

            timeSinceLastAttack = Time.time;
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }

    private void FireProjectile(GameObject projectileType)
    {
        var newProjectile = Instantiate(projectileType, projectileOrigin.transform.position, projectileOrigin.transform.rotation);
    }
}
