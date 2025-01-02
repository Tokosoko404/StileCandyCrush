using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance 
    {
        get 
        {
            if (instance == null) 
                Debug.LogError("non c'è l'istanza " + typeof(T) + " nella scena.");

                return instance;
            
        }
    }
    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            Init();

        }
        else
        {
            Debug.LogWarning("C'e gia un istanza di " + typeof(T) + " nella scena.Si autodistrugge.");
            Destroy(gameObject);
        }

    }
    protected void OnDestroy()
    {
        if (this == instance)
            instance = null;
    }
    protected virtual void Init() { }
}
