using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPlayerDetector : MonoBehaviour
{
    public SpawnEnemy spawnEnemy;
    public bool PlayerDetected { get; private set; }

    public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;

    [Header("OverlapBox parameters")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectoSize = Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float detectionDelay = 0.3f;


    [SerializeField]
    private LayerMask detectorLayerMask;

    [Header("Gizmo parameters")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetectedColor = Color.red;
    public bool showGizmos = true;


    private GameObject target;

    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            PlayerDetected = target != null;
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }

    public void PerformDetection()
    {
        Collider2D collider = 
            Physics2D.OverlapBox(
                (Vector2)detectorOrigin.position + detectorOriginOffset, detectoSize, 0, detectorLayerMask);
        if (collider != null)
        {
            Target = collider.gameObject;
            SpawnEnemy();
        }
        else
        {
            Target = null;
        }
    }

    private void SpawnEnemy()
    {
        spawnEnemy.Spawn();
    }

    private void OnDrawGizmos()
    {
        if (showGizmos && detectorOrigin != null)
        {
            Gizmos.color = gizmoIdleColor;
            if (PlayerDetected)
                Gizmos.color = gizmoDetectedColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectoSize);
        }
    }
}
