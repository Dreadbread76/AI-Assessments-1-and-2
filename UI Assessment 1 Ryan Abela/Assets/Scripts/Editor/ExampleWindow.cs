using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    string exampleString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    public GameObject prefab;

    [MenuItem("Window/Example")]
    public static void ShowWindow()
    {
        //GetWindow<EditorWindow>("Example");
        EditorWindow.GetWindow(typeof(ExampleWindow));
    }
    private void OnGUI()
    {
        GUILayout.Label("Example Label.", EditorStyles.boldLabel);
        exampleString = EditorGUILayout.TextField("Name", exampleString);
        if(GUILayout.Button("Press Me"))
        {
            Debug.Log("Button has been pressed");
        }
        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -100, 100);
        EditorGUILayout.EndToggleGroup();
    }
}
