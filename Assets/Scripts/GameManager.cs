using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GameManager : Singleton<GameManager>
{
    //private ProjectilePool pool;
    private MatchablePool pool;
    private MatchableGrid grid;
    [SerializeField] private Vector2Int dimensions = Vector2Int.one;


    [SerializeField] private Text gridOutput;



    private void Start()
    {
        pool = (MatchablePool)MatchablePool.Instance;
        grid = (MatchableGrid)MatchableGrid.Instance;
        //pool.PoolObjects(10);
        //grid.InitializeGrid(dimension);
        /*pool = (ProjectilePool) ProjectilePool.Instance;
        pool.PoolObjects(5);*/
        //StartCoroutine(Demo());
        StartCoroutine(SetUp());
    }

    private IEnumerator SetUp()
    {
        pool.PoolObjects(dimensions.x * dimensions.y * 2);
        grid.InitializeGrid(dimensions);
        yield return null;
        grid.PopulatedGrid();
    }
    /*
    private IEnumerator Demo() 
    {
        
        /*gridOutput.text = grid.ToString();
        yield return new WaitForSeconds(2);

        Matchable m1 = pool.GetPooledObject();
        m1.gameObject.SetActive(true);
        m1.gameObject.name = "a";

        Matchable m2 = pool.GetPooledObject();
        m2.gameObject.SetActive(true);
        m2.gameObject.name = "b";

        grid.PutItemAt(m1, 0, 1);
        grid.PutItemAt(m2, 2, 3);

        gridOutput.text = grid.ToString();
        yield return new WaitForSeconds(2);

        grid.SwapItemsAt(0, 1, 2, 3);
        gridOutput.text = grid.ToString();
        yield return new WaitForSeconds(2);

        grid.RemoveItemAt(0, 1);
        grid.RemoveItemAt(2, 3);
        gridOutput.text = grid.ToString();
        yield return new WaitForSeconds(2);

        pool.ReturnObjectToPool(m1);
        pool.ReturnObjectToPool(m2);*/




    /*Matchable m = pool.GetPooledObject();
    m.gameObject.SetActive(true);
    Vector3 randomPosition;
    for (int i = 0; i != 7; i++)
    {
        randomPosition = new Vector3(Random.Range(-6f,6f), Random.Range(-4f, 4f));
        yield return StartCoroutine(m.MoveToPosition(randomPosition));
    }
    /*List<Projectile> projectileList = new List<Projectile>();
    Projectile projectile;
    for (int i = 0; i != 7; ++i)
    {
        projectile = pool.GetPooledObject();
        projectileList.Add(projectile); 
        projectile.Randomize();
        projectile.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }
    for (int i = 0; i != 4; ++i) 
    {
        pool.ReturnObjectToPool(projectileList[i]);
        yield return new WaitForSeconds(0.5f);
    }
    for (int i = 0; i != 7; ++i)
    {
        projectile = pool.GetPooledObject();
        projectileList.Add(projectile);
        projectile.Randomize();
        projectile.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }*/

        
    

   


}
