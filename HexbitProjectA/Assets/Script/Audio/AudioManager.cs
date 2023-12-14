using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackroundPref = "BackroundPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";

    private int firstPlayInt;
    public Slider backroundSlider, soundEffectsSlider;
    private float backroundFloat, soundEffectsFloat;

    public AudioSource backroundAudio;
    public AudioSource[] soundEffectsAudio;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backroundFloat = .125f;
            soundEffectsFloat = .75f;
            backroundSlider.value = backroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackroundPref, backroundFloat);
            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backroundFloat = PlayerPrefs.GetFloat(BackroundPref);
            backroundSlider.value = backroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackroundPref, backroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backroundAudio.volume = backroundSlider.value;

        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
}
