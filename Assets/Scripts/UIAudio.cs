using UnityEngine;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    [SerializeField] private Scrollbar _masterVolume;
    [SerializeField] private Scrollbar _musicVolume;
    [SerializeField] private Scrollbar _sfxVolume;
    public void Init(float master, float music, float sfx)
    {
        _masterVolume.value = master;
        _musicVolume.value = music;
        _sfxVolume.value = sfx;
    }
}
