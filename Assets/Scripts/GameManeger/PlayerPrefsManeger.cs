using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerPrefsManeger : MonoBehaviour
{
    public AudioMixer sfxMaster;
    public AudioMixer musicMaster;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("PlayerPrefs"))
        {
            PlayerPrefs.SetFloat("SFX", 0.8f);
            PlayerPrefs.SetFloat("Music", 0.7f);
            PlayerPrefs.SetInt("Quality", QualitySettings.GetQualityLevel());
            PlayerPrefs.SetFloat("Sens", 5);
            PlayerPrefs.SetInt("PlayerPrefs", 1);
        }

    }
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        sfxMaster.SetFloat("volume", Mathf.Log(PlayerPrefs.GetFloat("SFX")) * 20);
        musicMaster.SetFloat("volume", Mathf.Log(PlayerPrefs.GetFloat("Music")) * 20);
    }
}
