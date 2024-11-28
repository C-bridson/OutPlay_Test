using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    //the list of sound clips to play
    [SerializeField]
    private List<AudioClip> audioClip;

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private MenuSystem menu;

    [SerializeField]
    private ObstacleSpawner obstacleSpawner;

    private CollisionHandler collisionHandler;

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
    private bool canMove = false;
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    // the camera controller script
    private CameraController cameraController;

    // the state of the game, true for the end of the game, false active gameplay.
    [SerializeField]
    private bool gameEnded = false;
    public bool GameEnd
    {
        get { return gameEnded; }
        set { gameEnded = value; }
    }


    private void Awake()
    {
        TotalTargets = flags.Count;

        CurrentTargetFlag = flags[targetsReached];

        InitializeComps();

    }

    // gather the requirements to insure the exist
    void InitializeComps()
    {
        cameraController = FindObjectOfType<CameraController>();
        CheckComponent(cameraController, "Camera Controller");

        audioSource = FindObjectOfType<AudioSource>();
        CheckComponent(audioSource, "Audio Source");

        particles = FindObjectOfType<ParticleSystem>();
        CheckComponent(particles, "Particle System");

        menu = FindAnyObjectByType<MenuSystem>();
        CheckComponent(menu, "Menu System");

        collisionHandler = FindAnyObjectByType<CollisionHandler>();
        CheckComponent(collisionHandler, "Collision Handler");

        obstacleSpawner = FindAnyObjectByType<ObstacleSpawner>();
        CheckComponent(obstacleSpawner, "Obstacle Spawner");
    }

    //checks if the component is not null, reports if so.
    void CheckComponent(object comp, string compName)
    {
        if (comp == null)
        {
            Debug.LogWarning($"{compName} is not a assigned");
        }
    }

    /// <summary>
    /// checks if that was the last target then ends the game
    /// else it sets the next target
    /// </summary>
    public void NextFlag()
    { 

        if (targetsReached == totalTargets) 
        {
            CurrentTargetFlag = null; 
            GameEnd = true;
            cameraController.SwapCamera();
            if (gameEnded)
            {
                menu.ShowEndScreen("Win");
                PlaySoundEffect("Ta da");
                particles.Play();
            }
        }
        else
        {
            if(targetsReached < flags.Count)
                CurrentTargetFlag = flags[targetsReached];
        }
    }

    /// <summary>
    /// update the based on which object was hit.
    /// flags hit change the target for the player.
    /// 
    /// obstacles end the game
    /// </summary>
    /// <param name="collision"></param>
    /// <param name="tag"></param>
    public void ObjectCollision(string tag)
    {
        if (tag == "Flag")
        {

            NextFlag();
        }
        else if (tag == "Obstacle")
        {
            cameraController.SwapCamera();
            GameEnd = true ;
            menu.ShowEndScreen("Lose");
            PlaySoundEffect("wamp wamp");
            particles.Play();
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
                break;
            }
        }
    }

    /// <summary>
    /// Reset game world state.
    /// </summary>

    public void NewGame()
    {
        GameEnd = false;
        obstacleSpawner.ResetObstaclePool();
        particles.Stop();
        particles.Clear();
        canMove = true;
        collisionHandler.ResetPlayerBody();

        targetsReached = 0;
        currentTarget = flags[targetsReached];

        foreach (var item in flags)
        {
            item.SetActive(true);
        }

        cameraController.SwapCamera();

    }


    }
