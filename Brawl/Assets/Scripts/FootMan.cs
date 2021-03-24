using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMan : Person
{
    void Awake()
    {
        DefaultValues();
    }

    private void DefaultValues(){
        speed = 2f;
        radiusToAttack = 1f;
        health = 10f;
        startHealth = health;
        damage = 1f;
    }
}
