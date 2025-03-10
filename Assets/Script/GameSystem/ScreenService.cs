using UnityEngine;

public class ScreenService: MonoSingleton<ScreenService>
{
    private GameObject _currentScreenObject;

    public void Initialize()
    {
        InitializeMonoSingleton(this);
        SpawnScreen(ScreenType.MainMenu);
    }

    public enum ScreenType
    {
        MainMenu,
        Shop,
        Settings
    }

    public void SpawnScreen(ScreenType screenType)
    {
        GameObject screen = Config.Instance.GetScreenPrefab(screenType);

        if (_currentScreenObject != null)
            Destroy(_currentScreenObject);

        _currentScreenObject = Instantiate(screen, transform.position, Quaternion.identity);
        _currentScreenObject.transform.SetParent(transform);
    }

}
