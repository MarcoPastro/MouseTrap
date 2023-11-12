using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotMachine : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    List<SlotNumbers> slotsnumber;
    [SerializeField]
    List<SlotEnemies> slotsenemy;

    public bool check;
    public bool onRolls;
    public bool readyToSpawn;
    private List<(string, int)> results;
    /*public List<Sprite> Rolls(){
        List<Sprite> results =new List<Sprite>();
        for(int i=0;i<slots.Count;i++){
            results.Add(slots[i].Roll());
        }
        return results;
    }*/
    private bool checkStop(){
        bool r=true;
        for(int i=0;i<slotsnumber.Count;i++){
            r=r&slotsenemy[i].IsStopped();
            r=r&slotsnumber[i].IsStopped();
        }
        return r;
    }
    public void Rolls(){

        for(int i=0;i<slotsnumber.Count;i++){

            slotsenemy[i].Roll();
            slotsnumber[i].Roll();

        }
        onRolls=true;
    }
    public List<(string, int)> GetResults(){
        List<(string, int)> r = new List<(string, int)>();
        for(int i=0;i<slotsnumber.Count;i++){

            string s =slotsenemy[i].GetResult();
            int n =slotsnumber[i].GetResult();
            r.Add((s,n));

        }
        return r;
    }
    public void setSlots(List<string> lForEnemies,List<int> lForNum){
        for(int i=0;i<slotsnumber.Count;i++){

            slotsenemy[i].SetList(lForEnemies);
            slotsnumber[i].SetList(lForNum);

        }
    }

    private void checkResults(){
        results=GetResults();
        onRolls=false;
        check=true;
    }
    public bool GetIfChecked(){
        return check;
    }
    public bool GetIfReadyToSpawn(){
        return readyToSpawn;
    }
    public List<(string, int)> GetFinalResults(){
        return results;
    }
    void Update(){
        if(!check){
            if(checkStop()){
                checkResults();
            }
        }
        buttonInteractiveManager();
    }
    private void buttonInteractiveManager(){
        if(button.interactable & onRolls){
            button.interactable = false;
        }else if(!button.interactable & !onRolls){
            button.interactable = true;
        }
    }
    public void DisebleSlotMachine(){
        readyToSpawn=true;
        gameObject.SetActive(false);
        
    }
    void Start()
    {
        /*List<string> lForEnemies=new List<string>();
        lForEnemies.Add("Falcon");
        lForEnemies.Add("MouseTrap");
        List<int> lForInt=new List<int>();
        lForInt.Add(1);
        lForInt.Add(2);
        lForInt.Add(3);*/
        setSlots(Values.listEnemies,Values.listNumber);
    }
    void Awake() {
        check=false; //set here to false or it will be always false if it's done in the top
        onRolls=false;
        readyToSpawn=false;
    }
}
