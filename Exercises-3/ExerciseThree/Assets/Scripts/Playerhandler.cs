using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject body;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flag"))
        {
            Debug.Log("Collision with Flag");
            //deactive body
            body.SetActive(false);
            //play sounds
            //play particals

        }

        if (collision.gameObject.CompareTag("Obstacle"))
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
