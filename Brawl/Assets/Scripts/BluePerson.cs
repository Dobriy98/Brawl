using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePerson : MonoBehaviour
{
    public static List<GameObject> bluePersonList = new List<GameObject>();
    public static List<GameObject> GetPesonList()
    {
        return bluePersonList;
    }
    public static GameObject GetTarget()
    {
        int randomPerson = Random.Range(0, bluePersonList.Count);
        return bluePersonList[randomPerson];
    }

    public static void RemoveFromList(GameObject personToRemove)
    {
        bluePersonList.Remove(personToRemove);
    }
    private void Awake()
    {
        bluePersonList.Add(this.gameObject);
    }
}
