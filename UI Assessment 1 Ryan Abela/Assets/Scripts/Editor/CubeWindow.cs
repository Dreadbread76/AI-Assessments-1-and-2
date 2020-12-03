using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubeWindow : EditorWindow
{


    string objectName = "New Object";
    GameObject prefab;
    float prefabScale;
   
    float spawnx, spawny, spawnz;
   

    [MenuItem("Window/Spawn")]

    public static void ShowWindow()
    {
        
        EditorWindow.GetWindow(typeof(CubeWindow));
    }

    // Update is called once per frame
    private void OnGUI()
    {
        objectName = EditorGUILayout.TextField("Name", objectName);
        prefab = (GameObject)EditorGUILayout.ObjectField(prefab, typeof(GameObject), true);
        if (GUILayout.Button("Spawn Cube"))
        {
            Instantiate(prefab, new Vector3 (0,0,0), Quaternion.identity );
        }
        
    }
}
