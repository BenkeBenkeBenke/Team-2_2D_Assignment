using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")] 
    public float moveSpeed = 5f;
    //public float accelerationSpeed = 1;
    public float jumpPower = 10f;

    [NonSerialized] public float currentSpeed;
    [NonSerialized] public Vector2 movementInput;
    
    private Transform _transform;
    private Rigidbody2D _body = null;
    private Vector3 _velocity = Vector3.zero;
    private float moveSmoothing = 0.05f;

    //public UnityEvent OnLandEvent;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private const float groundedRadius = 0.2f;

    private PlayerTriggerCollision _triggerCollision;

    //Animation
    private Animator _animatorRED;                      //Animator for the player
    private Animator _animatorBlue;                      //Animator for the player

    private void Awake()
    {
        _transform = transform;
        _body = GetComponent<Rigidbody2D>();
        _triggerCollision = GetComponent<PlayerTriggerCollision>();
        /*
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
        */

        //ref to animator to update when moving
        _animatorRED = this.gameObject.transform.GetChild(1).GetComponent<Animator>();
        _animatorBlue = this.gameObject.transform.GetChild(2).GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        if (movementInput.sqrMagnitude > 1f)
        {
            movementInput.Normalize();
        }

        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                //Debug.Log("Standing on GameObject: " + colliders[i].gameObject + " - Tag: " + colliders[i].gameObject.tag);
                isGrounded = true;
                //_triggerCollision.isOnStairs = false;
                /*
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                } 
                */
            }
        }
        //MoveInDirection();
        // currentSpeed = _body.velocity;
    }
    
    public void MoveInDirection(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * moveSpeed, _body.velocity.y);
        _body.velocity = Vector3.SmoothDamp(_body.velocity, targetVelocity, ref _velocity, moveSmoothing);
        
        if (isGrounded == true && jump == true)
        {
            isGrounded = false;
            _body.AddForce(new Vector2(0f, jumpPower));    
        }

        //transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, transform.position.x + (movementInput.x * moveSpeed), accelerationSpeed * Time.fixedDeltaTime), 0, 0);
        //transform.position = new Vector3(transform.position.x + movementInput.x * moveSpeed, 0, 0);
        //currentSpeed = Mathf.MoveTowards(currentSpeed, movementInput.x * moveSpeed, accelerationSpeed * Time.fixedDeltaTime);
        //_body.AddForce(Vector2.right * movementInput.x, ForceMode2D.Force);

        // Update animation
        _animatorRED.SetFloat("Body_Velocity_Horizontal", Input.GetAxis("Horizontal"));
        _animatorRED.SetFloat("Body_Velocity_Vertical", Input.GetAxis("Vertical"));
        _animatorBlue.SetFloat("Body_Velocity_Horizontal", Input.GetAxis("Horizontal"));
        _animatorBlue.SetFloat("Body_Velocity_Vertical", Input.GetAxis("Vertical"));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        
         _stairTrigger = other.gameObject;
         Collider2D thisStairCollider;
         
        if (_stairTrigger.tag == "StairTrigger")
        {
            thisStairCollider = _stairTrigger.transform.Find("StairCollider").GetComponent<Collider2D>();
            isOnStairs = true;
            //thisStairCollider.enabled = true;
        }
        else
        {
            isOnStairs = false;
            thisStairCollider.enabled = false;
        }
      
        Debug.Log("isOnStairs = " + isOnStairs);
    }

    private void OnTriggerExit(Collider other)
    {
        isOnStairs = false;

        Debug.Log("isOnStairs = " + isOnStairs);
    }
    */
}
