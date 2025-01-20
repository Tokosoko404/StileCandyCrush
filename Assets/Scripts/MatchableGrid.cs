using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;

public class MatchableGrid : GridSystem<Matchable>
{
    private MatchablePool pool;
    [SerializeField]private Vector3 offscreenOffSet;
    
    private void Start()
    {
        pool= (MatchablePool) MatchablePool.Instance;
    }
    public IEnumerator PopulatedGrid(bool allowMatches = false) 
    {
        Matchable newMatchable;
        Vector3 onscreenPosition;

        for (int y = 0; y != Dimensions.y; ++y)
            for (int x = 0; x != Dimensions.x; ++x) 
            {
                newMatchable = pool.GetRandomMatchable();
                //newMatchable.transform.position = transform.position + new Vector3(x, y);
                onscreenPosition = transform.position + new Vector3(x, y);
                newMatchable.transform.position = onscreenPosition +offscreenOffSet;
                newMatchable.gameObject.SetActive(true);
                newMatchable.position = new Vector2Int(x, y);
                PutItemAt(newMatchable,x,y);

                int initialType = newMatchable.Type;

                while (!allowMatches && IsPartOfMatch(newMatchable))
                {
                    if (pool.NextType(newMatchable) == initialType)
                    {
                        Debug.LogWarning("Failed to find a matchable that didn't match at (" +x+ "," +y+ ")");
                        Debug.Break();
                        break; 
                    }
                }

                StartCoroutine(newMatchable.MoveToPosition(onscreenPosition));

                yield return new WaitForSeconds(0.1f);
            }
        
        //yield return null;
    }
    private bool IsPartOfMatch(Matchable matchable)
    {
        return false;
    }

    public IEnumerator TrySwap(Matchable[] toBeSwapped) 
    {
        yield return StartCoroutine(Swap(toBeSwapped));






        StartCoroutine(Swap(toBeSwapped));
        //yield return null;  
    
    }
    private IEnumerator Swap(Matchable[] toBeSwapped) 
    {
        SwapItemsAt(toBeSwapped[0].position, toBeSwapped[1].position);
        Vector2Int temp = toBeSwapped[0].position;
        toBeSwapped[0].position = toBeSwapped[1].position;
        toBeSwapped[1].position = temp;
        Vector3[] worldPosition = new Vector3[2];
        worldPosition[0] = toBeSwapped[0].transform.position;
        worldPosition[1] = toBeSwapped[1].transform.position;
                     StartCoroutine(toBeSwapped[0].MoveToPosition(worldPosition[1]));
        yield return StartCoroutine(toBeSwapped[1].MoveToPosition(worldPosition[0]));
    }
}
