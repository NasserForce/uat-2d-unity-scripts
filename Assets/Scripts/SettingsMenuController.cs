using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsMenuController : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
