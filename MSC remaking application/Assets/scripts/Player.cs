using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //component references, injections
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    Collider2D myCollider2D;

    //values --> config
    [SerializeField] float runningSpeed = 5f;
    [SerializeField] float jumpingSpeed = 300f;
    [SerializeField] float climbingSpeed = 5f;
    float startingGravityForLadderClimbing;

    //states
    private bool isAlive = true;


    void Start()
    {
        //everytime I reference, I get that componenet 
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();


        //this had to be here because non static player had to be used in a non static method
        startingGravityForLadderClimbing = myRigidbody.gravityScale;
    }

    void Update()
    {
        //the order doesn't matter 
        Jump();
        Run();
        // Climb();
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
        Vector2 xVelocity = new Vector2(direction * runningSpeed, myRigidbody.velocity.y);

        //this will be the overall velocity now --> essential to specify  
        myRigidbody.velocity = xVelocity;

        //animation for runnning
        //epsilon --> The smallest value that a float can have different from zero.
        bool playerHasHorizontalSpeed = Math.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("run param", playerHasHorizontalSpeed);

    }

    void FlipPlayer()
    {
        bool playerHasSpeed = Math.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasSpeed)
        {
            //its' talking about the transform in the inspector and the scale vector's x y 
            //Sign = Return value is 1 when value given is positive or zero, -1 when value is negative.
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    void Jump()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            //0 on the x means the same apparently, let's check with player.velocity.x later 
            Vector2 yVelocity = new Vector2(0f, jumpingSpeed);
            //now the overall velocity has changed with the addition of the 2 vectors
            myRigidbody.velocity += yVelocity;
        }
    }

    /*
    private void Climb()
    {
        if (myRigidbody.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            float direction = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 yVelocity = new Vector2(myRigidbody.velocity.x, direction * climbingSpeed);
            myRigidbody.velocity = yVelocity;
            bool playerHasVenticalSpeed = Math.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("climb param", playerHasVenticalSpeed);
            myRigidbody.gravityScale = 0f;
        }
        else //if you are not touching the layer
        {
            myAnimator.SetBool("climb param", false);
            myRigidbody.gravityScale = startingGravityForLadderClimbing;
        }
         }
        */

}
