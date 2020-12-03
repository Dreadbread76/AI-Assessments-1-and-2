#region Needed Library

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#endregion
public class RandomRotate : EditorWindow

{
    public bool isSelected;
    public GameObject[] selectedObjects;
    
    
    float minRotX, minRotY, minRotZ, maxRotX, maxRotY, maxRotZ;
    float minRotXLim = -360, minRotYLim = -360, minRotZLim = -360, maxRotXLim = 360, maxRotYLim = 360, maxRotZLim = 360;
    public Vector3 randomRot;

    [MenuItem("Scrub Tools/Object Editor/Random Rotate")]
    
    
    
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(RandomRotate));

    }

    
    public void OnGUI()

    {
        EditorGUILayout.LabelField("Range X   " + minRotX + " : " + maxRotX);
        EditorGUILayout.MinMaxSlider(ref minRotX, ref maxRotX, minRotXLim, maxRotXLim);

        EditorGUILayout.LabelField("Range Y   " + minRotY + " : " + maxRotY);
        EditorGUILayout.MinMaxSlider(ref minRotY, ref maxRotY, minRotYLim, maxRotYLim);

        EditorGUILayout.LabelField("Range Z   " + minRotZ + " : " + maxRotZ);
        EditorGUILayout.MinMaxSlider(ref minRotZ, ref maxRotZ, minRotZLim, maxRotZLim);

        selectedObjects = Selection.gameObjects;
        
        if (selectedObjects.Length > 0)
        {
            isSelected = true;
                
        }
        else
        {
            isSelected = false;
        }

        if (isSelected)
        {
            ScriptableObject target = this;
            SerializedObject so = new SerializedObject(target);
            SerializedProperty objectProperty = so.FindProperty("selectedObjects");
            EditorGUILayout.PropertyField(objectProperty, true);
            so.ApplyModifiedProperties();

            if (GUILayout.Button("Discombobulate"))
            {
                for (int i = 0; i < selectedObjects.Length; i++)
                {
                    Transform tObj = selectedObjects[i].transform;

                    randomRot = new Vector3(
                        Random.Range(minRotX, maxRotX),
                        Random.Range(minRotY, maxRotY),
                        Random.Range(minRotZ, maxRotZ));

                    tObj.eulerAngles = new Vector3(
                        tObj.eulerAngles.x + randomRot.x,
                        tObj.eulerAngles.y + randomRot.y,
                        tObj.eulerAngles.z + randomRot.z);
                }
            }
        }
        
        
        
    }
}
    

