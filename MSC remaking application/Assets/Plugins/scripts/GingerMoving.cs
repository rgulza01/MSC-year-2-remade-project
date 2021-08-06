using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;

public class GingerMoving : MonoBehaviour
{
    //component references, injections
    Rigidbody2D player;
    Animator animator;
    
    //values --> config
    [FormerlySerializedAs("speed")] [SerializeField] float runningSpeed = 5f;
    [SerializeField] float jumpingSpeed = 5f;
    [SerializeField] float climbingSpeed = 5f;
    float startingGravityForLadderClimbing;

    //states
    //...not used yet
    
    
    void Start()
    {
        //everytime I reference, I get that componenet 
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //this had to be here because non static player had to be used in a non static method
        startingGravityForLadderClimbing =  player.gravityScale;
    }

    void Update()
    {
        //the order doesn't matter 
        Jump();
        Run();
        Climb();
        FlipPlayer();
    }
    
    
    /// <summary>
    /// Note that I have not used input till now via
    /// CrossPlatformInputManager.GetAxis("Horizontal") I was already working with
    /// left or right or a and d, as shown in edit --> project settings --> input in Unity    
    /// </summary>
    void Run()
    {
        //movement just gets the x axis 
        //this is the value which will be from -1 to 1
        //this is like Input.GetAxisRaw
        float direction = CrossPlatformInputManager.GetAxis("Horizontal");
        //for now I don't want any changes in the y axis so by doing it's velocity.y 
        //we are saying that whatever the current y runningSpeed is, that is what it is
        Vector2 xVelocity = new Vector2(direction * runningSpeed, player.velocity.y);
        
        //this will be the overall velocity now --> essential to specify  
        player.velocity = xVelocity;
        
        //animation for runnning
        //epsilon --> The smallest value that a float can have different from zero.
        bool playerHasHorizontalSpeed = Math.Abs(player.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Running condition", playerHasHorizontalSpeed);
        
    }

    void FlipPlayer()
    {
        bool playerHasSpeed = Math.Abs(player.velocity.x) > Mathf.Epsilon;
        if (playerHasSpeed)
        {
            //its' talking about the transform in the inspector and the scale vector's x y 
            //Sign = Return value is 1 when value given is positive or zero, -1 when value is negative.
            transform.localScale = new Vector2(Mathf.Sign(player.velocity.x), 1f);
        }
    }

    void Jump()
    {
        //make jumping conditional --> if not colliding/touching layers which are --> Ground
        //then allow the player to jump / return / Jump()
        if (player.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            animator.SetLayerWeight(1, 0);
            //because it is a click that require action performed always in the same manner
            //without pressure increasing the movement like we did with the horixontal axis
            //we use GetButtonDown
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                //0 on the x means the same apparently, let's check with player.velocity.x later 
                Vector2 yVelocity = new Vector2(0f, jumpingSpeed);
                //now the overall velocity has changed with the addition of the 2 vectors
                player.velocity += yVelocity;
            } 
        }
        else //if you are not on the ground --> if you are on the air  
        {
            //then the weight of the air layer is set to 1
            animator.SetLayerWeight(1,1);
        }
    }

    private void Climb()
    {
        if (player.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            float direction = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 yVelocity = new Vector2(player.velocity.x, direction * climbingSpeed);
            player.velocity = yVelocity;
            bool playerHasVenticalSpeed = Math.Abs(player.velocity.y) > Mathf.Epsilon;
            animator.SetBool("Climbing condition", playerHasVenticalSpeed);
            player.gravityScale = 0f;
        }
        else //if you are not touching the layer
        {
            animator.SetBool("Climbing condition", false);
            player.gravityScale = startingGravityForLadderClimbing;
        }
        
    }
    
}
