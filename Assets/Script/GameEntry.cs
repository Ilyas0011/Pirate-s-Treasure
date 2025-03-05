using UnityEngine;

public class GameEntry : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private UnityCallbackService _unityCallbackService;

    public static GameEntry Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogWarning("GameEntry is already initialized");

        _unityCallbackService.Initialize();
        new InputManager();
        _player.Initialize();
    }
}
