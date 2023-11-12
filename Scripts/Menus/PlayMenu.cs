using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject playMenu;
    [SerializeField]
    GameObject optionsMenu;

    public void Easy(){
        List<int> li=new List<int>();
        List<string> ls=new List<string>();

        li.Add(2);
        li.Add(3);
        li.Add(4);

        ls.Add("Falcon");
        ls.Add("MouseTrap");

        Values.listNumber=li;
        Values.listEnemies=ls;

        SceneManager.LoadScene("Game");
    }
    public void Normal(){
        List<int> li=new List<int>();
        List<string> ls=new List<string>();

        li.Add(5);
        li.Add(6);
        li.Add(7);

        ls.Add("Falcon");
        ls.Add("MouseTrap");

        Values.listNumber=li;
        Values.listEnemies=ls;

        SceneManager.LoadScene("Game");
    }
    public void Hard(){
        List<int> li=new List<int>();
        List<string> ls=new List<string>();

        li.Add(8);
        li.Add(9);
        li.Add(10);

        ls.Add("Falcon");
        ls.Add("MouseTrap");   

        Values.listNumber=li;
        Values.listEnemies=ls;

        SceneManager.LoadScene("Game");
    }
    public void Return(){
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }
}
