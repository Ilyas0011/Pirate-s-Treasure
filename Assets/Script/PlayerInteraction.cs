using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2f; // Дистанция для взаимодействия
    [SerializeField] private LayerMask interactableLayer; // Слой интерактивных объектов
    [SerializeField] private Image crosshair; // UI-элемент (точка или кружок в центре экрана)

    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractableObject interactable = hit.collider.GetComponent<IInteractableObject>();

            if (interactable != null)
            {
                crosshair.color = Color.green; // Меняем цвет точки (можно сделать эффект)

                if (Input.GetKeyDown(KeyCode.E)) // Подбираем предмет по нажатию "E"
                {
                    interactable.Interact();
                }
                return;
            }
        }

        crosshair.color = Color.white; // Если предметов нет – точка обычного цвета
    }
}
