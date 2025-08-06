using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] MenuBasic settingsBasic;
    [Header("Sound")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] TextMeshProUGUI musicValue;
    [SerializeField] TextMeshProUGUI soundValue;
    [Header("Sceen")]
    [SerializeField] TMP_Dropdown ScreenMode;
    [SerializeField] TMP_Dropdown ResolutionDropDown;
    Resolution[] resolutions;

    const string MIXER_MUSIC = "MusicVolume";
    const string MIXER_SFX = "SFXVolume";


    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        SFXSlider.onValueChanged.AddListener(ChangeSFXVolume);
        ScreenMode.onValueChanged.AddListener(SetScreenMode);
        ResolutionDropDown.onValueChanged.AddListener(SetResolution);
        SetResolutionSettings();
    }

    public void SetResolutionSettings()
    {
        resolutions = Screen.resolutions;
        ResolutionDropDown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        ResolutionDropDown.AddOptions(resolutionOptions);
        ResolutionDropDown.value = currentResolutionIndex;
        ResolutionDropDown.RefreshShownValue();
    }

    public void OpenSettings()
    {
        settingsBasic.Show();
    }

    public void CloseSettings()
    {
        settingsBasic.Hide();
    }

    private void ChangeMusicVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(volume) * 20);
        musicValue.text = (volume * 100).ToString();
    }

    private void ChangeSFXVolume(float volume)
    {
        audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(volume) * 20);
        soundValue.text = (volume * 100).ToString();
    }

    private void SetScreenMode(int value)
    {
        switch (value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            default:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
    }

    private void SetResolution(int value)
    {
        Resolution resolution = resolutions[value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }


}
