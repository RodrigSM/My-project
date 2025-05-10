using UnityEngine;

public class InteractText : MonoBehaviour
{
    public static InteractText Instance;

    [SerializeField] private Canvas canvas;
    private bool activeCanvas = false;

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

    public void ShowTextInteract(bool activeCanvas)
    {
        canvas.enabled = activeCanvas;
    }
}
