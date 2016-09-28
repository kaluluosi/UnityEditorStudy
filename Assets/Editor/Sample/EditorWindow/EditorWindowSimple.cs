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
    }

    void OnGUI(){

        GUILayout.BeginHorizontal();

        GUIStyle boxStyle = new GUIStyle("box");
        boxStyle.border = new RectOffset();
        boxStyle.margin = new RectOffset();
        boxStyle.padding = new RectOffset();
        boxStyle.normal.background = null;

        //boxStyle = new GUIStyle();
        //boxStyle.stretchWidth = true;

        EditorGUILayout.BeginVertical(boxStyle);
        GUILayout.BeginHorizontal("toolbar");
        GUILayout.Button("hehe","toolbarbutton",GUILayout.Width(100));
        GUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
        GUILayout.Button("hehe");
        EditorGUILayout.EndVertical();

        GUILayout.EndHorizontal();

    }

    private void doWindow(int id)
    {
        GUILayout.FlexibleSpace();

        GUILayout.Label("Content");

        GUI.DragWindow();
    }
}