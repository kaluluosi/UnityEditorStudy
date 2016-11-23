using UnityEngine;
using UnityEditor;
using EditorFramework;
using EditorFramework.Controls;
using System.Collections.Generic;

public class LayoutWindow : EditorWindowEx {
    [MenuItem("EditorFramework/LayoutWindow")]
    static void DoIt() {
        GetWindow<LayoutWindow>();
    }

    Button btntext;
    Button btnImg;
    Button btnImgtext;
    Button btnBoxStyle;
    Button btnRepeat;

    Button btnSpecialStyle;

    TextBox txtbox;

    HorizontalSlider hslider;
    HorizontalSlider hslider2;
    VerticalSlider vslider;


    HorizontalScrollBar hscrollbar;
    Tabbar tabbar;
    Tabbar tabbar_toolbarstyle;
    SelectionGrid selectionGrid2;

    CheckBox chkDesignMode;

    Button btnExpandModel;
    CheckBox chkExpandWidth;
    CheckBox chkExpandHeight;
    CheckBox chkAutoWidth;
    CheckBox chkAutoHeight;

    Toolbar toolbar;

    void OnEnable() {
        chkDesignMode = new CheckBox() { text = "设计模式", IsChecked = Visual.DebugMode };

        btntext = new Button() { text = "文本", ImagePath = "", tooltip = "这是文本按钮" };
        btnImg = new Button() { ImagePath = "SceneAsset Icon", tooltip = "这是图形按钮" };
        btnImgtext = new Button() { text = "图形+文本", ImagePath = "SceneAsset Icon", tooltip = "这是图形+文本按钮" };
        btnBoxStyle = new Button() {
            StyleName = "box",
            text = "Box风格",
            ImagePath = "SceneAsset Icon",
            tooltip = "这是Style设置成Box后的按钮",
            FixedWidth = 200,
            AdaptWidth = AdaptMode.Fixed
        };
        btnSpecialStyle = new Button("换了样式的按钮") { StyleName = "ChannelStripAttenuationMarkerSquare", AdaptWidth = AdaptMode.Fixed, FixedWidth = 50 };
        btnRepeat = new Button() { text = "连点按钮", Repeatable = true };


        //         //自适应
        //         btnExpandModel = new Button("模特") { FixedWidth=200,FixedHeight=50 };
        //         chkExpandWidth = new CheckBox() { text = "展开宽度",IsChecked=btnExpandModel.ExpandWidth };
        //         chkExpandHeight = new CheckBox() { text = "展开高度" ,IsChecked=btnExpandModel.ExpandHeight};
        //         chkAutoWidth = new CheckBox() { text = "自动宽度", IsChecked = btnExpandModel.AutoWidth };
        //         chkAutoHeight = new CheckBox() { text = "自动高度", IsChecked = btnExpandModel.AutoHeight };
        // 
        //         chkExpandWidth.CheckedEvent += (sender, args) => {
        //             btnExpandModel.ExpandWidth = args.NewValue;
        //         };
        //         chkExpandHeight.CheckedEvent += (sender, args) => { btnExpandModel.ExpandHeight = args.NewValue; };
        //         chkAutoWidth.CheckedEvent += (sender, args) => { btnExpandModel.AutoWidth = args.NewValue; };
        //         chkAutoHeight.CheckedEvent += (sender, args) => { btnExpandModel.AutoHeight = args.NewValue; };
        // 

        txtbox = new TextBox() {
            MultiLine = true,
            text = "1233455555555555555555555555555555555",
            tooltip = "文本框"
        };
        hslider = new HorizontalSlider() { Value = btnBoxStyle.FixedWidth, MinValue = 0, MaxValue = 1000, AdaptWidth = AdaptMode.Expand };
        hslider2 = new HorizontalSlider() { Value = 0, MinValue = 0, MaxValue = 100, SliderStyleName = "horizontalscrollbar", ThumbStyleName = "ColorPickerHorizThumb", AdaptWidth = AdaptMode.Expand };
        vslider = new VerticalSlider() { Value = 0, MinValue = 0, MaxValue = 100 };
        hscrollbar = new HorizontalScrollBar() { Value = 0, MinValue = 0, MaxValue = 100, AdaptWidth = AdaptMode.Expand };

        selectionGrid2 = new SelectionGrid() {
            Col = 2,
            AdaptWidth = AdaptMode.Expand
        };
        selectionGrid2.Items.Add(new Button("按钮1") { StyleName = "box" });
        selectionGrid2.Items.Add(new Button("按钮2"));
        selectionGrid2.Items.Add(new Button("按钮3"));

        tabbar = new Tabbar();
        tabbar.Items.Add(new Button("按钮1"));
        tabbar.Items.Add(new Button("按钮2"));
        tabbar.Items.Add(new Button("按钮3"));
        tabbar.Items.Add(btnBoxStyle);
        tabbar.Items.Add(btnImgtext);

        tabbar_toolbarstyle = new Tabbar() {
            StyleName = "toolbarbutton"
        };
        tabbar_toolbarstyle.Items.Add(new Button("按钮1"));
        tabbar_toolbarstyle.Items.Add(new Button("按钮2"));
        tabbar_toolbarstyle.Items.Add(new Button("按钮3"));
        tabbar_toolbarstyle.Items.Add(btnBoxStyle);
        tabbar_toolbarstyle.Items.Add(btnImgtext);

        toolbar = new Toolbar() {
        };
        toolbar.Items.Add(new Button("Hello") { ImagePath = "SceneAsset Icon", StyleName = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello2") { StyleName = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello3") { StyleName = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello4") { StyleName = "toolbarbutton" });
        toolbar.Items.Add(chkDesignMode);

        btnBoxStyle.RenderEvent += (sender, args) => {
            //Debug.Log(btnBoxStyle.Width);
        };


        btnRepeat.ClickEvent += (sender, args) => {
            Debug.Log("连点");
        };

        tabbar.SelectedChangedEvent += (sender, args) => {
            ShowNotification("Tabbar Changed Selection:" + tabbar.SelectedItem.text);
        };

        selectionGrid2.SelectedChangedEvent += (sender, args) => {
            ShowNotification("SelectionGrid Changed seledted:" + args.OldSelected + " to " + args.NewSelected);
        };

        chkDesignMode.CheckedEvent += (sender, args) => {
            Visual.DebugMode = args.NewValue;
            ShowNotification("Checked");
        };

    }




    void OnGUI() {
        toolbar.RenderLayout();
        chkDesignMode.RenderLayout();

        GUILayout.Label("按钮");
        btntext.RenderLayout();
        btnImg.RenderLayout();
        btnImgtext.RenderLayout();
        btnBoxStyle.RenderLayout();
        btnRepeat.RenderLayout();
        btnSpecialStyle.RenderLayout();

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
        tabbar_toolbarstyle.RenderLayout();

        GUILayout.Space(10);

        GUILayout.Label("单选组");
        selectionGrid2.RenderLayout();

    }
}