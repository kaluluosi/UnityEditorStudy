
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

        Rect areaRect = new Rect(100, 100, 800, 600);

        GUILayout.BeginArea(new Rect(100, 100, 800, 600),"box","box");

        BeginWindows();

        if (windowRect0.position.x < 0)
            windowRect0.x = 0;
        if (windowRect0.position.y < 0)
            windowRect0.y = 0;


        windowRect0 = GUILayout.Window(0,windowRect0,doWindow,img);

        EndWindows();

        GUILayout.EndArea();
    }

    private void doWindow(int id)
    {
        GUILayout.FlexibleSpace();

        GUILayout.Label("Content");

        GUI.DragWindow();
    }
}