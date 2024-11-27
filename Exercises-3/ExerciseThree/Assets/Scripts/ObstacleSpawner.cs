using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private int obstacleMax;


    /// <summary>
    /// the spawn range of obstacles
    /// </summary>

    [SerializeField]
    private ObstacleArea obstacleArea;

    [System.Serializable]
    public struct ObstacleArea
    {
        public int min;
        public int max;

        public ObstacleArea(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }

    [SerializeField]
    private GameObject obstacleFolder;


    private void Awake()
    {
        obstacleFolder = GameObject.FindWithTag("Obstacle");
    }

    /// <summary>
    /// taking from the range and the prefab we iterate instantiations of the Obstacle, to a set max. 
    /// we set their parent to a blank object to act as a folder.
    /// </summary>
    private void Start()
    {
  
        for (int i = 0; i < obstacleMax; i++)
        {
            GameObject temp = Instantiate(obstaclePrefab, new Vector3(Random.Range(obstacleArea.min, obstacleArea.max), 0.5f, Random.Range(obstacleArea.min, obstacleArea.max)), Quaternion.identity);
            temp.transform.parent = obstacleFolder.transform;
        }
    }




}
