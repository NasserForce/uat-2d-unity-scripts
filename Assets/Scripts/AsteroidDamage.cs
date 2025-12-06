using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    public int damage = 1;
    public bool instantKill = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        var health = col.GetComponent<HealthComponent>();
        if (health != null)
        {
            if (instantKill)
                health.TakeDamage(health.maxHealth);
            else
                health.TakeDamage(damage);
        }
    }
}
