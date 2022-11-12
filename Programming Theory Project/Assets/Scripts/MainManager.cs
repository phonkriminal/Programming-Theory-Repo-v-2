using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{    
    public static MainManager Instance { get; private set; } // ENCAPSULATION
    
    private string m_playerName;

    public string GetPlayerName()
    { return m_playerName; }
    public void SetPlayerName(string value)
    { m_playerName = value; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Another intance of MainManager was found.!!!");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneBuildIndex + 1);
    }

}
