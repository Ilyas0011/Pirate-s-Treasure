using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractableObject
{
    [SerializeField] private string itemName;

    public void Interact()
    {
        Debug.Log("Предмет подобран");
        Destroy(gameObject);
    }
}
