using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    float currentTime=0f;
    float startingTime=10f;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    public void TimerStart(){
        currentTime=startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime-=1*Time.deltaTime;
        textMeshPro.text=currentTime.ToString("0");
        if(currentTime<=0){
            currentTime=0;
        }
    }
}
