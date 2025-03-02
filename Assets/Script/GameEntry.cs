using UnityEngine;

public class GameEntry : MonoBehaviour
{
    [SerializeField] private Player _player;

    public static GameEntry Instance;
    private InputManager _inputManager;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogWarning("GameEntry is already initialized");

        _inputManager = new InputManager();

        _inputManager.Initialization();

        _player.Initialize();

    }
}
