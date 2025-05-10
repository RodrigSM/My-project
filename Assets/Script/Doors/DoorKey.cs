using UnityEngine;

public class DoorKey : MonoBehaviour, IDoorInteraction
{
    [SerializeField] private Animator doorOpen;

    private bool openDoor = false;

    public void IInteraction()
    {
        InputDoor();
    }

    private void InputDoor()
    {
        if (KeyManager.Instance.keys.haveKey == true)
        {
            DoorUnlocked();
        }
        else DoorLocked();
    }

    private void DoorUnlocked()
    {
        openDoor = !openDoor;
        if (openDoor)
        {
            doorOpen.SetBool("open", true);
            //SoundManager.Instance.SoundOpenDoor();
        }
        else
        {
            doorOpen.SetBool("open", false);
            //SoundManager.Instance.SoundOpenDoor();
        }
    }

    private void DoorLocked()
    {
        doorOpen.SetTrigger("locked");
        //SoundManager.Instance.SoundDoorLocked();
    }
}
