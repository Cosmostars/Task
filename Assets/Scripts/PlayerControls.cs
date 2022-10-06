using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Transform groundCheck;
    private bool jumpPressed = false;
    private float horizontalInput;
    private Rigidbody2D rigidBodyComponent;
    public LayerMask playerMask;
    private Animator anim;
    private bool facingLeft = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

         if (horizontalInput > 0 && !facingLeft)
         {
             Flip();
         } else if (horizontalInput < 0 && facingLeft)
        {
            Flip();
        }
    }

    // Physics update
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput * 2, rigidBodyComponent.velocity.y, 0);

        if (Physics2D.OverlapCircleAll(groundCheck.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpPressed == true)
        {
            rigidBodyComponent.AddForce(Vector3.up * 6, (ForceMode2D)ForceMode.VelocityChange);
            jumpPressed = false;
            // Debug.Log("W (up) was pressed");
        }

    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
