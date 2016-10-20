using UnityEngine;
using UnityEditor;
using EditorFramework;
using System.Linq;
using EditorFramework.Controls;

public class GUIStylesDemo : EditorWindow {
    private Vector2 scrollPos;

    [MenuItem("GUI/GUIStyles")]
    static void Init() {
        GetWindow<GUIStylesDemo>();
    }


    void OnGUI() {

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        foreach(GUIStyle style in GUI.skin) {
            if(GUILayout.Button(style.name, style)) {
                ShowNotification(new GUIContent(style.name + "已复制到剪贴板"));
                GUIUtility.systemCopyBuffer = style.name;
            }
        }

        EditorGUILayout.EndScrollView();
    }

}