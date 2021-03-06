﻿using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
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
    private PlayerTriggerCollision _triggerCollision;
    private PlayerAttackResource _attackResource;

    //Animation
    [Header("Animation")]
    private Animator _animatorRED;                      //Animator for the player
    private Animator _animatorBLUE;                      //Animator for the player
    private ParticleSystem _CastSpel_PS;                      //Animator for the player

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _body = GetComponent<Rigidbody2D>();
        _shield = GetComponent<PlayerShield>();
        _triggerCollision = transform.Find("CollisionDetection").GetComponent<PlayerTriggerCollision>();
        _attackResource = GetComponent<PlayerAttackResource>();

        //ref to animator to update when moving
        _animatorRED = this.gameObject.transform.GetChild(1).GetComponent<Animator>();
        _animatorBLUE = this.gameObject.transform.GetChild(2).GetComponent<Animator>();

        //ref to particle system
        _CastSpel_PS = this.gameObject.transform.GetChild(3).GetComponent<ParticleSystem>();


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
        if (Input.GetButtonDown("Fire1"))
        {
            StartAttack01();

            //Start animation
            _animatorRED.SetBool("Fire", true);
            _animatorBLUE.SetBool("Fire", true);

            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopAttack01();

            //Stop animation
            _animatorRED.SetBool("Fire", false);
            _animatorBLUE.SetBool("Fire", false);
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            StartAttack02();
            //Start animation
            _animatorRED.SetBool("Fire", true);
            _animatorBLUE.SetBool("Fire", true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            StopAttack02();
            //Stop animation
            _animatorRED.SetBool("Fire", false);
            _animatorBLUE.SetBool("Fire", false);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            _shield.ToggleShield();
        }

        if (Input.GetAxis("Vertical") >= 0.1)
        {
            _triggerCollision.UseStair(true);
        }
        if (Input.GetAxis("Vertical") <= -0.1)
        {
            _triggerCollision.UseStair(false);
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
        if (projectileType == projectileRed && _attackResource.redResource >= _attackResource.redCost)
        {
            _CastSpel_PS.Play();
            _attackResource.UseRedResource();
            var newProjectile = Instantiate(projectileType, projectileOrigin.transform.position, projectileOrigin.transform.rotation);   
            newProjectile.GetComponent<PlayerProjectiles>().SetInitialSpeed(_body.velocity);
        }
        if (projectileType == projectileBlue && _attackResource.blueResource >= _attackResource.blueCost)
        {
            _CastSpel_PS.Play();
            _attackResource.UseBlueResource();
            var newProjectile = Instantiate(projectileType, projectileOrigin.transform.position, projectileOrigin.transform.rotation);    
            newProjectile.GetComponent<PlayerProjectiles>().SetInitialSpeed(_body.velocity);
        }
        
    }
}
