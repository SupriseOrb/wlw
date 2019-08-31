using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public GameObject controlPanel;
   public GameObject pausePanel;
   public GameManager gameManager;
    void Awake()
    {
        gameManager = this.GetComponent<GameManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!pausePanel.activeInHierarchy){
                OpenPausePanel();
            }
            else if(pausePanel.activeInHierarchy 
                    && !controlPanel.activeInHierarchy){
                ClosePausePanel();
            }
            else if(controlPanel.activeInHierarchy ){
                CloseControlPanel();
            }

        }        
    }

    public void MainMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
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

    public void OpenPausePanel(){
        gameManager.player.ChangeCanProceedFalse();
        pausePanel.SetActive(true);
    }

    public void ClosePausePanel(){
        gameManager.player.ChangeCanProceedTrue();
        pausePanel.SetActive(false);
    }
}
