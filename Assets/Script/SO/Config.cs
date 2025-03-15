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

    private Dictionary<ScreenType, ScreenPrefab> _screenDictionary;

    public void Initialize() => ValidateAndFillDictionary(ScreenPrefabs);
    private void ValidateAndFillDictionary(ScreenPrefab[] screenPrefabs)
    {
        if (screenPrefabs == null || screenPrefabs.Length == 0)
            throw new Exception($"Config: {screenPrefabs} the array is empty or not specified!");

        _screenDictionary = new Dictionary<ScreenType, ScreenPrefab>();

        for (int i = 0; i < screenPrefabs.Length; i++)
        {
            if (screenPrefabs[i] == null)
                throw new Exception($"Config: The {screenPrefabs} on the {i} index is not set!");

            if (!Enum.IsDefined(typeof(ScreenType), i))
                throw new Exception($"Config: There is no corresponding value in the ScreenType for the index {i}");

            _screenDictionary.Add((ScreenType)i, ScreenPrefabs[i]);
        }
    }

    public ScreenPrefab GetScreenPrefab(ScreenType screenType)
    {
        if (_screenDictionary == null || !_screenDictionary.TryGetValue(screenType, out ScreenPrefab screenPrefab))
            throw new Exception($"Config: The prefab for {screenType} was not found!");

        return screenPrefab;
    }
}