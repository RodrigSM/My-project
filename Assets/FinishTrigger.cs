using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class FinishTrigger : MonoBehaviour
{
    [Tooltip("Reference to the TimerDisplay script in the scene.")]
    public TimerDisplay timerDisplay;

    [Tooltip("The UI panel to show when finished. Should be inactive at start.")]
    public GameObject finishPanel;

    [Tooltip("The restart button inside the finish panel.")]
    public Button restartButton;

    public Button mainMenuButton;

    // Automatically found TextMeshProUGUI inside the finishPanel
    private TextMeshProUGUI finishTimeText;

    private bool hasFinished = false;
    private const string BestTimeKey = "BestTime";


    private void Awake()
    {
        // Ensure the finish panel starts hidden
        if (finishPanel != null)
        {
            finishPanel.SetActive(false);
            finishTimeText = finishPanel.GetComponentInChildren<TextMeshProUGUI>(true);
            if (finishTimeText == null)
                Debug.LogWarning("No TextMeshProUGUI found under finishPanel.");

            if (restartButton == null)
                restartButton = finishPanel.GetComponentInChildren<Button>(true);
            if (restartButton != null)
                restartButton.onClick.AddListener(RestartGame);

            if (mainMenuButton == null)
                mainMenuButton = finishPanel.GetComponentInChildren<Button>(true);
            if (mainMenuButton != null)
                mainMenuButton.onClick.AddListener(OnMainMenu);

            else
                Debug.LogWarning("No Button found for restart on finishPanel.");
        }
        else
        {
            Debug.LogWarning("Finish panel not assigned on FinishTrigger.");
        }

        // Ensure this collider is a trigger
        Collider col = GetComponent<Collider>();
        if (col != null && !col.isTrigger)
            col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // only fire once
        if (hasFinished) return;

        // require the Player tag
        if (!other.CompareTag("Player")) return;
        hasFinished = true;
        finishTimeText.color = Color.white; 
        // Stop timer
        timerDisplay?.StopTimer();

        // Disable input and freeze physics
        var pc = other.GetComponentInParent<PlayerController>();
        var rb = other.GetComponentInParent<Rigidbody>();

        if (pc != null)
        {
            pc.canMove = false;
            pc.canLook = false;
        }

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        // unlock cursor for UI
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // calculate time
        float finalTime = timerDisplay != null ? timerDisplay.GetTime() : 0f;
        string timeStr = FormatTime(finalTime);

        // Check and save best time
        float bestTime = PlayerPrefs.GetFloat(BestTimeKey, float.MaxValue);
        bool isNewBest = finalTime < bestTime;
        if (isNewBest)
        {
            PlayerPrefs.SetFloat(BestTimeKey, finalTime);
            PlayerPrefs.Save();
        }
        string bestTimeStr = bestTime < float.MaxValue ? FormatTime(bestTime) : "--:--.--";

        // Show panel with results
        if (finishPanel != null)
        {
            finishTimeText.text = isNewBest
                ? $"New Best!\nTime: {timeStr}"
                : $"Time: {timeStr}\nBest: {bestTimeStr}";

            finishTimeText.color = Color.yellow;
            finishPanel.SetActive(true);
        }

        // pause game
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Formats seconds into MM:SS.FF
    /// </summary>
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int fraction = Mathf.FloorToInt((time * 100) % 100);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, fraction);
    }

    /// <summary>
    /// Restarts the current scene to play again.
    /// </summary>
    public void RestartGame()
    {
        // Ensure time scale and cursor state are reset
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

