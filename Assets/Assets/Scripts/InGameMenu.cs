using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenu, optionsMenu;
    public TMP_Dropdown graphicsDropdown;
    // Start is called before the first frame update
    
    void Awake()
    {
        if(PlayerPrefs.HasKey("mouseLock")) {
            PlayerPrefs.SetInt("mouseLock", 0);
        }
        else
        {
            PlayerPrefs.SetInt("mouseLock", 0);
        }
    }

    void Start()
    {
        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(QualitySettings.names.ToList());

        graphicsDropdown.value = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseMenu.activeSelf == true){
                pauseMenu.SetActive(false);
                PlayerPrefs.SetInt("mouseLock", 0);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (pauseMenu.activeSelf == false){
                pauseMenu.SetActive(true);
                PlayerPrefs.SetInt("mouseLock", 1);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void Quit() {
        Application.Quit();
    }
    public void Options() {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        PlayerPrefs.SetInt("mouseLock", 1);
    }

    public void Back() {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        PlayerPrefs.SetInt("mouseLock", 1);
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        PlayerPrefs.SetInt("mouseLock", 0);
    }

    public void SetGraphicsQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
