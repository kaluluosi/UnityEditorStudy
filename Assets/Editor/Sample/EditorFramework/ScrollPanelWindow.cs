using UnityEngine;
using UnityEditor;
using EditorFramework;
using EditorFramework.Controls;
using System.Collections.Generic;
using EditorFramework.Panel;
using System.Linq;

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

        hscrollpanel = new ScrollPanel() { Orientation = Direction.Horiziontal };
        for (int i = 0; i < 100; i++)
        {
            hscrollpanel.Items.Add(new Button("测试" + i));
        }


    }

    Button btnBox = new Button("box") { Style = "button" };
    private Vector2 scrollPos;
    private bool initialized = false;
    private Vector2 size;
    private Rect rect;
    void OnGUI()
    {

        Visual.DebugMode = GUILayout.Toggle(Visual.DebugMode, "调试模式");
        hscrollpanel.RenderLayout();
//         vscrollpanel.RenderLayout();

        // 
        //         scrollPos = GUILayout.BeginScrollView(scrollPos, "scrollview", GUILayout.ExpandHeight(false), GUILayout.ExpandWidth(false));
        //         GUILayout.Box("","box", GUILayout.Height(30), GUILayout.Width(10000));
        //         GUILayout.EndScrollView();
        // 
        // 
        // 
        //         if (Event.current.type == EventType.repaint)
        //         {
        //             initialized = true;
        //             size.x = rect.width;
        //             size.y = rect.height;
        //         }
        // 
        //         GUILayout.Label(size + " " + rect.size);
        // 
        //         if (Event.current.type == EventType.repaint)
        //             Debug.Log(GUILayoutUtility.GetLastRect());
        // 
        //         if (Event.current.type == EventType.repaint)
        //         {
        //             initialized = true;
        //             height = buttons.Sum(btn => btn.Height + btn.Style.margin.top)+4;
        //             scrollRect = GUILayoutUtility.GetLastRect();
        //             Debug.Log(scrollRect);
        //         }
        GUILayout.BeginHorizontal();
        btnBox.RenderLayout();
        btn.RenderLayout();
        btnBox.tooltip = btnBox.Position.ToString();
        btn.tooltip = btn.Position.ToString();
        GUILayout.EndHorizontal();

        GUILayout.Label((btn.Y - btnBox.Y - btnBox.Height).ToString());

        GUILayout.Label("border:" + btnBox.Style.border);
        GUILayout.Label("padding:" + btnBox.Style.padding);
        GUILayout.Label("margin:" + btnBox.Style.margin);

        GUILayout.Space(20);

        GUILayout.Label("border:" + btn.Style.border);
        GUILayout.Label("padding:" + btn.Style.padding);
        GUILayout.Label("margin:" + btn.Style.margin);


    }
}