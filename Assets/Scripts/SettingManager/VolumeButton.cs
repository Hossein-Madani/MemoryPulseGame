using UnityEngine;

public class VolumeButton : MonoBehaviour
{
    public enum VolumeButtonType
    {
        MusicVolumeUp, MusicVolumeDown,
        SFXVolumeUp, SFXVolumeDown
    }

    public VolumeButtonType buttonType;

    private void OnMouseDown()
    {
        var manager = SettingManager.Instance;

        switch (buttonType)
        {
            case VolumeButtonType.MusicVolumeUp:
                manager.OnMusicVolumeChange(manager.musicValue + 1);
                break;

            case VolumeButtonType.MusicVolumeDown:
                manager.OnMusicVolumeChange(manager.musicValue - 1);
                break;

            case VolumeButtonType.SFXVolumeUp:
                manager.OnSFXVolumeChange(manager.sfxValue + 1);
                break;

            case VolumeButtonType.SFXVolumeDown:
                manager.OnSFXVolumeChange(manager.sfxValue - 1);
                break;
        }
    }
}
