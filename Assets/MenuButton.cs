using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static ScreenService;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private ScreenType _screenType;

    private Button _button;

    void Awake ()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() => ScreenService.Instance.SpawnScreen(_screenType);
}
