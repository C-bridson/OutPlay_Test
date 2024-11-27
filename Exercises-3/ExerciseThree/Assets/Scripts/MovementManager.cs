using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    // the manager script thats controlling the state of the game
    private Manager manager;

    // adjustable speed in engine
    [SerializeField, Range(1f, 100f)]
    private float movementSpeed = 5f;

    private Rigidbody rb;

  
    /// <summary>
    /// set variables on awaken
    /// </summary>
    private void Awake()
    {
     
        rb = GetComponent<Rigidbody>();

     
        if (rb == null)
        {
            Debug.LogError("Rigidbody not assigned");
        }

 
        manager = FindObjectOfType<Manager>();


        if (manager == null)
        {
            Debug.LogError("Manager script not assigned");
        }
    }

    /// <summary>
    /// if the player is allowed to move and they haven't reached all targets keep them moving.
    /// </summary>
    void FixedUpdate()
    {
  
        if (manager.TargetsReached != manager.TotalTargets && manager.CanMove)
        {  
            if (manager.CurrentTargetFlag != null)
            {
                Move();
            }
            else
            {
                Debug.LogWarning("Target Flag is unassigned");
            }
        }
    }

    /// <summary>
    /// Move the player towards the current target flag and rotate to face direction.
    /// </summary>
    void Move()
    {
        Vector3 targetPosition = manager.CurrentTargetFlag.transform.position;

        Vector3 direction = (targetPosition - this.gameObject.transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 5f);

        rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
    }


}
