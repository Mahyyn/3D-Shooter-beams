using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioClip mainLoop;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        { 
            audioSource.clip = mainLoop;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

}
