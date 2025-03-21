using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ScreenManager;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private BaseScreen _screenPrefab;

    private ScreenManager _screenManager;

    private Button _button;

    private void Awake ()
    {
        _screenManager = ServiceLocator.Get<ScreenManager>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() => _screenManager.OpenScreen(_screenPrefab.GetType());
}
