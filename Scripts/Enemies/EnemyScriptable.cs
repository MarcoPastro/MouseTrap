using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="new Enemy", menuName = "MouseTrap/Enemy")]
public class EnemyScriptable : ScriptableObject
{
    public string name;

    public GameObject prefab;

    public Sprite artwork;

    public Sprite slotArtwork;

    public bool spawnOnScreen;

    public Transform spawnPosition=null;
}
