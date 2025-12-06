using UnityEngine;

public class DeathDestroy : DeathComponent
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
