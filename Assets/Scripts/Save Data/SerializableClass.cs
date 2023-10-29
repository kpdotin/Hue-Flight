using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SerializableClass
{
    public int Orbs;
    public int LevelsCompleted;
    public Dictionary<int, bool> FlightsOwned = new Dictionary<int, bool>()
    {
        {1 ,true},
        {2 ,false},
        {3 ,false},
        {4 ,false},
        {5 ,false},
        {6 ,false},
        {7 ,false},
        {8 ,false},
        {9 ,false}
    };
}
