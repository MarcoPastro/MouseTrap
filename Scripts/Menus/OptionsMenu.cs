using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject playMenu;
    [SerializeField]
    GameObject optionsMenu;

    public AudioMixer audioMixer;
    public void SetVolume(float volume){
            audioMixer.SetFloat("volume", volume);
    }
    public void Return(){
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
}
