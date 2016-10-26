using UnityEngine;
using UnityEditor;
using EditorFramework;

public class LayoutWindow : EditorWindow {
    [MenuItem("EditorFramework/LayoutWindow")]
    static void DoIt() {
        GetWindow<LayoutWindow>();
    }

    Button btnText = new Button() { Text = "文本", Image = "", ToolTip = "这是文本按钮" };
    Button btnImg = new Button() { Image = "SceneAsset Icon", ToolTip = "这是图形按钮", Position = new Rect(0, 30, 100, 20) };
    Button btnImgText = new Button() { Text = "图形+文本", Image = "SceneAsset Icon", ToolTip = "这是图形+文本按钮", Position = new Rect(0, 60, 100, 20) };
    Button btnBoxStyle = new Button() { Style = "box", Text = "Box风格", Image = "SceneAsset Icon", ToolTip = "这是Style设置成Box后的按钮", Position = new Rect(0, 90, 100, 20) };

    Button btnTextWidth = new Button() { Text = "LayoutSetting.Width",ToolTip="被LayoutSetting.Width影响的按钮", Width = 300 };

    void OnGUI() {
        btnText.RenderLayout();
        btnImg.RenderLayout();
        btnImgText.RenderLayout();
        btnBoxStyle.RenderLayout();
        btnTextWidth.RenderLayout();

//         if (GUILayout.Button("测试")) {
//             Rect rect = new Rect(0, 0, 100, 100);
//             Vector2 v = new Vector2(10, 10);
//             Debug.Log(rect.Contains(v));
//         }
    }
}