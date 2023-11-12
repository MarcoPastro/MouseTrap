using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    private List<List<GameObject>> enemies;

    public void InitializePool(Dictionary<string, int> poolSizes)
    {
        enemies = new List<List<GameObject>>();
        int i = 0;
        foreach (var item in poolSizes)
        {
            GameObject prefab = DictonaryOfEnemies.instance.GetEnemyPrefab(item.Key);
            if (prefab != null)
            {
                enemies.Add(new List<GameObject>());
                int poolSize = item.Value;
                for (int j = 0; j < poolSize; j++)
                {
                    GameObject enemy = Instantiate(prefab);
                    enemy.SetActive(false);
                    enemies[i].Add(enemy);
                }
                i++;
            }
            else
            {
                Debug.LogError("Enemy prefab not found with name: " + item.Key);
            }
        }
    }

    public GameObject GetEnemy(string name)
    {
        int typeIndex = -1;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].Count > 0 && enemies[i][0].name == name)
            {
                typeIndex = i;
                break;
            }
        }

        if (typeIndex == -1)
        {
            Debug.LogError("Enemy type not found in pool: " + name);
            return null;
        }

        for (int i = 0; i < enemies[typeIndex].Count; i++)
        {
            if (!enemies[typeIndex][i].activeInHierarchy)
            {
                enemies[typeIndex][i].SetActive(true);
                return enemies[typeIndex][i];
            }
        }

        GameObject newEnemy = Instantiate(DictonaryOfEnemies.instance.GetEnemyPrefab(name));
        enemies[typeIndex].Add(newEnemy);
        return newEnemy;
    }
}
