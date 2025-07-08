using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    public AudioSettings audioSettings;
    public Slider sliderEffect;
    public Slider sliderMusic;
    public Button buttonMusicOn;
    public Button buttonMusicOff;
    public Button buttonEffectOn;
    public Button buttonEffectOff;
    /*
    public Toggle toggleEffect;
    public Toggle toggleMusic;
    */

    private const string MusicVolumeKey = "MusicVolume";
    private const string EffectsVolumeKey = "EffectsVolume";

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

        LoadAudioSettings();
        ApplyVolumeSettings();

        buttonMusicOn.onClick.AddListener(OnButtonMusicOnClicked);
        buttonMusicOff.onClick.AddListener(OnButtonMusicOffClicked);
        buttonEffectOn.onClick.AddListener(OnButtonEffectOnClicked);
        buttonEffectOff.onClick.AddListener(OnButtonEffectOffClicked);
        /*
        toggleMusic.onValueChanged.AddListener(OnMusicToggleChanged);
        toggleEffect.onValueChanged.AddListener(OnEffectToggleChanged);
        */
        PlaySound("MainTheme");
    }
    void Update()
    {
        
        foreach (Sound s in sounds)
        {
            //s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

        LoadAudioSettings();
        ApplyVolumeSettings();

        buttonMusicOn.onClick.AddListener(OnButtonMusicOnClicked);
        buttonMusicOff.onClick.AddListener(OnButtonMusicOffClicked);
        buttonEffectOn.onClick.AddListener(OnButtonEffectOnClicked);
        buttonEffectOff.onClick.AddListener(OnButtonEffectOffClicked);
        
        //PlaySound("MainTheme");
    }
    public void PlaySound(string name)
    {
        Sound sound = GetSoundByName(name);
        if (sound != null)
        {
            sound.source.Play();
        }
    }
    
    public void OnButtonMusicOnClicked()
    {
        audioSettings.musicVolume = 1f; // Встановіть гучність максимальною
        ApplyVolumeSettings();
        SaveAudioSettings();
    }

    public void OnButtonMusicOffClicked()
    {
        audioSettings.musicVolume = 0f; // Встановіть гучність мінімальною (вимкнено)
        ApplyVolumeSettings();
        SaveAudioSettings();
    }

    public void OnButtonEffectOnClicked()
    {
        audioSettings.effectsVolume = 1f; // Встановіть гучність максимальною
        ApplyVolumeSettings();
        SaveAudioSettings();
    }

    public void OnButtonEffectOffClicked()
    {
        audioSettings.effectsVolume = 0f; // Встановіть гучність мінімальною (вимкнено)
        ApplyVolumeSettings();
        SaveAudioSettings();
    }

    /*
    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }
    }*/

    public void SetMusicVolume(float volume)
    {
        audioSettings.musicVolume = volume;
        ApplyVolumeSettings();
        SaveAudioSettings();
    }

    public void SetEffectsVolume(float volume)
    {
        audioSettings.effectsVolume = volume;
        ApplyVolumeSettings();
        SaveAudioSettings();
    }

    private void ApplyVolumeSettings()
    {
        /*
        bool isMusicEnabled = toggleMusic.isOn;
        bool isEffectsEnabled = toggleEffect.isOn;
        */
        foreach (Sound s in sounds)
        {
            /*
            if (s.type == "music")
            {
                s.source.volume = s.volume * audioSettings.musicVolume;
            }
            else if (s.type == "effect")
            {
                s.source.volume = s.volume * audioSettings.effectsVolume;
            }*/
            /*
            if (s.type == "music")
            {
                s.source.volume = isMusicEnabled ? s.volume * audioSettings.musicVolume : 0f;
            }
            else if (s.type == "effect")
            {
                s.source.volume = isEffectsEnabled ? s.volume * audioSettings.effectsVolume : 0f;
            }*/
            if (s.type == "music")
            {
                s.source.volume = s.volume * audioSettings.musicVolume;
            }
            else if (s.type == "effect")
            {
                s.source.volume = s.volume * audioSettings.effectsVolume;
            }
        }
    }
    private Sound GetSoundByName(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                return s;
            }
        }
        Debug.LogWarning("Sound with name " + name + " not found!");
        return null;
    }
    private void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat(MusicVolumeKey, audioSettings.musicVolume);
        PlayerPrefs.SetFloat(EffectsVolumeKey, audioSettings.effectsVolume);
        PlayerPrefs.Save();
    }

    private void LoadAudioSettings()
    {
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            audioSettings.musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey);
        }

        if (PlayerPrefs.HasKey(EffectsVolumeKey))
        {
            audioSettings.effectsVolume = PlayerPrefs.GetFloat(EffectsVolumeKey);
        }

        sliderMusic.value = audioSettings.musicVolume;
        sliderEffect.value = audioSettings.effectsVolume;

        sliderMusic.onValueChanged.AddListener(SetMusicVolume);
        sliderEffect.onValueChanged.AddListener(SetEffectsVolume);
    }

    /*
    public void Volume(string type)
    {
        
        foreach (Sound s in sounds)
        {
            if (type == "music")
            {
                if(s.type == type)
                {
                    s.source.volume = sliderMusic.value;
                }
            }
            if (s.type == type)
            {
                s.volume = sliderEffect.value;
                s.source.volume = sliderEffect.value;
                s.volume = sliderMusic.value;
                s.source.volume = sliderMusic.value;
            }
        }
    }*/
}
