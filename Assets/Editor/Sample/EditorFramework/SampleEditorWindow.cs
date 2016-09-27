
using System;
using EditorFramework;
using UnityEditor;
using UnityEngine;
using EditorFramework.Controls;

public class SampleEditorWIndow : EditorWindowEx
{
    [MenuItem("EditorFramework/SampleEditorWIndow")]
    static void Init(){
        GetWindow<SampleEditorWIndow>();
    }

    ToolBar toolbar;
    ToolBar statubar;
    ToolBar noneDockToolbar;

    Button btnLeft;
    Button btnFill;
    Button btnRight;
    Button btnNone;

    ContainerControl cc_container;

    public SampleEditorWIndow() {

        toolbar = new ToolBar();
        Button addWinBtn = new Button("Add Window");
        addWinBtn.Width = 100;
        addWinBtn.ToolTip = "hello moto";
        addWinBtn.Style = EditorStyles.toolbarButton;
        addWinBtn.Click += AddWinBtn_Click;
        toolbar.Controls.Add(addWinBtn);
        Controls.Add(toolbar);

        statubar = new ToolBar();
        Button statuLabel = new Button("This is a Label");
        statuLabel.Style = EditorStyles.label;
        statubar.Dock = Dock.Bottom;
        Controls.Add(statubar);

        noneDockToolbar = new ToolBar();
        noneDockToolbar.Rect = new Rect(200, 200, 300, 40);
        noneDockToolbar.Dock = Dock.None;
        noneDockToolbar.Controls.Add(new Button("Dock None Toolbar") { Style = EditorStyles.toolbarButton });
        Controls.Add(noneDockToolbar);

        btnLeft = new Button("Dock Left Button");
        btnLeft.Dock = Dock.Left;
        btnLeft.Click += BtnLeft_Click;

        btnFill = new Button("Dock Fill Button");
        btnFill.Dock = Dock.Fill;
        btnFill.ExpandHeight = true;
        btnFill.ExpandWidth = true;

        btnRight = new Button("Dock Right Button");
        btnRight.Dock = Dock.Right;

        btnNone = new Button("Dock None Button");
        btnNone.Rect = new Rect(300, 300, 200, 40);
        btnNone.Dock = Dock.None;
        Controls.Add(btnNone);

        cc_container = new ContainerControl();
        cc_container.Dock = Dock.Fill;
        cc_container.ExpandHeight = true;
        cc_container.ExpandWidth = true;

//         Controls.Add(cc_container);
        Controls.Add(btnLeft);
//         Controls.Add(btnFill);
        Controls.Add(btnRight);

    }

    private void BtnLeft_Click(object sender, ClickEventArgs e)
    {
        if (e.Source.ID == GUIUtility.hotControl)
            Debug.Log("ÍÛ ÄãµÄÊó±êÐüÍ£ÔÚ:" + e.Source.Text);
        Debug.Log(GUIUtility.hotControl);
    }

    private void AddWinBtn_Click(object sender,ClickEventArgs e)
    {
        this.Windows.Add(new SubWindow() { Position=new Vector2(position.width/2,position.height/2) });
    }


    public class SubWindow : Window
    {
        private Button btnLeft = new Button("test Button", "text tool") { Style = EditorStyles.toolbarButton,Dock = Dock.Left} ;

        private ToolBar statubar = new ToolBar() { Text="sub window statu bar",Dock = Dock.Bottom};

        public SubWindow(){
            Title = "Hello Window";
            Rect = new Rect(0,0,300,300);
            AutoSize = true;
            Draggable=true;

            statubar.Controls.Add(btnLeft);

            Controls.Add(statubar);
        }

    }

}
