using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    public float speed;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Key_Input();
        Animate_Player();
    }

    void FixedUpdate() 
    {
        Movement();    
    }

    void Movement()
    {
        //Moves player when respective keys are pressed
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void Key_Input()
    {
        if((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            //if the character is no longer moving and it has moved on either axis before, we store the last movement direction into lastMoveDirection.
            lastMoveDirection = moveDirection;
        }

        //When keys effecting horizontal or vertical movement are pressed, values on both the x and y axis are changed. So we store both changed into the Vector2 object moveDirection. We normalize it so that the magnitude on all directions are the same.
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void Animate_Player()
    {
        //connects MoveX and MoveY animation parameters to moveDirection so what their valus will be the same.
        anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);

        //connects MovementMagnitude parameter to moveDirection's magnitude. This will determine whether or not the player is in motion. If he is, the respective movement animation will play. If not, the respective idle animation will play.
        anim.SetFloat("MovementMagnitude", moveDirection.magnitude);

        //connects LastMoveX and LastMoveY parameters to lastMoveDirection. this is to determine which idle animation will play when the player is no longer in motion.
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }
}
