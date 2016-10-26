using UnityEngine;
using UnityEditor;

public class GUIStylesDemo : EditorWindow {
    private Vector2 scrollPos;

    [MenuItem("GUI/GUIStyles")]
    static void Init() {
        GetWindow<GUIStylesDemo>();
    }


    void OnGUI() {

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        foreach(GUIStyle style in GUI.skin) {
            EditorGUILayout.BeginHorizontal("box");
            if(GUILayout.Button(style.name, style)) {
                ShowNotification(new GUIContent(style.name + "已复制到剪贴板"));
                GUIUtility.systemCopyBuffer = style.name;
            }
            EditorGUILayout.EndHorizontal();
        }
        GUILayout.Space(50);
        EditorGUILayout.EndScrollView();
    }

}