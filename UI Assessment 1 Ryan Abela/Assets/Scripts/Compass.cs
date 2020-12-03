using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage compassScrTexture;
    public Transform playerPosInWorld;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
            compassScrTexture.uvRect = new Rect(playerPosInWorld.localEulerAngles.y / 360, 0, 1, 1);
        
    }
}
