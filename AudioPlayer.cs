using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] Slider volumeSlider;
        

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerPrefs.SetFloat("musicVolume", 0.3f);
    }  
    
    
    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.3f);
            Load();            
        }

        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }    
    
}
