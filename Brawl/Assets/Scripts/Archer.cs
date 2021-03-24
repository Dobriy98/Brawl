using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Person
{
    void Awake()
    {
        DefaultValues();
    }

    private void DefaultValues(){
        speed = 1;
        radiusToAttack = 4;
        health = 6;
        startHealth = health;
        damage = 2;
    }
}
