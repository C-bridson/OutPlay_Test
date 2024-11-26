using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject target_Flag;

    private int total_Targets = 0;
    private int current_Target = 0;
    private int target_Reached = 0;

    private Manager manager;

    private float movementSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
   
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<Manager>();


        target_Flag = manager.GetFlags().First();
        total_Targets = manager.GetFlags().Count();
    }

    void FixedUpdate()
    {
        if (target_Reached != total_Targets)
        {
            //move Character to current target flag
            Vector3 direction = (target_Flag.transform.position - this.gameObject.transform.position).normalized;
            rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
        }
    }





}
