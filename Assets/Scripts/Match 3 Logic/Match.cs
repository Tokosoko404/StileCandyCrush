using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Match
{
    private List<Matchable> matchables;
    public List<Matchable> Matchables
    { 
        get { return matchables; }
    
    }
    public int Count
    { 
        get { return matchables.Count; }
    }
    public Match()
    { 
        matchables = new List<Matchable>(5); 
    
    }
    public Match(Matchable original) : this() 
    { 
        AddMatchable (original);
    
    }
    public void AddMatchable(Matchable toAdd)
    { 
        matchables.Add (toAdd);
    }
    public void Merge(Match toMarge)
    {
        matchables.AddRange(toMarge.Matchables);
    }
    public override string ToString()
    {
        string s = " Match of type" + matchables[0].Type + ":";
        foreach (Matchable m in matchables)
        {
            s += "(" + m.position.x + "," + m.position.y + ")";
        }
        return s;
    }
}
