using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;
using TMPro;

public class ButtonStart : MonoBehaviour
{
    [SerializeField]
    private SlotMachine slots;

    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    public void CallFunction()
    {
        if(slots.check){
            slots.DisebleSlotMachine();
        }else{
            slots.Rolls();
            textMeshPro.text="Start";
        }
    }
}