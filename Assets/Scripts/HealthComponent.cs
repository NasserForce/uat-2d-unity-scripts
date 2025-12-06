using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play damage SFX when object is hurt
        if (GameManager.Instance != null && GameManager.Instance.hitSFX != null)
        {
            GameManager.Instance.PlaySFX(GameManager.Instance.hitSFX);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            var deaths = GetComponents<DeathComponent>();
            foreach (var death in deaths)
                if (death != null) death.Die();
        }
    }
}
