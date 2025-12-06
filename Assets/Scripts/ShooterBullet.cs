using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject projectilePrefab;
    public float bulletSpeed = 10f;

    public override void Shoot()
    {
        Vector3 spawnPos = transform.position + transform.up;
        GameObject bullet = Instantiate(projectilePrefab, spawnPos, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.linearVelocity = transform.up * bulletSpeed;
             GameManager.Instance.PlaySFX(GameManager.Instance.shootSFX);
        }
    }
}
