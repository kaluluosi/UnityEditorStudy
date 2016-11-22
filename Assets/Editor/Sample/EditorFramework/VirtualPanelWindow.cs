using UnityEngine;
using UnityEditor;
using EditorFramework.Panel;
using EditorFramework;
using EditorFramework.Controls;

public class VirtualPanel : EditorWindow {
    [MenuItem("EditorFramework/VirtualPanelWindow")]
    static void DoIt() {
        GetWindow<VirtualPanel>();
    }

    Panel mainPanel;
    Panel vStackPanel;
    Toolbar toolbar;
    Button button = new Button("haha");

    void OnEnable() {

        mainPanel = new VirtualStackPanel() { AdaptHeight = AdaptMode.Expand, AdaptWidth = AdaptMode.Expand };

        toolbar = new Toolbar() { Name="toolbar"};
        CheckBox chkDebugMode = new CheckBox("调试模式") { Style="toolbarbutton" };
        chkDebugMode.CheckedEvent += (sender, args) => { Visual.DebugMode = ((CheckBox)sender).IsChecked; };
        toolbar.Items.Add(chkDebugMode);

        Button btnResize = new Button("Resize") { Style="toolbarbutton"};
        btnResize.ClickEvent += (sender, args) => { mainPanel.Initialized = false; };
        toolbar.Items.Add(btnResize);

        vStackPanel = new VirtualStackPanel() {Name="panel1", AdaptHeight = AdaptMode.Expand, AdaptWidth = AdaptMode.Expand };
        vStackPanel.Items.Add(button);


        mainPanel.Items.Add(toolbar);
        mainPanel.Items.Add(vStackPanel);
        Visual.DebugMode = true;

    }

    void OnGUI() {

        //         mainPanel.RenderLayout();
        mainPanel.RenderLayout();

        //         GUILayout.BeginVertical("box",GUILayout.Height(200));
        //         GUILayout.EndVertical();
        // 
        //         button.RenderLayout();

    }

}