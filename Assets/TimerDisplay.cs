using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerDisplay : MonoBehaviour
{
    [Tooltip("The TextMeshProUGUI component to display the timer on.")]
    public TextMeshProUGUI timerText;

    // Tracks whether the timer is running
    private bool isRunning = false;
    // The elapsed time in seconds
    private float elapsedTime = 0f;

    /// <summary>
    /// Starts the timer. Call this method to begin counting time.
    /// </summary>
    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
        Debug.Log("Teste");
    }

    /// <summary>
    /// Stops the timer. Call this method to pause the timer.
    /// </summary>
    public void StopTimer()
    {
        isRunning = false;
    }

    /// <summary>
    /// Returns the current elapsed time in seconds.
    /// </summary>
    public float GetTime()
    {
        return elapsedTime;
    }

    private void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerText(elapsedTime);
    }

    private void Awake()
    {
        // Ensure we have a reference to the TextMeshProUGUI component
        if (timerText == null)
        {
            timerText = GetComponent<TextMeshProUGUI>();
        }

        // Initialize display
        ResetTimer();
    }

    private void Update()
    {
        if (!isRunning) return;

        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Update the displayed text
        UpdateTimerText(elapsedTime);
    }

    /// <summary>
    /// Formats and updates the TextMeshProUGUI text.
    /// </summary>
    /// <param name="timeToDisplay">Time in seconds.</param>
    private void UpdateTimerText(float timeToDisplay)
    {
        // Format to minutes:seconds:hundredths
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float fraction = (timeToDisplay * 100) % 100;

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, fraction);
    }

    private void Start()
    {
        // Automatically start the timer when the game begins
        StartTimer();
    }
}
