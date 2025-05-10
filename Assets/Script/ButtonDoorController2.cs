using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoorController2 : MonoBehaviour
{
    [SerializeField] private Animator doorAnim = null;
    [SerializeField] private DoorOpen doorToOpen; // Referência ao script DoorOpen

    private bool doorOpen = false;

    [SerializeField] private string openAnimationName = "OpenDoorButton";
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if (!doorOpen && !pauseInteraction)
        {
            // Animação do botão
            doorAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;

            // Chamar a porta para abrir
            if (doorToOpen != null)
            {
                doorToOpen.IInteraction();
            }
            else
            {
                Debug.LogWarning("A referência 'doorToOpen' está vazia!");
            }

            StartCoroutine(PauseDoorInteraction());
        }
    }
}
