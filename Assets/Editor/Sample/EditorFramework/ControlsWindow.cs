﻿using UnityEngine;
using UnityEditor;
using EditorFramework;

public class ControlsWindow : EditorWindow
{

    [MenuItem("EditorFramework/ControlsWindow")]
    static void DoIt()
    {
        GetWindow<ControlsWindow>();
    }

    Button btntext;
    Button btnImg;
    Button btnImgtext;
    Button btnBoxStyle;

    Label label;

    CheckBox chkBox;

    Image image;

    TextBox txtBox;

    TextBox multiLineTxtBox;

    PasswordBox passwordBox;

    HorizontalSlider slider;

    VerticalSlider vslider;

    HorizontalScrollBar hScrollBar;
    VerticalScrollBar vScrollBar;

    Toolbar toolbar;

    Texture defaultIcon;

    void OnEnable()
    {
        defaultIcon = EditorGUIUtility.Load("Texture2D Icon") as Texture;

        btntext = new Button() { Position = new Rect(0,0, 100, 20), text = "文本", ImagePath = "", tooltip = "这是文本按钮" };
        btnImg = new Button() { ImagePath = "SceneAsset Icon", tooltip = "这是图形按钮", Position = new Rect(0, 30, 100, 20) };
        btnImgtext = new Button() { text = "图形+文本", ImagePath = "SceneAsset Icon", tooltip = "这是图形+文本按钮", Position = new Rect(0, 60, 100, 20) };
        btnBoxStyle = new Button() { StyleName = "box", text = "Box风格", ImagePath = "SceneAsset Icon", tooltip = "这是Style设置成Box后的按钮", Position = new Rect(0, 90, 100, 20) };

        label = new Label() { text = "标签", Position = new Rect(0, 120, 100, 20) };

        chkBox = new CheckBox() { text = "选项框", tooltip = "这是一个选项框", IsChecked = Visual.DebugMode, Position = new Rect(0, 150, 100, 20) };

        image = new Image() { Mode = ScaleMode.ScaleToFit, AlphaBlend = true, Position = new Rect(0, 180, 100, 100) };

        txtBox = new TextBox() { text = "输入文字", Position = new Rect(0, 280, 100, 20) };

        multiLineTxtBox = new TextBox() { text = "输入多行文字\n另外一行", MultiLine = true, Position = new Rect(0, 310, 100, 40) };

        passwordBox = new PasswordBox() { Position = new Rect(0, 340, 100, 20) };

        slider = new HorizontalSlider() { Position = new Rect(0, 370, 100, 20), Value = 100, MinValue = 100, MaxValue = 1000 };

        vslider = new VerticalSlider() { Value = 0, MinValue = 0, MaxValue = 100, Position = new Rect(0, 400, 20, 100) };

        hScrollBar = new HorizontalScrollBar() { MinValue = 0, MaxValue = 100, Position = new Rect(30, 420, 100, 10) };
        vScrollBar = new VerticalScrollBar() { MinValue = 0, MaxValue = 100, Position = new Rect(30, 450, 10, 100) };

        toolbar = new Toolbar()
        {
            Position = new Rect(150, 5, 400, 20),            
        };

        toolbar.Items.Add(new Button("Hello") { ImagePath = "SceneAsset Icon", StyleName = "toolbarbutton", FixedHeight = 20, FixedWidth = 60 });
        toolbar.Items.Add(new Button("Hello") { StyleName = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello") { StyleName = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello") { StyleName = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello") { StyleName = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello") { StyleName = "toolbarbutton" });

        btnImg.ClickEvent += (sender, args) =>
        {
            ShowNotification(new GUIContent(btnImg.text + " Click!"));
        };

        label.MouseLeftDownEvent += (sender, args) =>
        {
            ShowNotification(new GUIContent(label.text + " Left Down!"));
        };

        label.MouseRightDownEvent += (sender, args) =>
        {
            ShowNotification(new GUIContent(label.text + " Right Down!"));
        };

        chkBox.CheckedEvent += (sender, args) =>
        {
            ShowMessage(chkBox.text + " is checked:" + args.OldValue + " to " + args.NewValue);
            Visual.DebugMode = args.NewValue;
        };

        txtBox.TextChangedEvent += (sender, args) =>
        {
            ShowMessage(txtBox.text + " is changed:" + args.OldValue + " to " + args.NewValue);
        };

        slider.ValueChangedEvent += (sender, args) =>
        {
            toolbar.Position = new Rect(toolbar.Position) { x = args.NewValue };
        };

    }

    private void ShowMessage(string v)
    {
        ShowNotification(new GUIContent(v));
    }

    void OnGUI()
    {
        btntext.Render();
        btnImg.Render();
        btnImgtext.Render();
        btnBoxStyle.Render();
        label.Render();
        chkBox.Render();
        image.Render();
        txtBox.Render();
        multiLineTxtBox.Render();

        passwordBox.Render();

        slider.Render();
        vslider.Render();

        hScrollBar.Render();
        vScrollBar.Render();

        toolbar.Render();


        GUILayout.BeginArea(new Rect(200, 200, 400, 400),"box");

        GUILayout.EndArea();
    }
}