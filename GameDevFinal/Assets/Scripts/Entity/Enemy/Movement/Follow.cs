using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] Transform target;
    [Header("Follow Settings")]
    [SerializeField] float aggroRange = 15f;
    [SerializeField] float spacingBuffer = 1f;



    void FixedUpdate(){
        EnemyFollow();
    }

    void EnemyFollow(){
        Vector3 distance = transform.position - target.position;
        if(distance.sqrMagnitude <= aggroRange * aggroRange && distance.sqrMagnitude > spacingBuffer * spacingBuffer){
            enemyMovement.EnemyMove(distance.x > 0 ? -1 : 1);
        }
    }
}
