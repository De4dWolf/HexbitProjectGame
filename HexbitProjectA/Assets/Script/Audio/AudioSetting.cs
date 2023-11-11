using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackroundPref = "BackroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private float backroundFloat, soundEffectsFloat;

    public AudioSource backroundAudio;
    public AudioSource[] soundEffectsAudio;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backroundFloat = PlayerPrefs.GetFloat(BackroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);

        backroundAudio.volume = backroundFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}
