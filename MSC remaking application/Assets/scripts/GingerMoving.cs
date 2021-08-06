using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
     Rigidbody2D myRigidBody;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>;
    }
      
    void Update()
    {
        Run();
           }
    void Run()
    {
        float controIThrow = CrossPlatformlnputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controIThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

    }

} 