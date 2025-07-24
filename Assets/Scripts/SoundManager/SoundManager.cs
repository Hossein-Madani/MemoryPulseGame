using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private AudioSource MusicPlayer;

    [Range(0f, 1f)] public float MusicVolume = 0.5f;
    [Range(0f, 1f)] public float SFXVolume = 0.5f;

    public enum SoundNames
    {
        ButtonClick1,
        ButtonClick2,
        GameStart,
        GameOver,
        LevelComplete,
        BackgroundMusic,
        CubeShow,
        AutoCubeShow,
        ButtonHover
    }

    [System.Serializable]
    public class AudioClipData
    {
        public SoundNames soundName;
        public AudioClip clip;
    }

    public AudioClipData[] audioClips;

    /// <summary>
    /// Play a sound. Supports optional pitch override (for SFX only).
    /// </summary>
    public void PlaySound(SoundNames soundName, float pitch = 1f)
    {
        foreach (var audioClip in audioClips)
        {
            if (audioClip.soundName == soundName)
            {
                if (soundName == SoundNames.BackgroundMusic)
                {
                    MusicPlayer.clip = audioClip.clip;
                    MusicPlayer.volume = MusicVolume;
                    MusicPlayer.loop = true;
                    MusicPlayer.Play();
                }
                else
                {
                    // Create GameObject for sound effect
                    GameObject sfxObject = new GameObject("SFX_" + soundName);
                    AudioSource audioSource = sfxObject.AddComponent<AudioSource>();
                    audioSource.clip = audioClip.clip;
                    audioSource.volume = SFXVolume;
                    audioSource.pitch = pitch;
                    audioSource.Play();

                    // Destroy after sound ends
                    Destroy(sfxObject, audioClip.clip.length / pitch);
                }
                return;
            }
        }

        Debug.LogWarning("Sound not found: " + soundName);
    }
}
