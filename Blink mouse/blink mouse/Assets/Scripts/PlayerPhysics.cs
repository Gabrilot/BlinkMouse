using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Controller2D))]
public class PlayerPhysics : MonoBehaviour {

    public static Animator anim;

    public float jumpHeight=4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne=.2f;
    float accelerationTimeGrounded=.1f;
    float moveSpeed=2;
    float gravity;

    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    void Start()
    {
        anim = GetComponent<Animator>();

        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity" + gravity + " Jump Velocity" + jumpVelocity);
    }

    void Update()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
            anim.SetBool("IsJumping", false);
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input.x == -1 && velocity.y == 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("IsMoving", true);
        } else if (input.x == 1 && velocity.y == 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("IsMoving", true);
        } else
        {
            anim.SetBool("IsMoving", false);
        }
    

        if(Input.GetKeyDown(KeyCode.Space)&& controller.collisions.below)
        {
            velocity.y = jumpVelocity;
                anim.SetBool("IsJumping", true);
          
        }
      

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    
  

    }
}

