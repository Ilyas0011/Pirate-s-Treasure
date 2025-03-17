using System;
using System.Threading.Tasks;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Device;

public class ScreenManager : MonoBehaviour, IInitializable
{
    private ScreenPrefab _currentScreenObject;
    private Transform _canvasTransform;
    private Config _config;

    public bool IsReady { get; set; }
    public bool DontAutoInit { get; }

    public ScreenManager() => _config = (Config)ServiceLocator.Get(typeof(Config));

    public Task Init()
    {
        SpawnCanvas();

        OpenScreen(typeof(CoreGameScreen));

        return Task.CompletedTask;
    }

    private void SpawnCanvas()
    {
        _canvasTransform = Instantiate(_config.CanvasPrefab, transform.position, Quaternion.identity).transform;
        _canvasTransform.SetParent(transform);
    }

    public void OpenScreen(Type screenType)
    {
        ScreenPrefab screen = _config.GetScreenPrefab(screenType);

        if (_currentScreenObject != null)
            Destroy(_currentScreenObject.gameObject);

        _currentScreenObject = Instantiate(screen, _canvasTransform.position, Quaternion.identity);
        _currentScreenObject.transform.SetParent(_canvasTransform);
    }
}
