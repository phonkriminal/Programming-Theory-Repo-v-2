using UnityEngine;
using UnityEngine.SceneManagement;

namespace edeastudio
{
    public class MainManager : AudioManager // INHERITANCE
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
        public override void Start()
        {
            base.Start();
            InitializeScene();  // ABSTRACTION
        }

        private void InitializeScene()
        {
            SceneManager.activeSceneChanged += ActiveSceneChanged;
            PlayCurrentSceneMusic();    //ABSTRACTION
        }

        private void PlayCurrentSceneMusic()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayMusic(currentSceneIndex, true);
        }
        private void ActiveSceneChanged(Scene current, Scene next)
        {
            PlayCurrentSceneMusic();    // ABSTRACTION
        }

        public void LoadNextLevel()
        {
            Invoke(nameof(LoadNext), 3);
        }
        private void LoadNext()
        {
            int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            sceneBuildIndex++;

            SceneManager.LoadScene(sceneBuildIndex);
        }
       
    }
}