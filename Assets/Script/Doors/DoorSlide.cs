using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    [SerializeField] private Animator doorSlide;

    private void OnTriggerEnter(Collider collision)
    {
        ApproachToOpenDoor();
    }

    private void OnTriggerExit(Collider collision)
    {
        MovingAwayToCloseDoor();
    }

    private void ApproachToOpenDoor()
    {
        doorSlide.SetBool("open", true);
        SoundManager.Instance.SoundSlideDoor();
    }

    private void MovingAwayToCloseDoor()
    {
        doorSlide.SetBool("open", false);
        SoundManager.Instance.SoundSlideDoor();
    }
}
