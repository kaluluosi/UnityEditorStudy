using UnityEngine;
using UnityEditor;
using EditorFramework;
using EditorFramework.Controls;
using System.Collections.Generic;
using EditorFramework.Panel;

public class PanelWindow : EditorWindowEx
{
    [MenuItem("EditorFramework/PanelWindow")]
    static void DoIt()
    {
        GetWindow<PanelWindow>();
    }

    #region

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

    #endregion

    Panel panel;
    Panel panelLayout;

    StackPanel hstackpanel;
    StackPanel vstackpanel;
    StackPanel stackpanel;

    void OnEnable()
    {
        #region

        chkDesignMode = new CheckBox() { text = "设计模式", IsChecked = Visual.DesignMode,Style="toolbarbutton" };

        btntext = new Button() { text = "文本", ImagePath = "", tooltip = "这是文本按钮" };
        btnImg = new Button() { ImagePath = "SceneAsset Icon", tooltip = "这是图形按钮"};
        btnImgtext = new Button() { text = "图形+文本", ImagePath = "SceneAsset Icon", tooltip = "这是图形+文本按钮" };
        btnBoxStyle = new Button() {
            Style = "box",
            text = "Box风格",
            ImagePath = "SceneAsset Icon",
            tooltip = "这是Style设置成Box后的按钮",
            FixedWidth = 200,
            AdaptWidth = AdaptMode.Fixed
        };
        btnSpecialStyle = new Button("换了样式的按钮") { Style = "ChannelStripAttenuationMarkerSquare",AdaptWidth=AdaptMode.Fixed,FixedWidth=50 };
        btnRepeat = new Button() { text = "连点按钮", Repeatable = true };




        txtbox = new TextBox() {
            MultiLine = true,
            text="1233455555555555555555555555555555555",
            tooltip="文本框"
        };

        hslider = new HorizontalSlider() { Value = btnBoxStyle.FixedWidth, MinValue = 0, MaxValue = 1000 ,AdaptWidth=AdaptMode.Expand};
        hslider2 = new HorizontalSlider() { Value = 0, MinValue = 0, MaxValue = 100, SliderStyle = "horizontalscrollbar", ThumbStyle = "ColorPickerHorizThumb", AdaptWidth = AdaptMode.Expand };
        vslider = new VerticalSlider() { Value = 0, MinValue = 0, MaxValue = 100 };
        hscrollbar = new HorizontalScrollBar() { Value = 0, MinValue = 0, MaxValue = 100, AdaptWidth = AdaptMode.Expand };

        selectionGrid2 = new SelectionGrid()
        {
            Items = new List<Control>()
            {
                new Button("按钮1") { Style="box"},
                new Button("按钮2"),
                new Button("按钮3"),
            },
            Col = 2,
            AdaptWidth = AdaptMode.Expand
        };

        tabbar = new Tabbar()
        {
            Items = new List<Control>() {
                new Button("按钮1"),
                new Button("按钮2"),
                new Button("按钮3"),
                btnBoxStyle,
                btnImgtext
            },
        };

        tabbar_toolbarstyle = new Tabbar()
        {
            Items = new List<Control>() {
                new Button("按钮1"),
                new Button("按钮2"),
                new Button("按钮3"),
                btnBoxStyle,
                btnImgtext
            },
            Style = "toolbarbutton"
        };

        toolbar = new Toolbar()
        {
            Items = new List<Control>()
            {
                new Button("Hello") { ImagePath="SceneAsset Icon",Style="toolbarbutton" },
                new Button("Hello2") {Style="toolbarbutton" },
                new Button("Hello3") { Style="toolbarbutton"} ,
                new Button("Hello4") { Style="toolbarbutton"} ,
                chkDesignMode
            }
        };

        btnBoxStyle.RenderEvent += (sender, args) =>
        {
            //Debug.Log(btnBoxStyle.Width);
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


        #endregion

        panel = new CanvasPanel() { Position = new Rect(200,300, 200, 200) };

        btnBoxStyle.Position = new Rect(0, 0, 100, 20);
        btnImgtext.Position = new Rect(150, 30, 100, 20);

        panel.Items.Add(btnBoxStyle);
        panel.Items.Add(btnImgtext);

        hslider.Value = panel.Position.width;
        hslider.ValueChangedEvent += (sender, args) =>
        {
            panel.Position = new Rect(panel.Position) { width = args.NewValue };
        };

        panelLayout = new CanvasPanel() { FixedHeight = 200, FixedWidth = 200,AdaptWidth=AdaptMode.Expand,AdaptHeight=AdaptMode.Fixed };
        panelLayout.Items.Add(btnBoxStyle);
        panelLayout.Items.Add(btnImgtext);



        hstackpanel = new StackPanel() { Orientation=StackPanel.Direction.Horiziontal };
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));


        vstackpanel = new StackPanel() { Orientation = StackPanel.Direction.Vertical };
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));


        stackpanel = new StackPanel() { Orientation = StackPanel.Direction.Horiziontal,Position=new Rect(500,500,400,400) };
        stackpanel.Items.Add(new Button("测试"));
        stackpanel.Items.Add(new Button("测试"));
        stackpanel.Items.Add(new Button("测试"));
        stackpanel.Items.Add(new Button("测试"));
        stackpanel.Items.Add(new Button("测试"));
        stackpanel.Items.Add(new Button("测试"));
        stackpanel.Items.Add(new Button("测试"));
        stackpanel.Items.Add(new Button("测试"));
    }



    void OnGUI()
    {
        toolbar.RenderLayout();
        hslider.RenderLayout();

        panel.Render();

        panelLayout.RenderLayout();

        GUILayout.Label("水平StackPanel");
        hstackpanel.RenderLayout();
        GUILayout.Label("垂直StackPanel");
        vstackpanel.RenderLayout();

        stackpanel.Render();

    }
}