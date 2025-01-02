using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Matchable : Movable
{
    public override string ToString()
    {
        return gameObject.name;
    }
}
