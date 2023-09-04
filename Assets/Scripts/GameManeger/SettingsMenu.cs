using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer sfxMaster;
    [SerializeField] AudioMixer musicMaster;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] TMP_Dropdown qualityDropdown;
    [SerializeField] TMP_InputField sensInputField;
    [SerializeField] GameObject pauseMenu, settingsMenu;

    private void Start()
    {
        sfxMaster.SetFloat("volume", Mathf.Log(PlayerPrefs.GetFloat("SFX")) * 20);
        musicMaster.SetFloat("volume", Mathf.Log(PlayerPrefs.GetFloat("Music")) * 20);
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));


        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        qualityDropdown.value = PlayerPrefs.GetInt("Quality");
        sensInputField.text = PlayerPrefs.GetFloat("Sens").ToString();
    }
    public void SFXVolume(float volume)
    {
        sfxMaster.SetFloat("volume", Mathf.Log(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
    }

    public void MusicVolume(float volume)
    {
        musicMaster.SetFloat("volume", Mathf.Log(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume);

    }

    public void Quality(int value)
    {
        QualitySettings.SetQualityLevel(value);
        PlayerPrefs.SetInt("Quality", value);
    }
    public void Sensitivity(string value)
    {
        PlayerPrefs.SetFloat("Sens", float.Parse(value));
    }

    public void Load()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Close()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

}