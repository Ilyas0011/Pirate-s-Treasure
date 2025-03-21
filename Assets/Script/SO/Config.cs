using System;
using System.Collections.Generic;
using UnityEngine;
using static GameEntry;
using static ScreenManager;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
public class Config : ScriptableObject
{
    public BaseScreen[] ScreenPrefabs;
    public CanvasPrefab CanvasPrefab;

    private Dictionary<Type, BaseScreen> _screenDictionary;

    public void Init() =>  ValidateAndFillDictionary();

    private void ValidateAndFillDictionary()
    {
        if (ScreenPrefabs == null)
            throw new Exception($"Encountered a null ScreenPrefab in the list");

        _screenDictionary = new Dictionary<Type, BaseScreen>();

        foreach (var screenPrefab in ScreenPrefabs)
            _screenDictionary[screenPrefab.GetType()] = screenPrefab;
    }

    public BaseScreen GetScreenPrefab(Type screenType)
    {
        if (_screenDictionary.TryGetValue(screenType, out var screenPrefab))
            return screenPrefab;

        throw new Exception($"Prefab {screenType} not found.");
    }
}