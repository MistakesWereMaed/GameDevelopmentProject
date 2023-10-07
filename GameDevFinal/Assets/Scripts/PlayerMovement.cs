using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask layerMask;

    public float moveSpeed = 10f;

    public float jumpSpeed = 5f;
    public int maxJumpCount = 2;

    public float dashSpeed = 20f;
    public float dashTime = .2f;
    public float dashRechargeTime = 1f;
    public int maxDashCount = 2;

    public float gravity = .15f;

    Vector2 moveDir;

    float horizontal = 0f;
    float vertical;
    float timeToNextDash;

    int currentJumpCount;
    int currentDashCount;

    bool isGrounded;
    bool isDashing;

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, .4f, layerMask);

        playerMove();
        playerDashMove();
    }

    public void playerMove()
    {
        if (isGrounded && vertical < 0.01f)
        {
            vertical = -.5f;
        }


        if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        moveDir = new Vector2(horizontal, vertical);
        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        vertical -= gravity;
    }

    public void playerJump()
    {
        if (isGrounded)
        {
            currentJumpCount = maxJumpCount;
        }
        if (currentJumpCount > 0)
        {
            vertical = jumpSpeed;
            currentJumpCount--;
        }
    }

    public IEnumerator PlayerDash()
    {
        if (currentDashCount > 0)
        {
            isDashing = true;
            timeToNextDash = Time.time + dashRechargeTime;
            yield return new WaitForSeconds(dashTime);
            isDashing = false;
            currentDashCount--;
        }
    }

    public void playerDashMove()
    {
        if (currentDashCount < maxDashCount && Time.time > timeToNextDash)
        {
            currentDashCount++;
        }

        if (isDashing)
        {
            vertical = 0f;
            controller.Move(transform.right * dashSpeed * Time.deltaTime);
        }
    }

    public void setInput(float input)
    {
        horizontal = input;
    }
}
