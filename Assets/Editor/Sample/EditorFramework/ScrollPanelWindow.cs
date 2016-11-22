using UnityEngine;
using UnityEditor;
using EditorFramework;
using EditorFramework.Controls;
using System.Collections.Generic;
using EditorFramework.Panel;
using System.Linq;

public class ScrollPanelWindow : EditorWindowEx {
    [MenuItem("EditorFramework/ScrollPanelWindow")]
    static void DoIt() {
        GetWindow<ScrollPanelWindow>();
    }

    List<Button> buttons = new List<Button>();
    private Vector2 scrollPos;
    Button btn = new Button("测试");

    void OnEnable() {

        btn.Position = new Rect(100, 100, 100, 20);
        for(int i = 0; i < 100; i++) {
            buttons.Add(new Button("测试" + i) );
        }


    }

    float height = 0f;
    bool initialized = false;
    Rect scrollRect;

    void OnGUI() {
        

        Visual.DebugMode = GUILayout.Toggle(Visual.DebugMode, "调试模式");

        scrollPos = GUILayout.BeginScrollView(scrollPos);

        if (initialized)
            GUILayout.Box("",GUIStyle.none, GUILayout.Height(height));

        foreach(Button btn in buttons) {
            if (btn.Initialized)
                btn.Render();
            else
                btn.RenderLayout();
        }

        GUILayout.EndScrollView();

        if (Event.current.type == EventType.repaint) {
            initialized = true;
            height = buttons.Sum(btn =>btn.Height+btn.Style.margin.top);
            scrollRect = GUILayoutUtility.GetLastRect();
            Debug.Log(scrollRect);
        }

    }
}