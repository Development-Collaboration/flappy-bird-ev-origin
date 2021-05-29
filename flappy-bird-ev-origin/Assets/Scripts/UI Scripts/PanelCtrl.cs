using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelCtrl : MonoBehaviour
{


    // 정말 맘에 안듬 제발 고치자
    [Header("Panels")]
    public GameObject openningPanel;
    public GameObject readyPanel;
    public GameObject playPanel;
    public GameObject gameOverPanel;   
    public GameObject menuPanel;

    /*
    // Boards
    [Header("Boards")]
    public GameObject scoreBoard;
    */

    private Image menuPanelImage;
    // private bool isGamePause = false;


    private void Awake()
    {
        /*
        menuPanel.SetActive(true);

        menuPanelImage = menuPanel.GetComponent<Image>();
        menuPanelImage.enabled = false;
        */

    }


    // 정말 맘에 안듬 제발 고치자
    public void PanelSwitch(GameManager.GameStatus gameStatus) 
    {
        PanelAllSwtich(false);       
        
        switch (GameManager.instance.gameStatus)
        {
            case GameManager.GameStatus.Openning:
                openningPanel.SetActive(true);
                break;
            case GameManager.GameStatus.Ready:
                readyPanel.SetActive(true);
                break;
            case GameManager.GameStatus.Play:
                playPanel.SetActive(true);
                break;
            case GameManager.GameStatus.GameOver:
                gameOverPanel.SetActive(true);                
                break;
            case GameManager.GameStatus.Pause:
                menuPanel.SetActive(true);
                break;
        }           
     
        
    }

    // 정말 맘에 안듬 제발 고치자
    public void PanelAllSwtich(bool OnOff)
    {
        openningPanel.SetActive(OnOff);
        readyPanel.SetActive(OnOff); 
        playPanel.SetActive(OnOff); 
        gameOverPanel.SetActive(OnOff);
        menuPanel.SetActive(OnOff);

        //
        //scoreBoard.SetActive(OnOff);

    }

    /*
    public void PauseGame()
    {
        menuPanelImage.enabled = true;

    }
    */


}
