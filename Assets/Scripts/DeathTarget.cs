using UnityEngine;

public class DeathTarget : DeathComponent
{
    public int points = 100; // designer-exposed
    public override void Die()
    {
        GameManager.Instance.AddScore(points);
        Destroy(gameObject);
    }
}
