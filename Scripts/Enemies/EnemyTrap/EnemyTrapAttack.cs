using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrapAttack : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator anim;
    private bool triggered=false, active=true, damage;
    private Player target;

    [SerializeField]
    private LayerMask attackMask;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (active) {
            if (collision.tag == "Player")
            {
                target = collision.GetComponent<Player>();
                damage = true;
                if (!triggered)
                {
                    StartCoroutine(ActivateTrap());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            damage = false;
            target = null;
        }
    }
    public void Attack(GameObject player)
    {
        if (damage == true && target!=null)
        {
            target.Death();
        }
    }
    private IEnumerator ActivateTrap()
    {
        triggered = true;
        yield return new WaitForSeconds(activationDelay);
        anim.SetBool("Triggered", true);
        anim.SetBool("Active", false);
    }
}
