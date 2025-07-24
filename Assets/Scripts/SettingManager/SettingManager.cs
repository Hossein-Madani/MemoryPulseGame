using TMPro;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;

    [SerializeField] private TextMeshPro musicText;
    [SerializeField] private TextMeshPro sfxText;

    public int musicValue { get; private set; }
    public int sfxValue { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Load saved values or default to 5 (0.5f)
        musicValue = PlayerPrefs.GetInt("MusicVolume", 5);
        sfxValue = PlayerPrefs.GetInt("SFXVolume", 5);

        ApplyVolumes();
    }

    public void OnMusicVolumeChange(int newValue)
    {
        musicValue = Mathf.Clamp(newValue, 0, 10);
        PlayerPrefs.SetInt("MusicVolume", musicValue);
        SoundManager.instance.MusicVolume = musicValue / 10f;
        UpdateVolumeTexts();
    }

    public void OnSFXVolumeChange(int newValue)
    {
        sfxValue = Mathf.Clamp(newValue, 0, 10);
        PlayerPrefs.SetInt("SFXVolume", sfxValue);
        SoundManager.instance.SFXVolume = sfxValue / 10f;
        UpdateVolumeTexts();
    }

    private void ApplyVolumes()
    {
        SoundManager.instance.MusicVolume = musicValue / 10f;
        SoundManager.instance.SFXVolume = sfxValue / 10f;
        UpdateVolumeTexts();
    }

    private void UpdateVolumeTexts()
    {
        if (musicText != null)
            musicText.text = $"  Music Volume {musicValue * 10}";

        if (sfxText != null)
            sfxText.text = $"  SFX Volume {sfxValue * 10}";
    }

}
