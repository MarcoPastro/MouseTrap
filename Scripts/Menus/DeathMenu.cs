using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    [SerializeField]
    GameObject deathMenu;
    
    void Start()
    {
        EventGame.current.onDeathTrigger+=Pause;
    }

    public void Pause(){
        deathMenu.SetActive(true);
        Time.timeScale=0f;
    }

    
    public void Home(int sceneID){
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
    }
    private void OnDestroy(){
        EventGame.current.onDeathTrigger-= Pause;
    }
}
