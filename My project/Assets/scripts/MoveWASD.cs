using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float jump;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float MovementX;
    private float MovementY;

    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        MovementX = 0; MovementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(MovementX, MovementY) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rigidBody.AddForce(new Vector2(rigidBody.velocity.x, jump));
        }

        if (Input.GetKeyDown(KeyCode.W) && rigidBody.velocity.y > 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f); ;
        }




        if (Input.GetKeyDown(KeyCode.D))
        {
            MovementX = 1;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            MovementX = -1;
        }
   
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            MovementX = 0;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
    }
}
