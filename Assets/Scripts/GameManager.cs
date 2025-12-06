using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement; // Needed for scene changes

public class GameManager : MonoBehaviour
{
    public AudioClip shootSFX;
    public AudioClip hitSFX;
    public AudioClip humSFX;
    public AudioClip musicClip; // Assign in Inspector if playing music through GameManager
    public AudioMixer gameAudioMixer;

    public static GameManager Instance { get; private set; }

    public int score = 0;
    private int obstacleCount = 0;
    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Music AudioSource setup
        if (musicClip != null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.playOnAwake = true;
            // Assign the "Music" group from the Audio Mixer if needed
            if (gameAudioMixer != null)
            {
                var groups = gameAudioMixer.FindMatchingGroups("Music");
                if (groups.Length > 0)
                    musicSource.outputAudioMixerGroup = groups[0];
            }
            musicSource.Play();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void RegisterObstacle()
    {
        obstacleCount++;
    }

    public void UnregisterObstacle()
    {
        obstacleCount--;
        if (obstacleCount <= 0)
        {
            EndGame(true); // Victory when no obstacles remain
        }
    }

    public void OnPlayerDeath()
    {
        EndGame(false); // Defeat when player loses all lives
    }

    // -------- AUDIO: PLAY SOUND EFFECT --------
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    // --------- AUDIO: VOLUME CONTROL WITH PERSISTENCE ---------
    public void SetSFXVolume(float volume)
    {
        if (gameAudioMixer != null)
            gameAudioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
        PlayerPrefs.SetFloat("sfx_volume", volume);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume)
{
    float v = Mathf.Clamp(volume, 0.0001f, 1f); // Prevent zero!
    gameAudioMixer.SetFloat("MusicVolume", Mathf.Log10(v) * 20);
    PlayerPrefs.SetFloat("music_volume", v);
    PlayerPrefs.Save();
}

    private void Start()
    {
        // Load saved volume, set at start
        float sfxVolume = PlayerPrefs.GetFloat("sfx_volume", 0.8f);
        float musicVolume = PlayerPrefs.GetFloat("music_volume", 0.8f);
        SetSFXVolume(sfxVolume);
        SetMusicVolume(musicVolume);

        // Find and update slider UI if present
        var sfxSlider = GameObject.Find("SFXVolumeSlider")?.GetComponent<UnityEngine.UI.Slider>();
        if (sfxSlider != null) sfxSlider.value = sfxVolume;
        var musicSlider = GameObject.Find("MusicVolumeSlider")?.GetComponent<UnityEngine.UI.Slider>();
        if (musicSlider != null) musicSlider.value = musicVolume;
    }

    // --------- GAME END LOGIC ---------
    // Call with true for win, false for loss
    public void EndGame(bool isWin)
    {
        if (isWin)
            SceneManager.LoadScene("Victory");    // Make sure your scene is named exactly "Victory"
        else
            SceneManager.LoadScene("GameOver");   // Make sure your scene is named exactly "GameOver"
    }
}
