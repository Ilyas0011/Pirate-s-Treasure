using System;
using System.Collections.Generic;
using UnityEngine;
using static GameEntry;
using static ScreenManager;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
public class Config : ScriptableObject
{
    public ScreenPrefab[] ScreenPrefabs;
    public CanvasPrefab CanvasPrefab;

    private Dictionary<Type, ScreenPrefab> _screenDictionary;

    public void Init()
    {
        if(ScreenPrefabs == null)
            throw new Exception($"Encountered a null ScreenPrefab in the list");

        _screenDictionary = new Dictionary<Type, ScreenPrefab>();

        foreach (var screenPrefab in ScreenPrefabs)
            _screenDictionary[screenPrefab.GetType()] = screenPrefab;
    }

    public ScreenPrefab GetScreenPrefab(Type screenType)
    {
        if (_screenDictionary.TryGetValue(screenType, out var screenPrefab))
            return screenPrefab;

        throw new Exception($"Prefab {screenType} not found.");
    }
}