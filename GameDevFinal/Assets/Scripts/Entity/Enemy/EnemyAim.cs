using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] EnemyShoot enemyShoot;
    [SerializeField] Patrol patrol;
    [SerializeField] Transform target;
    [SerializeField] LayerMask layerMask;
    [Header("Aim Settings")]
    [SerializeField] float aggroRange = 25f;

    bool lockedOn;



    void FixedUpdate(){
        Vector3 distance = transform.position - target.position;
        if(distance.sqrMagnitude <= aggroRange * aggroRange && LockOn()){
            patrol.StopPatrol();
            enemyShoot.Shoot(target.position);
        } else if(!patrol.GetPatrolState()){
            patrol.StartPatrol();
        }
    }

    bool LockOn(){
        bool lineOfSight = Physics.Raycast(transform.position, target.position - transform.position, aggroRange, layerMask);

        if(lineOfSight){
            lockedOn = true;
        } else {
            lockedOn = false;
        }

        return lockedOn;
    }

    public bool GetLockState(){
        return lockedOn;
    }
}
