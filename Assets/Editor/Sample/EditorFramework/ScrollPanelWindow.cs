using UnityEngine;
using UnityEditor;
using EditorFramework;
using System.Collections.Generic;

public class ScrollPanelWindow : EditorWindowEx
{
    [MenuItem("EditorFramework/ScrollPanelWindow")]
    static void DoIt()
    {
        GetWindow<ScrollPanelWindow>();
    }

    List<Button> buttons = new List<Button>();

    Button btn = new Button("测试");

    ScrollPanel vscrollpanel;
    ScrollPanel hscrollpanel;

    void OnEnable()
    {

        btn.Position = new Rect(100, 100, 100, 20);
        for (int i = 0; i < 100; i++)
        {
            buttons.Add(new Button("测试" + i));
        }


        vscrollpanel = new ScrollPanel() { Orientation = Direction.Vertical };

        for (int i = 0; i < 100; i++)
        {
            vscrollpanel.Items.Add(new Button("测试" + i) { AdaptWidth = AdaptMode.Expand });
        }

        hscrollpanel = new ScrollPanel() { Orientation = Direction.Horiziontal/*,AdaptHeight=AdaptMode.Fixed,FixedHeight=50*/ };
        for (int i = 0; i < 100; i++)
        {
            hscrollpanel.Items.Add(new Button("测试" + i));
        }

        Repaint();
    }

    Button btnBox = new Button("box") { StyleName = "button" };
    private bool initialized = false;
    private Vector2 size;
    private Rect rect;

    void OnGUI()
    {

        Visual.DebugMode = GUILayout.Toggle(Visual.DebugMode, "调试模式");
        hscrollpanel.RenderLayout();
        vscrollpanel.RenderLayout();


//         GUILayout.BeginHorizontal();
//         btnBox.RenderLayout();
//         btn.RenderLayout();
//         btnBox.tooltip = btnBox.Position.ToString();
//         btn.tooltip = btn.Position.ToString();
//         GUILayout.EndHorizontal();
// 
//         GUILayout.Label((btn.Y - btnBox.Y - btnBox.Height).ToString());
// 
//         GUILayout.Label("border:" + btnBox.Style.border);
//         GUILayout.Label("padding:" + btnBox.Style.padding);
//         GUILayout.Label("margin:" + btnBox.Style.margin);
// 
//         GUILayout.Space(20);
// 
//         GUILayout.Label("border:" + btn.Style.border);
//         GUILayout.Label("padding:" + btn.Style.padding);
//         GUILayout.Label("margin:" + btn.Style.margin);


    }
}