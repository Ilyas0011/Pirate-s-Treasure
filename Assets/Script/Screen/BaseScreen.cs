using UnityEngine;

public abstract class BaseScreen : MonoBehaviour
{
    public abstract ScreenIdentifier ID { get; }
    public enum ScreenIdentifier
    {
        Menu = 1,
        Settings = 2,
        Shop = 3,
        CoreGame = 4
    }
}
