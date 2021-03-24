using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPerson : MonoBehaviour
{
    public static List<GameObject> redPersonList = new List<GameObject>();

    public static List<GameObject> GetPesonList()
    {
        return redPersonList;
    }

    public static GameObject GetTarget()
    {
        int randomPerson = Random.Range(0, redPersonList.Count);
        return redPersonList[randomPerson];
    }

    public static void RemoveFromList(GameObject personToRemove)
    {
        redPersonList.Remove(personToRemove);
    }
    private void Awake()
    {
        redPersonList.Add(this.gameObject);
    }

}
