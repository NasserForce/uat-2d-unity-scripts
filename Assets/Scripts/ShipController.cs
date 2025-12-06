using UnityEngine;

public class ShipController : MonoBehaviour
{
    private ShipPawn pawn;

    public ShooterBullet shooter;

    void Start()
    {
        pawn = GetComponent<ShipPawn>();
        if (pawn == null)
        {
            Debug.LogError("ShipPawn component missing");
        }

        if (shooter == null)
        {
            Debug.LogWarning("ShooterBullet component is not assigned in inspector");
        }
    }

    void Update()
    {
        if (pawn == null) return;

        float dt = Time.deltaTime;
        bool turbo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float speed = pawn.moveSpeed * (turbo ? pawn.turboMultiplier : 1f);

        // Local space movement with WASD
        float move = 0f;
        if (Input.GetKey(KeyCode.W)) move += 1f;
        if (Input.GetKey(KeyCode.S)) move -= 1f;

        float rotation = 0f;
        if (Input.GetKey(KeyCode.A)) rotation += 1f;
        if (Input.GetKey(KeyCode.D)) rotation -= 1f;

        transform.Translate(Vector3.up * move * speed * dt, Space.Self);
        transform.Rotate(Vector3.forward, rotation * pawn.rotationSpeed * dt);

        // World space teleport with arrows
        if (Input.GetKeyDown(KeyCode.UpArrow))
            transform.position += Vector3.up * pawn.teleportDistance;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            transform.position += Vector3.down * pawn.teleportDistance;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.position += Vector3.left * pawn.teleportDistance;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.position += Vector3.right * pawn.teleportDistance;

        // Random teleport on T
        if (Input.GetKeyDown(KeyCode.T))
        {
            float x = Random.Range(pawn.randomTeleportMinX, pawn.randomTeleportMaxX);
            float y = Random.Range(pawn.randomTeleportMinY, pawn.randomTeleportMaxY);
            transform.position = new Vector3(x, y, transform.position.z);
        }

        // Shoot projectile on Fire1 input
        if (Input.GetButtonDown("Fire1") && shooter != null)
        {
            shooter.Shoot();
        }
    }
}
