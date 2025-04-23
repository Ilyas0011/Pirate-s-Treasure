using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator _handAnimator;
    private bool isLoading = false;
    public string cubeAddress = "CubePrefab";

    public void SwordSlash()
    {
        _handAnimator.SetTrigger("SwordSlash");

        if(!isLoading)
        {
            Addressables.LoadAssetAsync<GameObject>(cubeAddress).Completed += OnCubeLoaded;
            isLoading = true;
            Debug.Log("Загрузка началась");
        }
    }

    private void OnCubeLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
            Debug.Log("Загрузилос");
        else
            Debug.LogError("Не удалось загрузить префаб куба через Addressables.");

    }
}
