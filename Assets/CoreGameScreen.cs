using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreGameScreen : ScreenPrefab
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Game");
    }
}
