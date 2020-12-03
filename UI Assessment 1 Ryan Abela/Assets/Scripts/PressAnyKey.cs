using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pressAnyKeyPanel, menuPanel;
   

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            pressAnyKeyPanel.SetActive(false);
            menuPanel.SetActive(true);
           
        }
    }
}
