using UnityEngine;

public class AllKeys : MonoBehaviour, IDoorInteraction
{
    public void IInteraction()
    {
        IHaveTheKey();
    }

    private void IHaveTheKey()
    {
        KeyManager.Instance.IHaveTheKey();
    }
}
