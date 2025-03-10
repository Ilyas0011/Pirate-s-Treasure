using System;
using System.Collections.Generic;
using UnityEngine;
using static ScreenService;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
public class Config : ScriptableObject
{
    public GameObject[] ScreenPrefabs;
    public static Config Instance;

    private Dictionary<ScreenType, GameObject> _screenDictionary;

    public void Initialize()
    {
        if (Instance == null)
            Instance = this;
        else
            throw new Exception($"Config singleton already initialized");

        ValidateAndFillDictionary();
    }
    private void ValidateAndFillDictionary()
    {
        _screenDictionary = new Dictionary<ScreenType, GameObject>();

        if (ScreenPrefabs == null || ScreenPrefabs.Length == 0)
            throw new Exception("Config: screenPrefabs the array is empty or not specified!");

        for (int i = 0; i < ScreenPrefabs.Length; i++)
        {
            if (ScreenPrefabs[i] == null)
                throw new Exception($"Config: The prefab on the {i} index is not set!");

            if (!Enum.IsDefined(typeof(ScreenType), i))
                throw new Exception($"Config: There is no corresponding value in the ScreenType for the index {i}");

            _screenDictionary.Add((ScreenType)i, ScreenPrefabs[i]);
        }
    }

    public GameObject GetScreenPrefab(ScreenType screenType)
    {
        if (_screenDictionary == null || !_screenDictionary.TryGetValue(screenType, out GameObject screenPrefab))
            throw new Exception($"Config: The prefab for {screenType} was not found!");

        return screenPrefab;
    }
}
