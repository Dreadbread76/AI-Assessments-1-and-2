using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
    public void SceneChange(int sceneID)
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene(sceneID);
    }
    public void ExitToDesktop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

}
