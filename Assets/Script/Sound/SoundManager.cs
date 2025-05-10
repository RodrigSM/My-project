using System;
using UnityEngine;

[Serializable]
public struct SoundsDoor
{
    public AudioClip slideDoor;
    public AudioClip lockedDoor;
    public AudioClip openDoor;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private SoundsDoor soundsDoor;
    [SerializeField] private AudioSource soundsManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SoundSlideDoor()
    {
        soundsManager.PlayOneShot(soundsDoor.slideDoor);
    }
    public void SoundOpenDoor()
    {
        soundsManager.PlayOneShot(soundsDoor.openDoor);
    }

    public void SoundDoorLocked()
    {
        soundsManager.PlayOneShot(soundsDoor.lockedDoor);
    }
}
