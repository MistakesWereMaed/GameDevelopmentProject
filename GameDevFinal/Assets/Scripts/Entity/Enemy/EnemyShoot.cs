using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] GameObject bullet;
    [SerializeField] AudioSource shootSFX;
    [Header("Shoot Settings")]
    [SerializeField] float fireRate = 3f;
    [SerializeField] int damage = 10;

    float shootCooldown = 0;



    public void Shoot(Vector3 target){
        if(Time.time > shootCooldown){
            shootCooldown = Time.time + 1/fireRate;
            shootSFX.PlayOneShot(shootSFX.clip);
            Bullet _bullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
            _bullet.SetDirection(target - transform.position);
            _bullet.SetDamage(damage);
            _bullet.Shoot();
        }
    }
}
