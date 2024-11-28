using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> audioClip;


    [SerializeField]
    private List<GameObject> flags = new List<GameObject>();

    // a count of the total flags from the start of the game
    private int totalTargets = 0;
    public int TotalTargets
    {
        get { return totalTargets; }
        set { totalTargets = value; }
    }
    // a count of the targets that have been reached
    private int targetsReached = 0;
    public int TargetsReached
    {
        get { return targetsReached; }
        set { targetsReached = value; }
    }
    // what target is currently being moved too
    [SerializeField]
    private GameObject currentTarget;
    public GameObject CurrentTargetFlag
    {
        get { return currentTarget; }
        set { currentTarget = value; }
    }
    // a stop measure to prevent the player from continuing to move after ending the game
    private bool canMove = true;
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    // the camera controller script
    private CameraController cameraController;

    // the state of the game, true for the end of the game, false active gameplay.
    private bool gameEnded = false;
    public bool GameEnd
    {
        get { return gameEnded; }
        set { gameEnded = value; }
    }


    private void Awake()
    {
        TotalTargets = flags.Count;

        CurrentTargetFlag = flags.FirstOrDefault();

        cameraController = FindObjectOfType<CameraController>();

        audioSource = FindObjectOfType<AudioSource>();
    }


    /// <summary>
    /// taking the object that was collided with it removes the object from the list
    /// checks if that was the last object then ends the game
    /// else it sets the next target
    /// </summary>
    /// <param name="obj"></param>
    public void RemoveFlag(GameObject obj)
    {
        flags.Remove(obj); 

        if (flags.Count == 0) 
        {
            CurrentTargetFlag = null; 
            cameraController.SwapParent(); 
            GameEnd = true; 
            if(gameEnded)
            {
                PlaySoundEffect("Ta da");

            }
        }
        else
        {
          
            CurrentTargetFlag = flags.FirstOrDefault();
        }
    }

    /// <summary>
    /// update the based on which object was hit.
    /// flags remove the what was collided from the list
    /// 
    /// obstacles end the game
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="tag"></param>
    public void ObjectCollision(GameObject collision, string tag)
    {
        if (tag == "Flag")
        {
            RemoveFlag(collision);
        }
        else if (tag == "Obstacle")
        {
            cameraController.SwapParent();
            GameEnd = true ;
            PlaySoundEffect("wamp wamp");
        }
    }

    /// <summary>
    /// when called, plays the sound effect based on the sound clips name
    /// </summary>
    /// <param name="clipName"></param>
    private void PlaySoundEffect(string clipName)
    {
        foreach (var soundclip in audioClip)
        {
            if (soundclip.name == clipName)
            {
                audioSource.clip = soundclip;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("sound Clip not found");
            }
        }
    }



    }
