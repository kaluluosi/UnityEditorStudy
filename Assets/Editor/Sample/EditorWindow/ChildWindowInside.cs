
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class ChildWindowInside:EditorWindow
{
    [MenuItem("EditorWindow/ChildWindowInside")]
    static void Init(){
        GetWindow<ChildWindowInside>();
    }

    private  List<Window> windows = new List<Window>();

    private void AddWindow(Window window){
        window.Id = window.GetHashCode();
        windows.Add(window);
    }

    void OnGUI(){

        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
        
        if(GUILayout.Button("加一个窗口",EditorStyles.toolbarButton,GUILayout.Width(100))){
            Window win =new Window();
            win.Title = "ceshi"+win.Id;
            win.Enable = true;
            win.Draggable = true;
            win.Rect = new Rect(0,0,200,200);
            AddWindow(win);
        }

        if(GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Width(100))){
            windows.Clear();
        }

        GUILayout.FlexibleSpace();

        EditorGUILayout.EndHorizontal();

        DrawWindows();

        Debug.Log(Event.current.mousePosition);
    }

    void DrawWindows(){

        BeginWindows();
        foreach(Window win in windows){
            if(win.Enable)
                win.OnGUI();
        }
        EndWindows();
    }


    public class Window{
        /// <summary>
        /// Title text
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        /// <summary>
        /// Icon in title
        /// </summary>
        /// <returns></returns>
        public Texture Icon { get; set; }
        /// <summary>
        /// Rect of window
        /// </summary>
        /// <returns></returns>
        public Rect Rect { get; set; }
        /// <summary>
        /// Control ID
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }

        public bool Enable { get; set; }

        public bool Draggable { get; set; }

        public Rect DragArea { get; set; }

        public void OnGUI(){

            Rect = GUI.Window(Id,Rect,Draw,Title);
            
        }

        private void Draw(int id){
            
            DrawCustomContent(id);
            
            if(Draggable){
                if(DragArea.size != Vector2.zero)
                    GUI.DragWindow(DragArea);
                else
                    GUI.DragWindow();
            }

        }

        /// <summary>
        /// How to draw the content of window
        /// </summary>
        protected virtual void DrawCustomContent(int id){
            GUILayout.Label("Custom content");
        }
    }
}

