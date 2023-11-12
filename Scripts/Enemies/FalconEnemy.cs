using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconEnemy : Enemy //change this is only on the spawner 
{

    public override void Spawn(Camera camera, Player player){
        GameObject newPrefabInstance = Instantiate(DictonaryOfEnemies.instance.GetEnemyPrefab(name), player.transform.position, Quaternion.identity);
            if (newPrefabInstance != null) //&& parentGameObject!=null)
            {
                //newPrefabInstance.transform.parent = parentGameObject.transform;
                //newPrefabInstance.transform.SetParent(parentGameObject.transform);
                Canvas canvas = newPrefabInstance.GetComponent<Canvas>();
                 if (canvas != null)
                    canvas.worldCamera = camera;
            }
    }
    public override bool GetSpawnOnScreen(){
        return spawnOnScreen;
    }
}
