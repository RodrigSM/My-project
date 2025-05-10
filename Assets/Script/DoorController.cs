using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openRotation;
    public Vector3 closedRotation;
    public float smooth = 2f;
    private Quaternion targetRotation;
    private bool isOpen = false;

    private void Start()
    {
        // Garante que começa fechada
        targetRotation = Quaternion.Euler(closedRotation);
        transform.rotation = targetRotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        targetRotation = Quaternion.Euler(isOpen ? openRotation : closedRotation);
        Debug.Log("Porta " + (isOpen ? "aberta" : "fechada"));
    }
}
