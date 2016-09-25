using System;
using UnityEditor;
using UnityEngine;


public class EditorWindowSimple:EditorWindow
{
    [MenuItem("EditorWindow/EditorWindowSimple")]
    static void Init(){
        GetWindow<EditorWindowSimple>();
    }
 
    Rect windowRect0 = new Rect(10,10,200,200);
    Texture img ;

    void OnEnable(){
        img = (Texture)EditorGUIUtility.Load(@"Assets/Resources/ButtonBrakeOverSprite.png");
        Debug.Log(img);
    }

    void OnGUI(){

        BeginWindows();
        windowRect0 = GUI.Window(0, windowRect0, doWindow, img);
        EndWindows();

        GUILayout.BeginVertical(new GUIStyle("window"),GUILayout.Width(300),GUILayout.Height(200));
        EditorGUILayout.IntField("age", 100);
        GUILayout.EndVertical();

    }

    private void doWindow(int id)
    {
        GUILayout.FlexibleSpace();

        GUILayout.Label("Content");

        GUI.DragWindow();
    }
}