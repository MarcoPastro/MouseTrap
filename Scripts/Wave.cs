using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System;
using System.Linq;
public class Wave : MonoBehaviour
{
    private Camera camera;
    private Player player;
    private List<String> ListOfEnemies;//if you create = new List... here it doesn't work

    public Wave(Camera c,Player p){
        camera=c;
        player=p;
    }
    public int GetListCount(){
        return ListOfEnemies.Count;
    }
    public void AddEnemy(String e){
        ListOfEnemies.Add(e);
    }
    public void CreateNewList(){
        ListOfEnemies=new List<String>();
    }
    public void SpawnEnemies(){
        foreach(String e in ListOfEnemies){
            
            if(DictonaryOfEnemies.instance.GetEnemySpawnOnScreen(e)){
                GameObject newPrefabInstance = Instantiate(DictonaryOfEnemies.instance.GetEnemyPrefab(e), player.transform.position, Quaternion.identity);
                if (newPrefabInstance != null) //&& parentGameObject!=null)
                {
                //newPrefabInstance.transform.parent = parentGameObject.transform;
                //newPrefabInstance.transform.SetParent(parentGameObject.transform);
                    Canvas canvas = newPrefabInstance.GetComponent<Canvas>();
                    if (canvas != null)
                        canvas.worldCamera = camera;
                }
            }else{
                if(DictonaryOfEnemies.instance.GetEnemySpawnPosition(e)==null){
                    Instantiate(DictonaryOfEnemies.instance.GetEnemyPrefab(e), player.transform.position, Quaternion.identity);
                }else{
                    Instantiate(DictonaryOfEnemies.instance.GetEnemyPrefab(e), DictonaryOfEnemies.instance.GetEnemySpawnPosition(e).position, Quaternion.identity);
                }
            }
            
        }
    }
}
