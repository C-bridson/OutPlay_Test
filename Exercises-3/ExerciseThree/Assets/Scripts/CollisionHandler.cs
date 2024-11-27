using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.VersionControl;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
  
    // the visual body of the player
    [SerializeField]
    private GameObject body;

    // the manager script thats controlling the state of the game
    private Manager manager;

    private void Awake()
    {
        if (body == null)
        {
            UnityEngine.Debug.LogWarning("Body GameObject Not assigned");
        }

 
        manager = FindObjectOfType<Manager>();
        if (manager == null)
        {
            UnityEngine.Debug.LogWarning("Could Not Find Manager");
        }
    }


    /// <summary>
    /// upon entering trigger checks for 
    /// Flag 
    /// or
    /// Obstacle
    /// 
    /// flags update the total and change the target, once all flags have been reached end the game sequence.
    /// 
    /// disable movement and end game.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
  
        if (other.gameObject.CompareTag("Flag"))
        {
        
            manager.TargetsReached++;

     
            if (manager.TargetsReached < manager.TotalTargets)
            {
                other.transform.gameObject.SetActive(false);
                manager.ObjectCollision(other.gameObject, "Flag");
            }
            else
            {
     
                body.SetActive(false);
                other.transform.gameObject.SetActive(false);
                manager.ObjectCollision(other.gameObject, "Flag");
            }


            // play sounds
            // play particles
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            // Stop player movement
            manager.CanMove = false;
            // Deactivate the body
            body.SetActive(false);
            manager.ObjectCollision(null, "Obstacle");
            // play sounds
            // play particles
        }
    }

}
