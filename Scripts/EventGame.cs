using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGame : MonoBehaviour
{
    public static EventGame current;

    private void Awake() {
        current=this;
    }

    public event Action onDeathTrigger;
    public void DeathTrigger(){
        if(onDeathTrigger!=null){
            onDeathTrigger();
        }
    }
}
