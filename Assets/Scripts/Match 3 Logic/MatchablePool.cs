using UnityEngine;

public class MatchablePool : ObjectPooling<Matchable>
{
    [SerializeField]private int howManyTypes;
    [SerializeField]private Sprite[] sprites;

    public void RandomizeType(Matchable toRandomize) 
    {
        int random = Random.Range(0, howManyTypes);
        toRandomize.SetType(random, sprites[random]);
    }

    public Matchable GetRandomMatchable()
    {
        
        Matchable randomMatchable = GetPooledObject();  
        RandomizeType(randomMatchable);
        return randomMatchable;
    }
    public int NextType(Matchable matchable)
    {
        int nextType = (matchable.Type + 1) % howManyTypes;
        matchable.SetType(nextType, sprites[nextType]);
        return nextType;
    }
}
