using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;
using EditorFramework.Controls;
using EditorFramework.Panel;
using UnityEditor;

public class GridPanelWindow : EditorWindowEx {

    [MenuItem("EditorFramework/GridPanelWindow")]
    public static void Init() {
        GetWindow<GridPanelWindow>();
    }

    Panel mainPanel;

    void OnEnable() {

        autoRepaintOnSceneChange = true;

        mainPanel = new StackPanel() { AdaptHeight = AdaptMode.Expand, AdaptWidth = AdaptMode.Expand };


        GridPanel grid = new GridPanel();

        for(int i = 0; i < 50; i++) {
            grid.Items.Add(new Button("测试" + i));
        }

        mainPanel.Items.Add(grid);

    }

    void OnGUI() {

        mainPanel.RenderLayout();
    }

}
