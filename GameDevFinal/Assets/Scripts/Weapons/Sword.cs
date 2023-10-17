using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    int damage = 25;

    void Awake(){
        gameObject.SetActive(false);
    }

    public void Attack(float duration){
        StartCoroutine(AttackRoutine());

        IEnumerator AttackRoutine(){
            float timer = 0;
            while(timer < duration){
                timer += Time.deltaTime;
                yield return null;
            }
            gameObject.SetActive(false);
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other){
        EntityManager entity = other.gameObject.GetComponent<EntityManager>();
        if(entity != null){
            entity.Hit(damage);
        }
    }

    public void SetDamage(int damage){
        this.damage = damage;
    }
}
