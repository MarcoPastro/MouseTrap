using System.Diagnostics;
using UnityEngine;
using System.Collections.Generic;

public class DictonaryOfEnemies : MonoBehaviour
{
    public static DictonaryOfEnemies instance;
    public List<EnemyScriptable> lScriptable;
    public Dictionary<string, EnemyScriptable> enemyPrefabs = new Dictionary<string, EnemyScriptable>();

    private void Awake() //singleton
    {
        if (instance == null)
        {
            instance = this;
            LoadEnemyPrefabs();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadEnemyPrefabs()
    {
        foreach (EnemyScriptable prefab in lScriptable)
        {
            enemyPrefabs.Add(prefab.name, prefab);
        }
    }

    public GameObject GetEnemyPrefab(string name)
    {
        if (enemyPrefabs.ContainsKey(name))
        {
            return enemyPrefabs[name].prefab;
        }
        else
        {
            UnityEngine.Debug.LogError("Enemy prefab not found with name: " + name);
            return null;
        }
    }

    public Sprite GetEnemySlotSprite(string name)
    {
        
        if (enemyPrefabs.ContainsKey(name))
        {
            return enemyPrefabs[name].slotArtwork;
        }
        else
        {
            UnityEngine.Debug.LogError("Enemy slotsprite not found with name: " + name);
            return null;
        }
    }
    public bool GetEnemySpawnOnScreen(string name)
    {
        if (enemyPrefabs.ContainsKey(name))
        {
            return enemyPrefabs[name].spawnOnScreen;
        }
        else
        {
            UnityEngine.Debug.LogError("Enemy spawnOnScreen not found with name: " + name);
            return false;
        }
    }
    public Transform GetEnemySpawnPosition(string name)
    {
        if (enemyPrefabs.ContainsKey(name))
        {
            return enemyPrefabs[name].spawnPosition;
        }
        else
        {
            UnityEngine.Debug.LogError("Enemy spawnPosition not found with name: " + name);
            return null;
        }
    }
}