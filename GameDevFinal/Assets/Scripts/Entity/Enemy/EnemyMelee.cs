using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] Sword sword;
    [SerializeField] Transform target;
    [SerializeField] AudioSource meleeSFX;
    [Header("Melee Settings")]
    [SerializeField] float meleeAttackDuration = .5f;
    [SerializeField] float meleeCooldown = .3f;
    [SerializeField] int meleeDamage = 25;
    [SerializeField] float preemptiveSwingRange = 1;


    float timeToNextAttack = 0f;
    float range;


    void Awake(){
        sword.SetDamage(meleeDamage);
        range = sword.transform.localScale.x + preemptiveSwingRange;
    }

    void FixedUpdate(){
        Vector3 distance = transform.position - target.position;
        if(distance.sqrMagnitude <= range * range){
            Melee();
        }
    }

    void Melee()
    {
        if (Time.time > timeToNextAttack)
        {
            sword.gameObject.SetActive(true);
            meleeSFX.PlayOneShot(meleeSFX.clip);
            sword.Attack(meleeAttackDuration);
            timeToNextAttack = Time.time + meleeAttackDuration + meleeCooldown;
        }
    }
}
