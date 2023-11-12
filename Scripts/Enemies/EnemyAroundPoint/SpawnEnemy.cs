using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject myPrefab;
    public Camera camera;
    public Player player;

    [SerializeField]
    private bool spawnOnScreen = true;
    public GameObject parentGameObject;

    public void Spawn()
    {
        if (spawnOnScreen)
        {
            GameObject newPrefabInstance = Instantiate(myPrefab, transform.position, Quaternion.identity);
            if (newPrefabInstance != null && parentGameObject!=null)
            {
                //newPrefabInstance.transform.parent = parentGameObject.transform;
                //newPrefabInstance.transform.SetParent(parentGameObject.transform);
                Canvas canvas = newPrefabInstance.GetComponent<Canvas>();
                 if (canvas != null)
                    canvas.worldCamera = camera;
            }
        }
    }
}
