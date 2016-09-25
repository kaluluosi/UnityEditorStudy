using UnityEngine;
using UnityEditor;
using EditorFramework;
using System.Linq;
using EditorFramework.Controls;

public class GUIStylesDemo : EditorWindowEx
{
    [MenuItem("EditorFramework/GUIStylesDemo")]
    static void Init()
    {
        GetWindow<GUIStylesDemo>();
    }

    Button btnDisplayAll;

    public GUIStylesDemo()
    {
        btnDisplayAll = new Button("显示所有风格");
        btnDisplayAll.Click += BtnDisplayAll_Click;
        Controls.Add(btnDisplayAll);
    }

    private void BtnDisplayAll_Click(object sender, ClickEventArgs e)
    {
        //EditorStyles里面不仅仅只有GUIStyle 还有别的类型的属性，因此要过滤一下
        var properties = typeof(GUISkin).GetProperties().Where(p => p.PropertyType == typeof(GUIStyle));

        foreach (var prop in properties)
        {
            string name = prop.Name;
            GUIStyle style = prop.GetValue(GUI.skin, null) as GUIStyle;
            Debug.Log(style);
            Controls.Add(new Button(name, "This is " + name) { Style = style, Width = 200 });
        }

    }
}