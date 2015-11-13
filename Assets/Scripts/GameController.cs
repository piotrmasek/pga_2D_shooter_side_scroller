using UnityEngine;

public class GameController : Singleton<GameController>
{
    public GameObject m_StartGame;
    public GameObject m_ExitGame;
    public GameObject m_MainMenu;

    private bool m_IsPaused = false;


    protected GameController() {} //singleton protection
     
    // Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Cancel"))
        {
            if(m_IsPaused)
                UnpauseGame();
            else
                PauseGame();
        }

        if(Application.loadedLevel == 0)
        {
            m_StartGame.SetActive(true);
            m_ExitGame.SetActive(true);
            m_MainMenu.SetActive(false);
        }
        else
        {
            m_StartGame.SetActive(false);
            m_ExitGame.SetActive(false);

            if (m_IsPaused)
                m_MainMenu.SetActive(true);
            else
                m_MainMenu.SetActive(false);


        }
	}

    public void StartGame()
    {
        Application.LoadLevel(1);
        UnpauseGame();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        m_IsPaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        m_IsPaused = false;
    }

}
