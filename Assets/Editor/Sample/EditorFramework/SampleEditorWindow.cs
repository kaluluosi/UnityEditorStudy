
using System;
using EditorFramework;
using UnityEditor;
using UnityEngine;


public class SampleEditorWIndow : EditorWindowEx
{
    [MenuItem("EditorFramework/SampleEditorWIndow")]
    static void Init(){
        GetWindow<SampleEditorWIndow>();
    }

    ToolBar toolbar = new ToolBar();
    SubWindow window = new SubWindow();

    public SampleEditorWIndow() {

    }

    void OnEnable(){
        Controls.Add(toolbar);
        Windows.Add(window);
    }

    void OnGUI(){
        DrawControls();
        DrawWindows();
    }

    public class ToolBar : Control
    {
        public ToolBar(){
            Enable = true;
        }

        public override void Draw()
        {
            GUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.Label("Label");
            GUILayout.Button("Button",EditorStyles.toolbarButton);
            GUILayout.EndHorizontal();
        }
    }

    public class SubWindow : Window
    {
        public SubWindow(){
            Title = "Hello Window";
            Rect = new Rect(0,0,300,300);
            AutoSize = false;
            Draggable=true;
        }
        protected override void DrawContent()
        {
            GUILayout.Label("Hello World!");
        }
    }

}
