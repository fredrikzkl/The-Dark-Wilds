using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] public Animator handAnimator;


    public float movementSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

  
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movements
        float x = 0;
        float z = 0;

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        //Attacks
        if (!handAnimator.GetBool("isAttacking") && Input.GetButtonDown("LightAttack"))
        {
            LightAttack();
        }       

        Vector3 move = transform.right * x + transform.forward * z;

        WalkAnimation(move);

        controller.Move(move * movementSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }



    void LightAttack()
    {
        handAnimator.SetBool("isAttacking", true);
        handAnimator.SetBool("lightAttack", true);
    }

    void WalkAnimation(Vector3 move)
    {
        var animationSpeed = Mathf.Max(Mathf.Abs(move.x), Mathf.Abs(move.y));
        //handAnimator.SetFloat("walkingSpeedAnimationMultiplier", animationSpeed);
        //Debug.Log("AnimationSpeed: " + animationSpeed + " | Multiplier: " + handAnimator.GetFloat("walkingSpeedAnimationMultiplier"));


    }
}
