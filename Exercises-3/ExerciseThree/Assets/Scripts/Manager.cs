using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> flags = new List<GameObject>();

    public List<GameObject> GetFlags()
    {
        return flags;
    }

    public void RemoveFlag(GameObject obj)
    {
        flags.Remove(obj);
    }

}
