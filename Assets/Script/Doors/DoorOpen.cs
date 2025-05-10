using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour, IDoorInteraction
{
    [SerializeField] private Animator doorOpen;

    [SerializeField] private bool NeedButton;
    private bool openDoor = false;

    public void IInteraction()
    {
        InputDoor();
    }

    private void InputDoor()
    {
        openDoor = !openDoor;
        if (openDoor)
        {
            Debug.Log("Porta Abriu");
            doorOpen.SetBool("open", true);
            if (SoundManager.Instance != null)
                SoundManager.Instance.SoundOpenDoor();
            else
                Debug.LogWarning("SoundManager.Instance está null!");
        }
        else
        {
            doorOpen.SetBool("open", false);
            if (SoundManager.Instance != null)
                SoundManager.Instance.SoundOpenDoor();
            else
                Debug.LogWarning("SoundManager.Instance está null!");
        }
    }

}
// public class DoorOpen : MonoBehaviour, IDoorInteraction
// {
//     [SerializeField] private Animator doorAnimator;
//     [SerializeField] private bool needButton = false;
//     private bool isOpen = false;

//     public bool RequiresButton => needButton;

//     // Called by player (e.g. via an “E” key ray‐cast) 
//     public void IInteraction()
//     {
//         if (needButton)
//         {
//             Debug.Log("Esta porta só abre com um botão escondido!");
//             return;
//         }
//         ToggleDoor();
//     }

//     // Exposed so SecretButtonRay can call it 
//     public void ToggleDoor()
//     {
//         isOpen = !isOpen;
//         doorAnimator.SetBool("open", isOpen);
//         Debug.Log(isOpen ? "Porta abriu!" : "Porta fechou!");

//         if (SoundManager.Instance != null)
//             SoundManager.Instance.SoundOpenDoor();
//         else
//             Debug.LogWarning("SoundManager.Instance está null!");
//     }
// }