using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject helpPanel;          // Seu painel de ajuda
    [Header("UI Buttons")]
    public Button settingsButton;         // Botão que abre o tutorial
    public Button closeTutorialButton;    // Botão que fecha o tutorial
    [Header("Help Panel Elements")]
    public TextMeshProUGUI bestTimeText;

    public GameObject player; // referenciado no editor ou encontrado via tag


    private const string BestTimeKey = "BestTime";


    void Start()
    {
        // Começa com o painel e o botão de fechar tutorial ocultos
        if (helpPanel != null) helpPanel.SetActive(false);
        if (closeTutorialButton != null) closeTutorialButton.gameObject.SetActive(false);

        UpdateBestTimeText();
    }

    public void OnPlayButton()
    {
        Time.timeScale = 1f;

        // (Opcional) Garante que o cursor volta a ficar travado e invisível
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Abre o HelpPanel e troca os botões
    public void OnSettingsButton()
    {
        if (helpPanel == null || settingsButton == null || closeTutorialButton == null) return;

        helpPanel.SetActive(true);
        settingsButton.gameObject.SetActive(false);
        closeTutorialButton.gameObject.SetActive(true);
    }

    // Fecha o HelpPanel e restaura os botões
    public void OnCloseHelpButton()
    {
        if (helpPanel == null || settingsButton == null || closeTutorialButton == null) return;

        helpPanel.SetActive(false);
        settingsButton.gameObject.SetActive(true);
        closeTutorialButton.gameObject.SetActive(false);
    }

    private void UpdateBestTimeText()
    {
        if (bestTimeText == null)
        {
            Debug.LogWarning("BestTimeText TMP component not assigned.");
            return;
        }

        if (PlayerPrefs.HasKey(BestTimeKey))
        {
            float best = PlayerPrefs.GetFloat(BestTimeKey);
            bestTimeText.text = $"Best Time: {FormatTime(best)}";
        }
        else
        {
            bestTimeText.text = "Best Time: --:--.--";
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int fraction = Mathf.FloorToInt((time * 100) % 100);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, fraction);
    }
}
