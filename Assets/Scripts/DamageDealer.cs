using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            // Apply damage to the target
            targetHealth.TakeDamage(damage);

            // Check if the target is the player and only destroy if health is zero
            if (targetHealth.GetHealth() <= 0)
            {
                Destroy(target);
            }
        }

        // Destroy the damage dealer itself, e.g., a projectile
        Destroy(gameObject);
    }
}