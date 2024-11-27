using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    private GameObject player;

    private GameObject mapCenter;

    [SerializeField]
    private float rotationSpeed = 50f;

    [SerializeField]
    private float smoothing = 5f;

    private Quaternion desiredRotation;

    private Manager manager;

    /// <summary>
    /// set variables at start
    /// </summary>
    private void Awake()
    {
        player = this.transform.parent.gameObject;
        if (player == null)
        {
            Debug.LogWarning("Player object unassigned");
        }

        manager = FindObjectOfType<Manager>();

        if (manager == null)
        {
            Debug.LogWarning("Manager not found.");
        }

        mapCenter = manager.gameObject;
    }

    // changes the camera parent object to the center of the map
    public void SwapParent()
    {
        this.gameObject.transform.parent = mapCenter.transform;
    }
    /// <summary>
    /// Pivots the camera round the center of the map after the game ends regardless of outcome
    /// </summary>
    public void PivotMapCenter()
    {
        transform.RotateAround(mapCenter.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);

        desiredRotation = Quaternion.LookRotation(mapCenter.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothing * Time.deltaTime);
    }


    private void FixedUpdate()
    {
        if (manager.GameEnd == true && manager.TargetsReached >= manager.TotalTargets)
        {
            PivotMapCenter();
        }
        else if (manager.GameEnd == true && manager.TargetsReached < manager.TotalTargets)
        {
            PivotMapCenter();
        }
    }

}
