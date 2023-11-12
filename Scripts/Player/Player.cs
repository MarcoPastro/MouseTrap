using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    private bool death;
    // Start is called before the first frame update
    void Start()
    {
        death = false;
        animator.SetBool("Death", death);
        EventGame.current.onDeathTrigger+=Death;
    }

    public void Death()
    {
        death = true;
        animator.SetBool("Death", death);
    }

    private void OnDestroy(){
        EventGame.current.onDeathTrigger-= Death;
    }
}
