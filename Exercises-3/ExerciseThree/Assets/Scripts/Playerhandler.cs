using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject body;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flag"))
        {
            this.GetComponent<Movement>().target_Reached++;
            Debug.Log("Collision with Flag");
            //deactive body
            if (this.GetComponent<Movement>().target_Reached < this.GetComponent<Movement>().total_Targets)
            {

                other.transform.gameObject.SetActive(false);
                this.GetComponent<Movement>().UpdateTarget();
            }
            else
            {
                body.SetActive(false);
            }
        
            //play sounds
            //play particals

        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with Obstacle");
            //deactive body
            this.gameObject.GetComponent<Movement>().CanMove = false;
            body.SetActive(false);
            //play sounds
            //play particles

        }

    }
}
