using EditorFramework;
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
