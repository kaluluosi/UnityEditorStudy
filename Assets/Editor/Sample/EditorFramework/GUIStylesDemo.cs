using UnityEngine;
using UnityEditor;
using EditorFramework;
using System.Linq;
using EditorFramework.Controls;

public class GUIStylesDemo : EditorWindow
{
    [MenuItem("EditorFramework/GUIStylesDemo")]
    static void Init()
    {
        GetWindow<GUIStylesDemo>();
    }
    private Vector2 scollPos;



    void OnGUI()
    {
        //EditorStyles里面不仅仅只有GUIStyle 还有别的类型的属性，因此要过滤一下
        //         var properties = typeof(GUISkin).GetProperties().Where(p => p.PropertyType == typeof(GUIStyle));
        scollPos = GUILayout.BeginScrollView(scollPos);
        foreach (GUIStyle style in GUI.skin)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Button(style.name, style);
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
    }
}