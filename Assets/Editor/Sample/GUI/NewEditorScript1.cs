using UnityEngine;
using UnityEditor;
using Assets.Editor;
using EditorFramework;

public class NewEditorScript1 : EditorWindow
{
    [MenuItem("Tools/Do It in C#")]
    static void DoIt()
    {
        GetWindow<NewEditorScript1>();
    }

    Visual visual = new MyVisual() {Rect=new Rect(100,100,100,100) };
    float x = 1;
    float y = 1;
    float z = 1;
    float w = 1;

    private float rotAngle = 0;
    private Vector2 pivotPoint;
    private Vector2 scrollPos;

    void OnGUI()
    {
        //         Vector2 screenPos = Event.current.mousePosition;
        //         Drawing.DrawRectangle(new Rect(10, 10, 100, 100), Color.red);
        //         GUI.BeginGroup(new Rect(10, 10, 100, 100));
        //         Vector2 convertedGUIPos = GUIUtility.ScreenToGUIPoint(screenPos);
        //         GUI.EndGroup();
        //         Debug.Log("Screen: " + screenPos + " GUI: " + convertedGUIPos);
        //         visual.Render();

        //         x = GUILayout.HorizontalSlider(x, -255, 255);
        //         y = GUILayout.HorizontalSlider(y, -255, 255);
        //         z = GUILayout.HorizontalSlider(z, -255, 255);
        //         w = GUILayout.HorizontalSlider(w,-1, 1);
        //         Quaternion q = Quaternion.Euler(x, y, z);
        // 
        //         GUILayout.Label("x:" + x);
        //         GUILayout.Label("y:" + y);
        //         GUILayout.Label("z:" + z);
        // 
        //         Handles.RectangleCap(1,new Vector3(100,100), q, 50);

        //         pivotPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        //         GUIUtility.RotateAroundPivot(rotAngle, pivotPoint);
        //         if (GUI.Button(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 25, 50, 50), "Rotate"))
        //             rotAngle += 10;

        //         x = GUILayout.HorizontalSlider(x, 1, 5);
        //         y = GUILayout.HorizontalSlider(y, 1, 5);
        //         visual.Scale = new Vector2(x, y);
        //         visual.Render();
        //         Debug.Log(visual.Scale);
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        for(int i = 0; i < 1000; i++)
        {
            GUILayout.Button("test");
        }
        GUILayout.EndScrollView();
    }


    class MyVisual :Visual
    {
        public override void OnRender(DrawCanvas drawContext)
        {
            //             drawContext.DrawLine(new Vector2(0, 0), new Vector2(10, 10));
            //             drawContext.DrawRectangle(ClientRect);
//             GUI.Button(Rect, "ceshi");
        }
    }
}