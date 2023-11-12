using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject playMenu;
    [SerializeField]
    GameObject optionsMenu;
    public void PlayGame(){
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void Options(){
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Quit(){
        Application.Quit();
    }
}
