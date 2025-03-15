using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ScreenManager;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private ScreenType _screenType;

    private ScreenManager _screenManager;

    private Button _button;

    void Awake ()
    {
        _screenManager = (ScreenManager)ServiceLocator.Get(typeof(ScreenManager));

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() => _screenManager.OpenScreen(_screenType);
}
