using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Object Assignments")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject bullet;
    [SerializeField] Sword sword;
    [SerializeField] AudioSource shootSFX;
    [SerializeField] AudioSource meleeSFX;
    [Header("Shoot Settings")]
    [SerializeField] float fireRate = 3f;
    [SerializeField] int bulletDamage = 10;
    [Header("Melee Settings")]
    [SerializeField] float meleeAttackDuration = .5f;
    [SerializeField] float meleeCooldown = .1f;
    [SerializeField] int meleeDamage = 10;



    float timeToNextAttack = 0f;
    float shootCooldown = 0;
    bool shooting = false;



    void Awake(){
        sword.SetDamage(meleeDamage);
    }

    public void StartShoot()
    {
        shooting = true;
        StartCoroutine(ShootRoutine());
    }

    public void EndShoot()
    {
        shooting = false;
    }

    IEnumerator ShootRoutine(){
        while(shooting){
            if(Time.time > shootCooldown){
                shootCooldown = Time.time + 1/fireRate;
                shootSFX.PlayOneShot(shootSFX.clip);
                Bullet _bullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
                _bullet.SetDirection(playerMovement.GetDirection());
                _bullet.SetDamage(bulletDamage);
                _bullet.Shoot();
            }
            yield return null;
        }
        yield return null;
    }

    public void Melee()
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
