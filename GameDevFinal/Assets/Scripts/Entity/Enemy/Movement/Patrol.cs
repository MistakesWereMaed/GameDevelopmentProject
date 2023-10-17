using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] EnemyMovement enemyMovement;
    [Header("Patrol Settings")]
    [SerializeField] float leftBoundary;
    [SerializeField] float rightBoundary;

    int dir = 0;
    bool isPatroling = false;



    void Start(){
        StartPatrol();
    }

    void FixedUpdate(){
        EnemyPatrol();
    }

    void EnemyPatrol(){
        enemyMovement.EnemyMove(dir);

        if(transform.position.x >= rightBoundary || transform.position.x <= leftBoundary){
            SwitchDirections();
        }
    }

    void SwitchDirections(){
        dir *= -1;
    }

    public void StartPatrol(){
        dir = 1;
        isPatroling = true;
    }

    public void StopPatrol(){
        dir = 0;
        isPatroling = false;
    }

    public bool GetPatrolState(){
        return isPatroling;
    }
}
