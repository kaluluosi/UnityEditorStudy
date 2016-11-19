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

    Button btntext = new Button() { text = "文本", ImagePath = "", tooltip = "这是文本按钮" };
    Button btnImg = new Button() { ImagePath = "SceneAsset Icon", tooltip = "这是图形按钮", Position = new Rect(0, 30, 100, 20) };
    Button btnImgtext = new Button() { text = "图形+文本", ImagePath = "SceneAsset Icon", tooltip = "这是图形+文本按钮", Position = new Rect(0, 60, 100, 20) };
    Button btnBoxStyle = new Button() { Style = "box", text = "Box风格", ImagePath = "SceneAsset Icon", tooltip = "这是Style设置成Box后的按钮", Position = new Rect(0, 90, 100, 20) };
    Button btntextWidth = new Button() { text = "LayoutSetting.Width",tooltip="被LayoutSetting.Width影响的按钮", Width = 300 };
    Button btnRepeat = new Button() { text = "连点按钮", Repeatable = true };

    TextBox txtbox = new TextBox() { MultiLine = true };

    HorizontalSlider hslider = new HorizontalSlider() { Value = 0, MinValue = 0, MaxValue = 100 };
    HorizontalSlider hslider2 = new HorizontalSlider() { Value = 0, MinValue = 0, MaxValue = 100, SliderStyle = "horizontalscrollbar", ThumbStyle = "horizontalscrollbarthumb" };

    VerticalSlider vslider = new VerticalSlider() { Value = 0, MinValue = 0, MaxValue = 100 };

    Tabbar tabbar = new Tabbar() {
        Items = new List<GUIContent>() {
            new TabItem("按钮1"),
            new TabItem("按钮2"),
            new TabItem("按钮3"),
            new Button() { text="真·按钮" }
        }
    };

    SelectionGrid selectionGrid = new SelectionGrid() {
        Items = new List<GUIContent>() {
            new TabItem("按钮1"),
            new TabItem("按钮2"),
            new TabItem("按钮3"),
            new Button() { text="真·按钮" }
        },
        Col = 2
    };

    void Awake() {

        btnRepeat.ClickEvent += (sender, args) => {
            Debug.Log("连点");
        };

        tabbar.SelectedChangedEvent += (sender, args) => {
            ShowNotification("Tabbar Changed Selection:" + tabbar.SelectedItem.text);
        };

        selectionGrid.SelectedChangedEvent += (sender, args) => {
            ShowNotification("SelectionGrid Changed seledted:" + args.OldSelected + " to " + args.NewSelected);
        };
    }

    void OnGUI() {
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

        selectionGrid.RenderLayout();

    }
}