
using System;
using UnityEditor;
using UnityEngine;


public class EditorWindowSimple:EditorWindow
{
    [MenuItem("EditorWindow/EditorWindowSimple")]
    static void Init(){
        GetWindow<EditorWindowSimple>();
    }
 
    Rect windowRect0 = new Rect(10,10,419,610);
    Texture img ;

    void OnEnable(){
        img = (Texture)EditorGUIUtility.Load(@"Assets/Resources/ButtonBrakeOverSprite.png");
        Debug.Log(img);
    }

    void OnGUI(){

        BeginWindows();

        windowRect0 = GUILayout.Window(0,windowRect0,doWindow,img);

        EndWindows();
    }

    private void doWindow(int id)
    {
        GUILayout.Label("Content");

        GUI.DragWindow();
    }
}