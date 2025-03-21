using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreGameScreen : BaseScreen
{
    void Start()
    {
        SceneManager.LoadScene("Game");
    }
}
