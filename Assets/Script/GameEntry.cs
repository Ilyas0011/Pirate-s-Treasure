using UnityEngine;

public class GameEntry : MonoBehaviour
{
    [SerializeField] private Player _player;

    private InputManager _inputManager;
    public static GameEntry Instance;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        _inputManager = new InputManager();
        

        _inputManager.Initialize();
        _player.Initialize();

    }

    void OnEnable() => _inputManager.Enable();
    void OnDisable() => _inputManager.Disable();

}
