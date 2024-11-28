using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Camera worldCamera;

    private Manager manager;

    /// <summary>
    /// set variables at start
    /// </summary>
    private void Awake()
    {
        manager = FindObjectOfType<Manager>();

        if (manager == null)
        {
            Debug.LogWarning("Manager not found.");
        }
    }

    /// <summary>
    /// Change which camera is being displayed 
    /// Player camera, attached to the player it followes where ever the player gose
    /// world camera, show a over view of the whole map on win/lose.
    /// </summary>
    public void SwapCamera()
    {
        if (manager.GameEnd == true)
        {
            playerCamera.enabled = false;
            worldCamera.enabled = true;
            
        }
        else
        {
            worldCamera.enabled = false;
            playerCamera.enabled = true;
   
        }
    }
}
