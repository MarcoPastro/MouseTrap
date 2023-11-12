using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject myPrefab;
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private Player player;

    [SerializeField]
    private bool spawnOnScreen = true;
    [SerializeField]
    private GameObject parentGameObject;

    [SerializeField]
    private Timer timer;

    [SerializeField]
    private SlotMachine slots;

    private List<String> listOfEnemies=new List<String>();

    private bool loadedEnemiesFromSlots=false;

    public int numberOfWaves;
    private int numberOfCurrentWave;
    private List<Wave> createListOfWaves(int numberOfWaves){
        int numberOfEnemyThisWave=0;
        int n=listOfEnemies.Count;
        //check if odd and add to last if it is
        bool addOneToLast=false;
        if((numberOfWaves%2!=0 && n%2==0) ||(numberOfWaves%2==0 && n%2!=0)){
             addOneToLast=addOneToLast=true;
        }
        //shuffle array
        var rand = new System.Random();
        List<String> ShuffledListOfEnemies = listOfEnemies.OrderBy(x => rand.Next()).ToList();
        for(int i=0;i<n;i++){
            UnityEngine.Debug.Log("ShuffledListOfEnemies "+i+" = "+ShuffledListOfEnemies[i]);
        }
        List<Wave> results=new List<Wave>();
        int j=0;

        for(int i=0;i<numberOfWaves;i++){
            numberOfEnemyThisWave=n/numberOfWaves;
            if(i==numberOfWaves-1 && addOneToLast){
                numberOfEnemyThisWave=numberOfEnemyThisWave+1;
            }
            Wave w=new Wave(camera,player);
            w.CreateNewList();//to set the list to a new list
            for(int y=0;y<numberOfEnemyThisWave;y++){
                if(j<n){    //check for an error with odds length
                    w.AddEnemy(ShuffledListOfEnemies[j]);
                }
                j++;
            }
            results.Add(w);
        }
        return results;
    }


    //create function to transform dictonary in a list of enemies throughtn enemypool get enemies
    public void SlotsToList(List<(string s, int i)> d){
        List<String> r=new List<String>();
        foreach (var u in d)
        {
            
            for(int i=0;i<u.i;i++){
                r.Add(u.s);
            }
        }
        listOfEnemies=r;
        loadedEnemiesFromSlots=true;
    }

    public void SpawnAll(){
        List<Wave> w=createListOfWaves(1);
        
        w[0].SpawnEnemies();

        timer.TimerStart();//test
    }
    // Update is called once per frame
    void Update()
    {

        if(!loadedEnemiesFromSlots & slots.GetIfChecked()){

            SlotsToList(slots.GetFinalResults());
            numberOfWaves=1;//test
        }
        if(numberOfWaves>0 & slots.GetIfReadyToSpawn()){
            numberOfWaves--;
            SpawnAll();

        }
    }
    void Awake()
    {
        loadedEnemiesFromSlots=false;
        numberOfWaves=0;
    }
    /*void Start(){
        FalconEnemy f = new FalconEnemy(Resources.Load<EnemyScriptable>("Scriptable/Falcon"));
        listOfEnemies.Add(f);
        listOfEnemies.Add(f);
        listOfEnemies.Add(f);
        listOfEnemies.Add(f);
        listOfEnemies.Add(f);
        List<Wave> w=createListOfWaves(2);
        //UnityEngine.Debug.Log(w.Count);
        //UnityEngine.Debug.Log(w[0].GetListCount());
        //UnityEngine.Debug.Log(w[1].GetListCount());

        w[0].SpawnEnemies();
        
        w[1].SpawnEnemies();
    }*/
}
