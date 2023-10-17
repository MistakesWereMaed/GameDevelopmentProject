using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] CharacterController controller;
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;
    [Header("Physics Settings")]
    [SerializeField] float gravity = .15f;

    Vector2 moveDir;
    float vertical = 0f;



    void FixedUpdate(){
        LockZPosition();
    }

    public void EnemyMove(float horizontal){        
        if (horizontal > 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (horizontal < 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
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

    public CharacterController GetController(){
        return controller;
    }
}
