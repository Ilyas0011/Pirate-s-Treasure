using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static BaseScreen;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
public class Config : ScriptableObject
{
    public BaseScreen[] ScreenPrefabs;
    public CanvasPrefab CanvasPrefab;

    private Dictionary<ScreenIdentifier, BaseScreen> _screenById;

    public void Init() => FillScreenDictionary();

    private void FillScreenDictionary()
    {
        foreach (var screenType in GetAllDerivedTypes())
        {
            bool exists = ScreenPrefabs.Any(prefab => prefab.GetType() == screenType);

            if (!exists)
                throw new Exception($"The screen {screenType.Name} is not in ScreenPrefabs.");
        }

        var duplicateGroup = ScreenPrefabs.GroupBy(screen => screen.ID)
            .FirstOrDefault(group => group.Count() > 1);

        if (duplicateGroup != null)
            throw new Exception($"Duplicate Screen ID found: {duplicateGroup.Key}");

        _screenById = new Dictionary<ScreenIdentifier, BaseScreen>();

        foreach (var screenPrefab in ScreenPrefabs)
            _screenById[screenPrefab.ID] = screenPrefab;
     }

    public static List<Type> GetAllDerivedTypes()
    {
        var derivedTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Screen)) && !t.IsAbstract)
            .ToList();
        return derivedTypes;
    }

    public BaseScreen GetScreenPrefab(ScreenIdentifier screenIdentifier) => _screenById[screenIdentifier];
}
