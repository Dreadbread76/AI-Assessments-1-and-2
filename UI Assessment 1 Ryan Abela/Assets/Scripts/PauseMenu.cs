using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    public static bool isPaused;
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public LinearInventory inventory;


    [SerializeField]
    public GameObject player;

    #endregion
    #region Start
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);


    }
    #endregion
    #region Update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuActive();
        }
    }
    #endregion
    #region Pause Menu
    public void PauseMenuActive()
    {
        
        isPaused = !isPaused;
        Debug.Log(isPaused);
        if (isPaused)
        {

            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pausePanel.SetActive(true);
            
        }
        else
        {
           if (!LinearInventory.showInv)
           {
                Time.timeScale = 1;
           }
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pausePanel.SetActive(false);
        }
    }
    #endregion


}
