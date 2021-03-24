using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject[] persons;

    public void ButtonStart(){
        timer.SetActive(true);

        for(int i = 0; i < persons.Length; i++){
            if(persons[i].GetComponent<Archer>()){
                persons[i].GetComponent<Archer>().enabled = true;
            } else {
                persons[i].GetComponent<FootMan>().enabled = true;
            }
        }
        gameObject.SetActive(false);
    }
}
