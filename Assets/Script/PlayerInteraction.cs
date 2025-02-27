using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2f; // ��������� ��� ��������������
    [SerializeField] private LayerMask interactableLayer; // ���� ������������� ��������
    [SerializeField] private Image crosshair; // UI-������� (����� ��� ������ � ������ ������)

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
                crosshair.color = Color.green; // ������ ���� ����� (����� ������� ������)

                if (Input.GetKeyDown(KeyCode.E)) // ��������� ������� �� ������� "E"
                {
                    interactable.Interact();
                }
                return;
            }
        }

        crosshair.color = Color.white; // ���� ��������� ��� � ����� �������� �����
    }
}
