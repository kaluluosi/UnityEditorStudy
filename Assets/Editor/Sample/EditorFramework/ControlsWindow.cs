using UnityEngine;
using UnityEditor;
using EditorFramework;
using System;
using EditorFramework.Controls;

public class ControlsWindow : EditorWindow {


    [MenuItem("EditorFramework/ControlsWindow")]
    static void DoIt() {
        GetWindow<ControlsWindow>();
    }

    Button btntext = new Button() { text = "文本", ImagePath = "", tooltip="这是文本按钮" };
    Button btnImg = new Button() { ImagePath = "SceneAsset Icon", tooltip="这是图形按钮",Position=new Rect(0,30,100,20) };
    Button btnImgtext = new Button() { text = "图形+文本", ImagePath = "SceneAsset Icon", tooltip= "这是图形+文本按钮", Position = new Rect(0, 60, 100, 20) };
    Button btnBoxStyle = new Button() { Style="box", text = "Box风格", ImagePath = "SceneAsset Icon", tooltip= "这是Style设置成Box后的按钮", Position = new Rect(0, 90, 100, 20) };

    Label label = new Label() { text = "标签", Position = new Rect(0, 120, 100, 20) };

    CheckBox chkBox = new CheckBox() { text = "选项框",tooltip="这是一个选项框", Position = new Rect(0, 150, 100, 20) };

    Image image = new Image() { Mode = ScaleMode.ScaleToFit, AlphaBlend=true,Position=new Rect(0,180,100,100) };

    TextBox txtBox = new TextBox() { Text="输入文字",Position=new Rect(0,280,100,20) };

    TextBox multiLineTxtBox = new TextBox() { Text="输入多行文字\n另外一行" ,MultiLine=true,Position = new Rect(0,310,100,40)};

    PasswordBox passwordBox = new PasswordBox() { Position = new Rect(0, 340, 100, 20) };

    HorizontalSlider slider = new HorizontalSlider() { Position = new Rect(0, 370, 100, 20), Value = 0, MinValue = 0, MaxValue = 100 };

    VerticalSlider vslider = new VerticalSlider() { Value = 0, MinValue = 0, MaxValue = 100,Position=new Rect(0,400,20,100) };

    HorizontalScrollBar hScrollBar = new HorizontalScrollBar() { MinValue=0,MaxValue=100,Position=new Rect(30,420,100,10) };
    VerticalScrollBar vScrollBar = new VerticalScrollBar() { MinValue = 0, MaxValue = 100, Position = new Rect(30, 450, 10, 100) };

    void Awake() {
        btnImg.ClickEvent += (sender, args) => {
            ShowNotification(new GUIContent(btnImg.text+" Click!"));
        };

        label.MouseLeftDownEvent += (sender, args) => {
            ShowNotification(new GUIContent(label.text + " Left Down!"));
        };

        label.MouseRightDownEvent += (sender, args) => {
            ShowNotification(new GUIContent(label.text + " Right Down!"));
        };

        chkBox.CheckedEvent += (sender, args) => {
            ShowMessage(chkBox.text + " is checked:" + args.OldValue + " to " + args.NewValue);
        };

        txtBox.TextChangedEvent += (sender, args) => {
            ShowMessage(txtBox.text + " is changed:" + args.OldValue + " to " + args.NewValue);
        };

    }

    private void ShowMessage(string v) {
        ShowNotification(new GUIContent(v));
    }

    void OnGUI() {
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
    }
}