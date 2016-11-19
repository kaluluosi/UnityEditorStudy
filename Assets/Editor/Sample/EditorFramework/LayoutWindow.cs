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

    Button btnTest;

    TextBox txtbox;

    HorizontalSlider hslider;
    HorizontalSlider hslider2;
    VerticalSlider vslider;


    HorizontalScrollBar hscrollbar;
    Tabbar tabbar;
    SelectionGrid selectionGrid2;

    CheckBox chkDesignMode;

    Button btnExpandModel;
    CheckBox chkExpandWidth;
    CheckBox chkExpandHeight;
    CheckBox chkAutoWidth;
    CheckBox chkAutoHeight;

    Toolbar toolbar;


    void Awake()
    {
        chkDesignMode = new CheckBox() { text = "设计模式", IsChecked = Visual.DesignMode };

        btntext = new Button() { text = "文本", ImagePath = "", tooltip = "这是文本按钮" };
        btnImg = new Button() { ImagePath = "SceneAsset Icon", tooltip = "这是图形按钮"};
        btnImgtext = new Button() { text = "图形+文本", ImagePath = "SceneAsset Icon", tooltip = "这是图形+文本按钮" };

        btnExpandModel = new Button("模特") { FixedWidth=200,FixedHeight=50 };

        chkExpandWidth = new CheckBox() { text = "展开宽度",IsChecked=btnExpandModel.ExpandWidth };
        chkExpandHeight = new CheckBox() { text = "展开高度" ,IsChecked=btnExpandModel.ExpandHeight};
        chkAutoWidth = new CheckBox() { text = "自动宽度", IsChecked = btnExpandModel.AutoWidth };
        chkAutoHeight = new CheckBox() { text = "自动高度", IsChecked = btnExpandModel.AutoHeight };

        chkExpandWidth.CheckedEvent += (sender, args) => {
            btnExpandModel.ExpandWidth = args.NewValue;
        };
        chkExpandHeight.CheckedEvent += (sender, args) => { btnExpandModel.ExpandHeight = args.NewValue; };
        chkAutoWidth.CheckedEvent += (sender, args) => { btnExpandModel.AutoWidth = args.NewValue; };
        chkAutoHeight.CheckedEvent += (sender, args) => { btnExpandModel.AutoHeight = args.NewValue; };

        btnTest = new Button("10") { Style = "ChannelStripAttenuationMarkerSquare",AutoWidth=false,FixedWidth=50 };

        btnBoxStyle = new Button() {
            Style = "box",
            text = "Box风格",
            ImagePath = "SceneAsset Icon",
            tooltip = "这是Style设置成Box后的按钮",
            FixedWidth = 200,
            ExpandWidth = false
        };

        btntextWidth = new Button() {
            text = "LayoutSetting.Width",
            tooltip = "被LayoutSetting.Width影响的按钮",
            FixedWidth = 300,
        };

        btnRepeat = new Button() { text = "连点按钮", Repeatable = true };

        txtbox = new TextBox() {
            MultiLine = true,
            text="1233455555555555555555555555555555555",
            tooltip="文本框"
        };

        hslider = new HorizontalSlider() { Value = btnBoxStyle.FixedWidth, MinValue = 0, MaxValue = 1000 ,ExpandWidth=true,AutoWidth=false};
        hslider2 = new HorizontalSlider() { Value = 0, MinValue = 0, MaxValue = 100, SliderStyle = "horizontalscrollbar", ThumbStyle = "ColorPickerHorizThumb", ExpandWidth = true, AutoWidth = false };

        vslider = new VerticalSlider() { Value = 0, MinValue = 0, MaxValue = 100 };

        hscrollbar = new HorizontalScrollBar() { Value = 0, MinValue = 0, MaxValue = 100, ExpandWidth = true, AutoWidth = false};

        selectionGrid2 = new SelectionGrid()
        {
            Items = new List<Control>()
            {
                new Button("按钮1") { Style="box"},
                new Button("按钮2"),
                new Button("按钮3"),
            },
            Col = 2,
            ExpandWidth = true
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
            Items = new List<Control>()
            {
                new Button("Hello") { ImagePath="SceneAsset Icon",Style="toolbarbutton",FixedHeight=20,FixedWidth=60 },
                new Button("Hello2") {Style="toolbarbutton" },
                new Button("Hello3") { Style="toolbarbutton"} ,
                new Button("Hello4") { Style="toolbarbutton"} ,
            }
        };

        btnBoxStyle.RenderEvent += (sender, args) =>
        {
            //Debug.Log(btnBoxStyle.Width);
        };

        hslider.ValueChangedEvent += (sender, args) =>
        {
            btnBoxStyle.FixedWidth = args.NewValue;
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

        chkDesignMode.CheckedEvent += (sender, args) =>
        {
            Visual.DesignMode = args.NewValue;
            ShowNotification("Checked");
        };
    }




    void OnGUI()
    {
        toolbar.RenderLayout();
        chkDesignMode.RenderLayout();

        GUILayout.Label("按钮");
        btntext.RenderLayout();
        btnImg.RenderLayout();
        btnImgtext.RenderLayout();
        btnBoxStyle.RenderLayout();
        btntextWidth.RenderLayout();
        btnRepeat.RenderLayout();
        btnTest.RenderLayout();

        GUILayout.Space(10);
        GUILayout.Label("自适应");
        btnExpandModel.RenderLayout();
        chkExpandHeight.RenderLayout();
        chkExpandWidth.RenderLayout();
        chkAutoWidth.RenderLayout();
        chkAutoHeight.RenderLayout();
        GUILayout.Space(10);

        GUILayout.Label("文本框");
        txtbox.RenderLayout();

        GUILayout.Space(10);


        GUILayout.Label("滚动条");
        hslider.RenderLayout();

        hslider2.RenderLayout();

        vslider.RenderLayout();
        hscrollbar.RenderLayout();

        GUILayout.Space(10);

        GUILayout.Label("Tab条");
        tabbar.RenderLayout();

        GUILayout.Space(10);

        GUILayout.Label("单选组");
        selectionGrid2.RenderLayout();

    }
}