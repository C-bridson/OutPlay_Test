using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;


    // pool size
    [SerializeField]
    private int obstacleMax;

    private List<GameObject> obstaclesPool = new List<GameObject>();


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


    /// <summary>
    /// taking from the range and the prefab we iterate instantiations of the Obstacle, to a set max. 
    /// we set their parent to a blank object to act as a folder.
    /// 
    /// deactivate them
    /// and add to pool
    /// </summary>
    private void Awake()
    {
        obstacleFolder = GameObject.FindWithTag("Obstacle");

        for (int i = 0; i < obstacleMax; i++)
        {
            GameObject temp = Instantiate(obstaclePrefab, GetRandomPos(), Quaternion.identity) ;
            temp.transform.parent = obstacleFolder.transform;

            temp.SetActive(true);
            obstaclesPool.Add(temp);

        }

    }

    /// <summary>
    /// random positions generator based on set parameters 
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(obstacleArea.min, obstacleArea.max), 0.5f, Random.Range(obstacleArea.min, obstacleArea.max));
    }


    /// <summary>
    /// loops through List and switches objects off and on, while changing their positions 
    /// </summary>
    public void ResetObstaclePool()
    {
        foreach (var item in obstaclesPool)
        {
            if (item != null)
            {
                item.SetActive(false);
                item.transform.position = GetRandomPos();
                item.SetActive(true);
            }
        }


    }

}
