using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] CharacterController controller;
    [SerializeField] Transform model;
    [SerializeField] GroundCheck groundCheck;
    [SerializeField] LayerMask layerMask;
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 10f;
    [Header("Jump Settings")]
    [SerializeField] int maxJumpCount = 2;
    [SerializeField] float jumpSpeed = 5f;
    [Header("Dash Settings")]
    [SerializeField] int maxDashCount = 2;
    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashTime = .2f;
    [SerializeField] float dashRechargeTime = 1f;
    [Header("Physics Settings")]
    [SerializeField] float gravity = .15f;
    [SerializeField] float wallDrag = .5f;

    Vector2 moveDir;

    float horizontal = 0f;
    float vertical;
    float timeToNextDash;

    int currentJumpCount;
    int currentDashCount;

    bool isDashing;



    void Start(){
        currentJumpCount = maxJumpCount;
    }

    private void FixedUpdate(){

        PlayerMove();
        PlayerDashMove();
        LockZPosition();
    }

    public void PlayerMove(){
        
        if (groundCheck.GetGroundedState() && vertical < 0.01f){
            vertical = -wallDrag;
        }
        
        if (horizontal > 0){
            model.rotation = Quaternion.Euler(0, 0, 0);
        } else if (horizontal < 0){
            model.rotation = Quaternion.Euler(0, 180, 0);
        }
        
        moveDir = new Vector2(horizontal, vertical);
        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        vertical -= gravity;
    }

    void LockZPosition(){
        if (transform.position.z != 0f){
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
        }
    }

    public void PlayerJump(){
        if (groundCheck.GetGroundedState()){
            currentJumpCount = maxJumpCount;
        }
        if (currentJumpCount > 0){
            vertical = jumpSpeed;
            currentJumpCount--;
        }
    }

    public void PlayerDash(){
        StartCoroutine(PlayerDashRoutine());

        IEnumerator PlayerDashRoutine(){
            if (currentDashCount > 0)
            {
                isDashing = true;
                gameObject.layer = LayerMask.NameToLayer("I-Frame");
                timeToNextDash = Time.time + dashRechargeTime;
                yield return new WaitForSeconds(dashTime);
                isDashing = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
                currentDashCount--;
            }
        }
    }

    public void PlayerDashMove(){
        if (currentDashCount < maxDashCount && Time.time > timeToNextDash){
            currentDashCount++;
        }

        if (isDashing){
            vertical = 0f;
            controller.Move(transform.right * moveDir.x * dashSpeed * Time.deltaTime);
        }
    }

    public void SetInput(float input){
        horizontal = input;
    }

    public Vector3 GetDirection(){
        return model.transform.right;
    }
}
