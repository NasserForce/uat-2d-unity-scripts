using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        var health = col.GetComponent<HealthComponent>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
