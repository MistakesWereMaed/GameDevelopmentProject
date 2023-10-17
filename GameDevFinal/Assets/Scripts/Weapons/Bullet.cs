using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] Rigidbody body;
    [Header("Bullet Settings")]
    [SerializeField] float speed;
    [SerializeField] float lifeSpan = 2f;

    Vector3 direction;
    int damage;



    public void Shoot()
    {
        body.AddForce(direction.normalized * speed, ForceMode.Impulse);
        DeathTimer();
    }

    void DeathTimer(){
        StartCoroutine(DeathTimerRoutine());

        IEnumerator DeathTimerRoutine(){
            float timer = 0;
            while(timer < lifeSpan){
                timer += Time.deltaTime;
                yield return null;
            }
            Destroy(gameObject);
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other){
        EntityManager entity = other.gameObject.GetComponent<EntityManager>();
        if(entity != null){
            entity.Hit(damage);
        }
        Destroy(gameObject);
    }

    public void SetDamage(int damage){
        this.damage = damage;
    }

    public void SetDirection(Vector3 direction){
        this.direction = direction;
    }
}
