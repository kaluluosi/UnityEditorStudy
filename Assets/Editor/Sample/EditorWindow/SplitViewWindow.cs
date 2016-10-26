using UnityEngine;
using UnityEditor;
using EditorFramework;

public class SplitViewWindow : EditorWindow
{
    private Vector2 scrollPos = Vector2.zero;
    float currentScrollViewHeight;
    bool resize = false;
    Rect cursorChangeRect;

    [MenuItem("EditorWindow/SplitView")]
    public static void Init()
    {
        GetWindow<SplitViewWindow>();
    }

    void OnEnable()
    {
        this.position = new Rect(200, 200, 400, 300);
        currentScrollViewHeight = this.position.height / 2;
        cursorChangeRect = new Rect(0, currentScrollViewHeight, this.position.width, 5f);
    }

    Rect rect = new Rect(100, 100, 100, 100);

    void OnGUI()
    {
        GUILayout.BeginVertical();
        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Height(currentScrollViewHeight));
        for (int i = 0; i < 20; i++)
            GUILayout.Label("dfs");
        GUILayout.EndScrollView();

        ResizeScrollView();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Lower part");

        GUILayout.EndVertical();
        Repaint();

        Drawing.DrawRectangle(rect,Color.red);

        if (Event.current.type == EventType.mouseDown && rect.Contains(Event.current.mousePosition)) {
            Debug.Log("rect mouseDown");
        }


    }

    private void ResizeScrollView()
    {
        GUI.DrawTexture(cursorChangeRect, EditorGUIUtility.whiteTexture);
        EditorGUIUtility.AddCursorRect(cursorChangeRect, MouseCursor.ResizeVertical);

        if (Event.current.type == EventType.mouseDown && cursorChangeRect.Contains(Event.current.mousePosition))
        {
            resize = true;
            Debug.Log("mouseDown");
        }
        if (resize)
        {
            currentScrollViewHeight = Event.current.mousePosition.y;
            cursorChangeRect.Set(cursorChangeRect.x, currentScrollViewHeight, cursorChangeRect.width, cursorChangeRect.height);
        }
        if (Event.current.type == EventType.MouseUp)
            resize = false;
    }
}