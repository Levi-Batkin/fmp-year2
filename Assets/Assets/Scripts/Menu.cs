using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    // Reference to the options menu UI panel
    public GameObject optionsPanel;
    public GameObject mainPanel;

    // Reference to the graphics quality dropdown UI element
    public TMP_Dropdown graphicsDropdown;

    private void Start()
    {

        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(QualitySettings.names.ToList());

        graphicsDropdown.value = QualitySettings.GetQualityLevel();
    }

    // Start the game when the play button is clicked
    public void Play()
    {
        SceneManager.LoadScene("Storyline");
    }

    // Show the options menu when the options button is clicked
    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    // Hide the options menu when the back button is clicked
    public void HideOptions()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    // Set the graphics quality level when the graphics quality dropdown is changed
    public void SetGraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    // Quit the game when the quit button is clicked
    public void Quit()
    {
        Application.Quit();
    }
}
