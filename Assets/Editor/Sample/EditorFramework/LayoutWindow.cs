using UnityEngine;
using UnityEditor;
using EditorFramework;
using EditorFramework.Controls;
using System.Collections.Generic;

public class LayoutWindow : EditorWindowEx
{
    [MenuItem("EditorFramework/LayoutWindow")]
    static void DoIt()
    {
        GetWindow<LayoutWindow>();
    }

    Button btntext;
    Button btnImg;
    Button btnImgtext;
    Button btnBoxStyle;
    Button btntextWidth;
    Button btnRepeat;
    TextBox txtbox;
    HorizontalSlider hslider;
    HorizontalSlider hslider2;
    VerticalSlider vslider;
    HorizontalScrollBar hscrollbar;
    Tabbar tabbar;
    SelectionGrid selectionGrid2;

    CheckBox chkbox;

    Toolbar toolbar;


    void Awake()
    {
        Visual.DesignMode = true;

        chkbox = new CheckBox() { text = "设计模式", IsChecked = Visual.DesignMode };

        btntext = new Button() { text = "文本", ImagePath = "", tooltip = "这是文本按钮" };
        btnImg = new Button() { ImagePath = "SceneAsset Icon", tooltip = "这是图形按钮", Position = new Rect(0, 30, 100, 20) };
        btnImgtext = new Button() { text = "图形+文本", ImagePath = "SceneAsset Icon", tooltip = "这是图形+文本按钮", Position = new Rect(0, 60, 100, 20) };
        btnBoxStyle = new Button() { Style = "box", text = "Box风格", ImagePath = "SceneAsset Icon", tooltip = "这是Style设置成Box后的按钮", Position = new Rect(0, 90, 100, 20) };
        btntextWidth = new Button() { text = "LayoutSetting.Width", tooltip = "被LayoutSetting.Width影响的按钮", Width = 300 };
        btnRepeat = new Button() { text = "连点按钮", Repeatable = true };

        txtbox = new TextBox() { MultiLine = true };

        hslider = new HorizontalSlider() { Value = 0, MinValue = 0, MaxValue = 100 };
        hslider2 = new HorizontalSlider() { Value = 0, MinValue = 0, MaxValue = 100, SliderStyle = "horizontalscrollbar", ThumbStyle = "ColorPickerHorizThumb" };

        vslider = new VerticalSlider() { Value = 0, MinValue = 0, MaxValue = 100 };

        hscrollbar = new HorizontalScrollBar() { Value = 0, MinValue = 0, MaxValue = 100 };

        selectionGrid2 = new SelectionGrid()
        {
            Items = new List<Control>()
            {
                new Button("按钮1") { Style="box"},
                new Button("按钮2"),
                new Button("按钮3"),
            },
            Col = 2,
        };

        tabbar = new Tabbar()
        {
            Items = new List<Control>() {
                new Button("按钮1"),
                new Button("按钮2"),
                new Button("按钮3"),
                btnBoxStyle,
                btnImgtext
            }
        };

        toolbar = new Toolbar()
        {
            Position = new Rect(150, 5, 400, 20),
            Items = new List<Control>()
            {
                new Button("Hello") { ImagePath="SceneAsset Icon",Style="toolbarbutton",Height=20,Width=60 },
                new Button("Hello") {Style="toolbarbutton" },
                new Button("Hello") { Style="toolbarbutton"} ,
                new Button("Hello") { Style="toolbarbutton"} ,
            }
        };


        hslider.ValueChangedEvent += (sender, args) =>
        {
            hscrollbar.BarSize = args.NewValue;
        };


        btnRepeat.ClickEvent += (sender, args) =>
        {
            Debug.Log("连点");
        };

        tabbar.SelectedChangedEvent += (sender, args) =>
        {
            ShowNotification("Tabbar Changed Selection:" + tabbar.SelectedItem.text);
        };

        selectionGrid2.SelectedChangedEvent += (sender, args) =>
        {
            ShowNotification("SelectionGrid Changed seledted:" + args.OldSelected + " to " + args.NewSelected);
        };

        chkbox.CheckedEvent += (sender, args) =>
        {
            Visual.DesignMode = args.NewValue;
            ShowNotification("Checked");
        };
    }




    void OnGUI()
    {
        toolbar.RenderLayout();
        chkbox.RenderLayout();

        btntext.RenderLayout();
        btnImg.RenderLayout();
        btnImgtext.RenderLayout();
        btnBoxStyle.RenderLayout();
        btntextWidth.RenderLayout();

        txtbox.RenderLayout();

        hslider.RenderLayout();

        hslider2.RenderLayout();

        vslider.RenderLayout();

        btnRepeat.RenderLayout();

        tabbar.RenderLayout();

        selectionGrid2.RenderLayout();

        hscrollbar.RenderLayout();

    }
}