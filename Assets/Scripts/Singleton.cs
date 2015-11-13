using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance {get; private set;}

    protected void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.Log("[Singleton] An instance of " + typeof(T).ToString() + " already exists. Destroying " + gameObject.name + "...");
            Destroy(gameObject);
        }
        else
        {
            if(FindObjectsOfType<T>().Length > 1)
                Debug.LogError("[Singleton] Something went wrong! Multiple instencaes of " + typeof(T).ToString() + "already exist!");

            Instance = (T)FindObjectOfType<T>();
	        DontDestroyOnLoad(gameObject);
	        Debug.Log("[Singleton] Initializing the instance of " + typeof(T).ToString() + " with already exising GameObject: " + Instance.gameObject.name);
        }
    }
    
}
