using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string name;
    public bool spawnOnScreen;
    public abstract void Spawn(Camera camera=null, Player player=null);
    public abstract bool GetSpawnOnScreen();
}
