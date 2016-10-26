using UnityEngine;
using UnityEditor;
using EditorFramework;

public class ControlsWindow : EditorWindow {


    [MenuItem("EditorFramework/ControlsWindow")]
    static void DoIt() {
        GetWindow<ControlsWindow>();
    }

    Button btnText = new Button() { Text = "文本", Image = "", ToolTip="这是文本按钮" };
    Button btnImg = new Button() { Image = "SceneAsset Icon", ToolTip="这是图形按钮",Position=new Rect(0,30,100,20) };
    Button btnImgText = new Button() { Text = "图形+文本", Image = "SceneAsset Icon", ToolTip = "这是图形+文本按钮", Position = new Rect(0, 60, 100, 20) };
    Button btnBoxStyle = new Button() { Style="box", Text = "Box风格", Image = "SceneAsset Icon", ToolTip = "这是Style设置成Box后的按钮", Position = new Rect(0, 90, 100, 20) };

    Label label = new Label() { Text = "标签", Position = new Rect(0, 120, 100, 20) };

    CheckBox chkBox = new CheckBox() { Text = "选项框",ToolTip="这是一个选项框", Position = new Rect(0, 150, 100, 20) };

    Image image = new Image() { Mode = ScaleMode.ScaleToFit, AlphaBlend=true,Position=new Rect(0,180,100,100) };

    void Awake() {
        btnImg.ClickEvent += (sender, args) => {
//             Debug.Log("Click "+args.Position+" Btn Posistion:"+btnImg.Position);
            ShowNotification(new GUIContent(btnImg.Text+" Click!"));
        };

        label.MouseLeftDownEvent += (sender, args) => {
            ShowNotification(new GUIContent(label.Text + " Left Down!"));
        };

        label.MouseRightDownEvent += (sender, args) => {
            ShowNotification(new GUIContent(label.Text + " Right Down!"));
        };
    }

    void OnGUI() {

        btnText.Render();
        btnImg.Render();
        btnImgText.Render();
        btnBoxStyle.Render();
        label.Render();
        chkBox.Render();
        image.Render();
    }
}