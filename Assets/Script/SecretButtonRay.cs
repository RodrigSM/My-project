using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SecretButtonRay : MonoBehaviour, ISecretButtonInteraction
{
    public DoorController door;

    private void Reset()
    {
        // Ensure the Collider is set as a trigger
        var col = GetComponent<Collider>();
        col.isTrigger = true;
    }
    
    // This will fire as soon as something enters the trigger volume
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger activated by: {other.name}");
        IInteraction();
    }

    // Your existing interaction method
    public void IInteraction()
    {
        if (door != null)
        {
            Debug.Log("Botão escondido ativado!");
            //door.ToggleDoor();
        }
    }
}
