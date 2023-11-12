using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundPoint : MonoBehaviour
{
    [SerializeField]
    private float attackDelay = 1f;

    [SerializeField]
    private float speed = 1f;
    public Rigidbody2D rb;
    public Animator animator;

    [SerializeField]
    private Canvas parentCanvas;

    [SerializeField]
    private bool active = false;

    [SerializeField]
    private int minBounce = 5, maxBounce = 20;

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private Transform exitWaypoint;

    [SerializeField]
    private Transform pointOnPlayerWaypoint;

    private Transform target;

    private int waypointIndex = 0;

    private int countdown;

    private void Start()
    {
        SetCountDown(minBounce, maxBounce);
        Activate();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (active)
        {
            
            if (target != null)
            {
                
                if (countdown > 0)
                {
                    
                    PreAttack();
                }
                else
                {
                    
                    StartAttack();
                }
            }
        }
    }
    void Activate()
    {
        active = true;
        //target = waypoints[0];
        target = waypoints[Random.Range(0, waypoints.Length - 1)];
    }
    void PreAttack()
    {
        if (!CheckIfinPosition())
        {
            MoveToWayPoint(target);
        }
        else
        {
            NextWayPoint();
        }
    }
    void StartAttack()
    {
        new WaitForSeconds(attackDelay);
        parentCanvas.renderMode = RenderMode.WorldSpace;
        Attack();
    }
    public void Attack()
    {
        MoveToWayPoint(pointOnPlayerWaypoint);
    }
    private bool CheckIfinPosition()
    {
        bool r = true;
        
        if (target != null)
        {
            //r = rb.position.x == target.transform.position.x && rb.position.y == target.transform.position.y;
            //r = transform.position.x == target.transform.position.x && transform.position.y == target.transform.position.y;
            r = transform.position == target.transform.position;
            
            if (r)
            {
                if(countdown==0){
                    active=false;
                }else{
                    countdown = countdown - 1;
                }               
            }
        }
        return r;
    }
    void SetCountDown(int min,int max)
    {
        countdown=Random.Range(min, max);
    }
    void NextWayPoint()
    {
        if (waypoints.Length > 0)
        {
            if(waypointIndex > waypoints.Length - 1)
            {
                waypointIndex = 0;
            }
            target = waypoints[waypointIndex];
            waypointIndex+=1;
            
        }
    }
    void MoveToWayPoint(Transform waypoint)
    {
        //Vector2 t = new Vector2(waypoint.transform.position.x, waypoint.transform.position.y);
        //rb.MovePosition(Vector2.MoveTowards(rb.position, t, speed * Time.fixedDeltaTime));
        transform.position=Vector3.MoveTowards(transform.position, waypoint.transform.position, speed * Time.fixedDeltaTime);
    }
}
