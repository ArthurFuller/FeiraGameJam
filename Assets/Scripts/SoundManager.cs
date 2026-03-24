using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MasterVolumeSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;

    bool isLoading = true;

    void Awake()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        if (savedVolume <= 0f)
            savedVolume = 1f;

        slider.SetValueWithoutNotify(savedVolume);
        ApplyVolume(savedVolume);

        isLoading = false;
    }

    public void SetVolume(float value)
    {
        ApplyVolume(value);

        if (!isLoading)
        {
            PlayerPrefs.SetFloat("MasterVolume", value);
            PlayerPrefs.Save();
        }
    }

    void ApplyVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }
}