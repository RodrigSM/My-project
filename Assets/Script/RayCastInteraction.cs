using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastInteraction : MonoBehaviour
{
    private float maxDistanceRay = 2.5f;

    private void FixedUpdate()
    {
        RayCastInteract();
    }

    private void RayCastInteract()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;

        if (Physics.Raycast(ray, out hitPoint, maxDistanceRay))
        {
            Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward, Color.red);

             IDoorInteraction interactDoor = hitPoint.transform.GetComponent<IDoorInteraction>();

            if(interactDoor != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Isto entrou");
                    interactDoor.IInteraction();
                }
            }

            if (hitPoint.collider.CompareTag("interactable"))
            {
                InteractText.Instance.ShowTextInteract(true);
            }
        }
        else
        {
            InteractText.Instance.ShowTextInteract(false);
        }
    }
}


















































































// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RayCastInteraction : MonoBehaviour
// {
//     private float maxDistanceRay = 2.5f;

//     private void Update()
//     {
//         RayCastInteract();
//     }

//     private void RayCastInteract()
//     {
//         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit hitPoint;

//         if (Physics.Raycast(ray, out hitPoint, maxDistanceRay))
//         {
//             Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.red);

//             IDoorInteraction interactDoor = hitPoint.transform.GetComponent<IDoorInteraction>();

//             if (interactDoor != null)
//             {
//                 //Debug.Log("Objeto com interface detectado: " + hitPoint.transform.name);
                
//                 if (Input.GetKeyDown(KeyCode.E))
//                 {
//                     Debug.Log("Tecla E pressionada!");
//                     interactDoor.IInteraction();
//                 }
//             }
//             else
//             {
//                 //Debug.Log("Nada com a interface detectado");
//             }


//             if (hitPoint.collider.CompareTag("interactable"))
//             {
//                 InteractText.Instance.ShowTextInteract(true);
//             }
//         }
//         else
//         {
//             InteractText.Instance.ShowTextInteract(false);
//         }
//     }
// }
