using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    FMOD.Studio.EventInstance SFXVolumeTestEvent;

    FMOD.Studio.Bus Music;
    FMOD.Studio.Bus SFX;
    FMOD.Studio.Bus Master;
    private float MusicVolume;
    private float SFXVolume;
    private float MasterVolume;
    [SerializeField] private UIAudio _uiAudio;

    void Awake()
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.2f);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        _uiAudio.Init(MasterVolume, MusicVolume, SFXVolume);

        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");

        Master.setVolume(MasterVolume);
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);

        SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXVolumeTest");
    }

    public void MasterVolumeLevel(float newMasterVolume) => SetVolume("MasterVolume", Master, newMasterVolume);

    public void MusicVolumeLevel(float newMusicVolume) => SetVolume("MusicVolume", Music, newMusicVolume);

    public void SFXVolumeLevel(float newSFXVolume) => SetVolume("SFXVolume", SFX, newSFXVolume);

    private void SetVolume(string volumeKey, FMOD.Studio.Bus audioBus, float newVolume)
    {
        PlayerPrefs.SetFloat(volumeKey, newVolume);
        audioBus.setVolume(newVolume);
        if (volumeKey == "SFXVolume")
            PlayTestSound();
    }

    private void PlayTestSound()
    {
        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTestEvent.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTestEvent.start();
        }
    }
}