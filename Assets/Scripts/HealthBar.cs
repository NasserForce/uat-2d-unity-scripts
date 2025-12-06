using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthComponent health; // assign in Inspector
    public Image fillImage;        // assign in Inspector

    private float fullWidth;

    void Start()
    {
        fullWidth = fillImage.rectTransform.sizeDelta.x;
    }

    void Update()
    {
        if (health != null)
        {
            float percent = Mathf.Clamp01((float)health.currentHealth / health.maxHealth);
            fillImage.rectTransform.sizeDelta = new Vector2(fullWidth * percent, fillImage.rectTransform.sizeDelta.y);
        }
    }
}
