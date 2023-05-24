using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    private float masterVolume = 1f;
    private float sfxVolume = 1f;
    private float musicVolume = 1f;

    void Start()
    {
        // Load saved volumes, or use default values if no saved volumes exist
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 1f);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Set initial slider values to the saved volumes
        masterSlider.value = masterVolume;
        sfxSlider.value = sfxVolume;
        musicSlider.value = musicVolume;

        // Set initial volumes based on saved volumes
        SetMasterVolume(masterVolume);
        SetSfxVolume(sfxVolume);
        SetMusicVolume(musicVolume);

        // Set up event listeners for sliders
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        Debug.Log(masterSlider.value);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMasterVolume(float volume)
    {
        // Set master volume and save the current value
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20f);
        masterVolume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);

        // Update other volumes accordingly
        SetSfxVolume(sfxVolume);
        SetMusicVolume(musicVolume);
    }

    public void SetSfxVolume(float volume)
    {
        // Set sfx volume, taking into account the master volume
        mixer.SetFloat("Sfx", Mathf.Log10(volume * masterVolume) * 20f);
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        // Set music volume, taking into account the master volume
        mixer.SetFloat("Music", Mathf.Log10(volume * masterVolume) * 20f);
        musicVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
