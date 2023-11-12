using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDetector : Detector
{
    [SerializeField]
    private float detectnRadius = 2;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private bool showGizmos = true;

    Collider2D[] colliders;

    public override void Detect(AIData aiData)
    {
        //create a circle colliders
        //                                      center              radius         layer
        colliders = Physics2D.OverlapCircleAll(transform.position, detectnRadius, layerMask);
        aiData.obstacles = colliders;
    }

    private void OnDrawGizmos()
    {
        if (showGizmos == false) return;
        if(Application.isPlaying && colliders != null)
        {
            Gizmos.color = Color.red;
            foreach(Collider2D obstacleCollider in colliders)
            {
                Gizmos.DrawSphere(obstacleCollider.transform.position, 0.2f);
            }
        }
    }
}
