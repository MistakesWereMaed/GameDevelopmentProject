using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Material modelMaterial;

    public float lightAttackDuration = .5f;
    public float heavyAttackDuration = 1f;
    public float specialAttackDuration = 1f;
    public float chargedSpecialAttackDuration = 2f;

    float timeToNextAttack = 0f;

    private void FixedUpdate()
    {
        if (Time.time > timeToNextAttack)
        {
            modelMaterial.color = Color.blue;
        }
    }

    public void lightAttack()
    {
        if (Time.time > timeToNextAttack)
        {
            Debug.Log("light");
            modelMaterial.color = Color.red;
            timeToNextAttack = Time.time + lightAttackDuration;
        }
    }

    public void heavyAttack()
    {
        if (Time.time > timeToNextAttack)
        {
            Debug.Log("heavy");
            modelMaterial.color = Color.red;
            timeToNextAttack = Time.time + heavyAttackDuration;
        }
    }

    public void specialAttack()
    {
        if (Time.time > timeToNextAttack)
        {
            Debug.Log("special");
            modelMaterial.color = Color.red;
            timeToNextAttack = Time.time + specialAttackDuration;
        }
    }

    public void chargedSpecialAttack()
    {
        if (Time.time > timeToNextAttack)
        {
            Debug.Log("charged special");
            modelMaterial.color = Color.red;
            timeToNextAttack = Time.time + chargedSpecialAttackDuration;
        }
    }
}
