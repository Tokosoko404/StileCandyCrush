using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;

public class MatchableGrid : GridSystem<Matchable>
{
    private MatchablePool pool;

    private void Start()
    {
        pool= (MatchablePool) MatchablePool.Instance;
    }
    public  void PopulatedGrid() 
    {
        Matchable newMatchable;

        for (int y = 0; y != Dimensions.y; ++y)
            for (int x = 0; x != Dimensions.x; ++x) 
            {
                newMatchable = pool.GetPooledObject();
                newMatchable.transform.position = transform.position + new Vector3(x, y);
                newMatchable.gameObject.SetActive(true);
                PutItemAt(newMatchable,x,y);
            }


    }
   
}
