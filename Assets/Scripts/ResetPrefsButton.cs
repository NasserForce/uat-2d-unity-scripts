using UnityEngine;

public class ResetPrefsButton : MonoBehaviour
{
    // Attach to a GameObject, call this method from a Button OnClick or run Play mode once
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All PlayerPrefs deleted and reset!");
    }

    // Uncomment this for one-time use in editor Play mode
    /*
    void Start() {
        ResetPrefs();
    }
    */
}
