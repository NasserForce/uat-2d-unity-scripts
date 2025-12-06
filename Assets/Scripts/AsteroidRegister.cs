using UnityEngine;

public class AsteroidRegister : MonoBehaviour
{
    void Start()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.RegisterObstacle();
    }

    void OnDestroy()
    {
        // This fires when the asteroid is destroyed
        if (GameManager.Instance != null)
            GameManager.Instance.UnregisterObstacle();
    }
}
