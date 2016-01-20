using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Teleport : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	   
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Teleport working!");
            //int next_scene = SceneManager.GetActiveScene().buildIndex + 1;

            //if (next_scene <= SceneManager.GetAllScenes().Length)
            //    SceneManager.LoadScene(next_scene);
            //else
            //    Debug.LogError("Tried to load an unexisitng scene");
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
