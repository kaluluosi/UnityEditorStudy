using UnityEngine;
using UnityEditor;
using EditorFramework;
using EditorFramework.Controls;
using System.Collections.Generic;
using EditorFramework.Panel;

public class StackPanelWindow : EditorWindowEx
{
    [MenuItem("EditorFramework/StackPanelWindow")]
    static void DoIt()
    {
        GetWindow<StackPanelWindow>();
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


    Toolbar toolbar;

    #endregion

    Panel mainPanel;

    Panel panel;
    Panel panelLayout;

    StackPanel hstackpanel;
    StackPanel vstackpanel;
    StackPanel stackpanel;
    private StackPanel floatstackpanel;

    void OnEnable()
    {
        #region

        chkDesignMode = new CheckBox() { text = "设计模式", IsChecked = Visual.DebugMode,Style="toolbarbutton" };

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

        selectionGrid2 = new SelectionGrid() {
            Col = 2,
            AdaptWidth = AdaptMode.Expand
        };

        selectionGrid2.Items.Add(new Button("按钮1") { Style = "box" });
        selectionGrid2.Items.Add(new Button("按钮2"));
        selectionGrid2.Items.Add(new Button("按钮3"));

        tabbar = new Tabbar();
        tabbar.Items.Add(new Button("按钮1"));
        tabbar.Items.Add(new Button("按钮2"));
        tabbar.Items.Add(new Button("按钮3"));
        tabbar.Items.Add(btnBoxStyle);
        tabbar.Items.Add(btnImgtext);

        tabbar_toolbarstyle = new Tabbar() {
            Style = "toolbarbutton"
        };
        tabbar_toolbarstyle.Items.Add(new Button("按钮1"));
        tabbar_toolbarstyle.Items.Add(new Button("按钮2"));
        tabbar_toolbarstyle.Items.Add(new Button("按钮3"));
        tabbar_toolbarstyle.Items.Add(btnBoxStyle);
        tabbar_toolbarstyle.Items.Add(btnImgtext);

        toolbar = new Toolbar() {
        };
        toolbar.Items.Add(new Button("Hello") { ImagePath = "SceneAsset Icon", Style = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello2") { Style = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello3") { Style = "toolbarbutton" });
        toolbar.Items.Add(new Button("Hello4") { Style = "toolbarbutton" });
        toolbar.Items.Add(chkDesignMode);


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
            Visual.DebugMode = args.NewValue;
            ShowNotification("Checked");
        };


        #endregion
        btnBoxStyle.Position = new Rect(0, 0, 100, 20);
        btnImgtext.Position = new Rect(150, 30, 100, 20);

        panel = new CanvasPanel() { Position = new Rect(200,300, 200, 200) };

        
        Button btnTemp = new Button("测试") { Position = new Rect(150,30,100,20) };
        Button btnTemp2 = new Button("测试2") { Position = new Rect(0, 0, 100, 20) };
        btnTemp.RenderEvent += (sender, args) => {
            Visual v = sender as Visual;
//             Debug.LogFormat("parent:{0} self:{1} inside:{2}", v.VisualParent.Position, v.Position,v.Renderable);
        };
        panel.Items.Add(btnTemp);
        panel.Items.Add(btnTemp2);

        hslider.Value = panel.Position.width;
        hslider.ValueChangedEvent += (sender, args) =>
        {
            panel.Position = new Rect(panel.Position) { width = args.NewValue };
        };

        panelLayout = new CanvasPanel() { FixedHeight = 200, FixedWidth = 200,AdaptWidth=AdaptMode.Expand,AdaptHeight=AdaptMode.Fixed };
        panelLayout.Items.Add(btnBoxStyle);
        panelLayout.Items.Add(btnImgtext);



        hstackpanel = new StackPanel() { Orientation= Direction.Horiziontal };
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));
        hstackpanel.Items.Add(new Button("测试"));


        vstackpanel = new StackPanel() { Orientation = Direction.Vertical };
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));
        vstackpanel.Items.Add(new Button("测试"));


        stackpanel = new StackPanel() { Orientation = Direction.Horiziontal };
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});
        stackpanel.Items.Add(new Button("测试"){AdaptHeight=AdaptMode.Expand,AdaptWidth=AdaptMode.Expand});

        floatstackpanel = new StackPanel() { Orientation = Direction.Horiziontal ,Position=new Rect(100,100,500,200)};
        floatstackpanel.Items.Add(new Button("测试") { });
        floatstackpanel.Items.Add(new Button("测试") { });
        floatstackpanel.Items.Add(new Button("测试") { });
        floatstackpanel.Items.Add(new Button("测试") { });
        floatstackpanel.Items.Add(new Button("测试") { });
        floatstackpanel.Items.Add(new Button("测试") { });
        floatstackpanel.Items.Add(new Button("测试") { });
        floatstackpanel.Items.Add(new Button("测试") { });


        mainPanel = new StackPanel() { Orientation=Direction.Vertical, AdaptHeight = AdaptMode.Expand, AdaptWidth = AdaptMode.Expand };
        mainPanel.Items.Add(toolbar);
        mainPanel.Items.Add(hslider);
        mainPanel.Items.Add(panelLayout);
        mainPanel.Items.Add(new Label("Horizontal StackPanel"));
        mainPanel.Items.Add(hstackpanel);
        mainPanel.Items.Add(new Label("Vertical StackPanel"));
        mainPanel.Items.Add(vstackpanel);
        mainPanel.Items.Add(new Label("Vertical StackPanel"));
        mainPanel.Items.Add(stackpanel);

    }


    void OnGUI()
    {

        mainPanel.RenderLayout();
        floatstackpanel.Render();

        //scrollPosition =GUILayout.BeginScrollView(scrollPosition,GUILayout.Height(300));
        //         for(int i = 0; i < 100; i++) {
        //             GUILayout.Button("测试");
        //             Rect rect = GUILayoutUtility.GetLastRect();
        //             Drawing.DrawRectangle(rect,Color.red);
        //         }
        //GUILayout.Box("box",GUILayout.Height(1000));

        //GUILayout.EndScrollView();
    }
}