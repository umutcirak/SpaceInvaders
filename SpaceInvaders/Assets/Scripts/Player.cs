using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{    
    [SerializeField] float movementSpeed = 15f;   
    [SerializeField] float paddingTop  = 1f;
    [SerializeField] float paddingBottom = 1f;
    [SerializeField] float paddingLeft = 1f;
    [SerializeField] float paddingRight = 1f;
    [SerializeField] GameObject projectile;

    Vector2 moveInput;
    Vector2 minBound;
    Vector2 maxBound;

    Shooter shooter;

    void Awake()
    {
        shooter = FindObjectOfType<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }

  
    void Update()
    {
        Move();       

    }

    void InitBounds()
    {
        minBound = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }
    

    void Move()
    {
        Vector2 reducedMoveInput = moveInput * movementSpeed * Time.deltaTime;
        Vector2 newPosition = new Vector2();

        newPosition.x = Mathf.Clamp(transform.position.x + reducedMoveInput.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + reducedMoveInput.y, minBound.y + paddingBottom, maxBound.y - paddingTop);

        transform.position = newPosition;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }


}
