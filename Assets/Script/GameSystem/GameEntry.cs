using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GameEntry : MonoSingleton<GameEntry>
{
    [SerializeField] private UnityCallbackService _unityCallbackService;
    [SerializeField] private Config _config;
    [SerializeField] private ScreenService _screenService;

    public static GameEntry Instance;

    void Awake()
    {
        InitializeMonoSingleton(this);
        _config.Initialize();
        _screenService.Initialize();

        _unityCallbackService.Initialize();
        new InputManager();
    }
}
