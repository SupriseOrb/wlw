using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlPanel;
    public GameObject creditsPanel;
    void Start()
    {
        
    }

    void Update()
    {
        if(controlPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape)){
            CloseControlPanel();
        }
        if(creditsPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape)){
            CloseCreditsPanel();
        }
    }

    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame(){
        Application.Quit();
    }

    public void OpenControlPanel(){
        controlPanel.SetActive(true);
    }

    public void CloseControlPanel(){
        controlPanel.SetActive(false);
    }

    public void OpenCreditsPanel(){
        creditsPanel.SetActive(true);
    }

    public void CloseCreditsPanel(){
        creditsPanel.SetActive(false);
    }
}
