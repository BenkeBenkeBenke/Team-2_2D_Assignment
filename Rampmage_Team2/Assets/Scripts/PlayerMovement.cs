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
    
    private void Awake()
    {
        _transform = transform;
        _body = GetComponent<Rigidbody2D>();
        
        /*
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
        */
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
                //Debug.Log(colliders[i].gameObject);
                isGrounded = true;
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
