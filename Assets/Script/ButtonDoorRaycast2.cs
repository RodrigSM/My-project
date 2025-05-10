using UnityEngine;
using UnityEngine.UI;

public class ButtonDoorRaycast2 : MonoBehaviour
{
    [SerializeField] private int rayLength = 50;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private ButtonDoorController2 raycastedObj;

    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "DoorButton";

    private void Update()
{
    RaycastHit hit;

    // Pega a câmera principal
    Camera cam = Camera.main;
    Ray ray = new Ray(cam.transform.position, cam.transform.forward);

    // Prepara a máscara de camadas, excluindo a que foi definida
    int excludeLayer = LayerMask.NameToLayer(excludeLayerName);
    int mask = ~(1 << excludeLayer) & layerMaskInteract.value;

    // Faz o Raycast da câmera
    if (Physics.Raycast(ray, out hit, rayLength, mask))
    {
        // Desenha o raio no editor (linha vermelha)
        Debug.DrawRay(cam.transform.position, cam.transform.forward * rayLength, Color.red); 

        if (hit.collider.CompareTag(interactableTag))
        {
            if (!doOnce)
            {
                raycastedObj = hit.collider.gameObject.GetComponent<ButtonDoorController2>();
                CrosshairChange(true);
            }

            isCrosshairActive = true;
            doOnce = true;

            if (Input.GetKeyDown(openDoorKey))
            {
                raycastedObj.PlayAnimation();
            }
        }
    }
    else
    {
        if (isCrosshairActive)
        {
            CrosshairChange(false);
            doOnce = false;
        }
    }
}


    void CrosshairChange(bool on)
    {
        // if (on && doOnce)
        // {
        //     crosshair.color = Color.red;
        // }
        // else
        // {
        //     crosshair.color = Color.white;
        //     isCrosshairActive = false;
        // }
    }
}
