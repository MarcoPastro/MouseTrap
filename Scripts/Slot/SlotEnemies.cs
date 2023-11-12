using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SlotEnemies : Slot<string>
{
    private List<string> sprites;
    
    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private Image rend;

    [SerializeField]
    private Transform start;

    [SerializeField]
    private Transform finish;

    [SerializeField]
    private Transform center;


    private float speed=5f;


    private float initialTime=1f;


    private float waitTime=1f;

    private string result="";

    private bool stopped;

    public void SetList(List<string> l){
        sprites=l;
    }
    
    public override void Roll(){
        StartCoroutine(RollSlice());
    }
    // Coroutine that rolls the dice
    private IEnumerator RollSlice()
    {
        int random = 0;

        int finalSide = 0;

        float speedLog=speed;

        int r=UnityEngine.Random.Range(5,20); //number of slides
        for (int i = 1; i <= r; i++)
        {
            // Pick up random value from 0 to x (x-1 inclusive)
            random = UnityEngine.Random.Range(0, sprites.Count);
            
            obj.transform.position=start.transform.position;
            rend.sprite = DictonaryOfEnemies.instance.GetEnemySlotSprite(sprites[random]);

            if(i<r){

                //waitTime=waitTime+Math.Log(i, r);
                
                //UnityEngine.Debug.Log(waitTime+"=w s="+speedLog);
                yield return StartCoroutine(Slice(start.transform.position,finish.transform.position,speed-(i/r)*(speed/2),initialTime));
                yield return new WaitForSeconds((i/r)*waitTime);
                //speed=speed-MathF.Log(i,r)*speed;
            }else{
                yield return StartCoroutine(Slice(start.transform.position,center.transform.position,speed-(i/r)*(speed/2),initialTime));
            }
            
            yield return new WaitForSeconds((i/r)*waitTime);

        }
        
        result = sprites[random];
        stopped=true;
        yield return result;
    }

    private IEnumerator Slice(Vector3 a, Vector3 b,float speed,float time)
    {
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        
        float elapsedTime = 0;
         
        
        //while (!(rend.transform.position == finish.transform.position))
        while (elapsedTime < time)
        {
            elapsedTime += step; // Goes from 0 to 1, incrementing by step each time
            obj.transform.position = Vector3.Lerp(a, b, elapsedTime); // Move objectToMove closer to b
            yield return null;
            //rend.transform.position=Vector3.MoveTowards(rend.transform.position, finish.transform.position, speed * Time.fixedDeltaTime);
            //rend.transform.position=Vector3.Lerp(rend.transform.position, finish.transform.position, speed * (elapsedTime / time));
            //elapsedTime += Time.deltaTime;
            //yield return null;
        }
        obj.transform.position=b;
        yield return null;
    }
    public string GetResult(){
        return result;
    }
    public bool IsStopped(){
        return stopped;
    }
    void Awake() {
        stopped=false;
    }
}
