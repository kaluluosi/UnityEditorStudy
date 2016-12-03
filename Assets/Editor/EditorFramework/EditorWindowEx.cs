using EditorFramework.Panel;
using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework {
    public class EditorWindowEx :EditorWindow,IControlContainer,IVisual{

        private StackPanel panel;

        public EditorWindowEx()
        {
            panel = new StackPanel() { text = "EditorWindowEx.panel" };
        }

       public void ShowNotification(string message) {
            ShowNotification(new GUIContent(message));
        }


       public string Name
       {
           get
           {
               return titleContent.text;
           }
           set
           {
               titleContent.text = value;
           }
       }

       public Rect Position
       {
           get
           {
               return position;
           }
           set
           {
               position = value;
           }
       }

       public float X
       {
           get
           {
               return position.x;
           }
           set
           {
               position = new Rect(position) { x = value };
           }
       }

       public float Y
       {
           get
           {
               return position.y;
           }
           set
           {
               position = new Rect(position) { y = value };
           }
       }

       public float Width
       {
           get
           {
               return position.width;
           }
           set
           {
               position = new Rect(position) { width = value };
           }
       }

       public float Height
       {
           get
           {
               return position.height;
           }
           set
           {
               position = new Rect(position) { height = value };
           }
       }

       public Quaternion Rotation { get; set; }

       public Vector2 Scale { get; set; }

       public Rect ScreenPosition
       {
           get { return position; }
       }

       public Vector2 Size
       {
           get { return position.size; }
       }

       public int VisualChildCount { get; set; }

       public IVisual VisualParent { get; set; }

       public event EventHandler<RenderEventArgs> RenderEvent;

       public void OnRender()
       {
           if (RenderEvent != null)
               RenderEvent(this, new RenderEventArgs() { Canvas = new DrawCanvas(position) });
       }

       public void Render()
       {
           panel.RenderLayout();
           OnRender();
       }

       public ControlCollection Items
       {
           get
           {
               return panel.Items;
           }
           set
           {
               panel.Items = value;
           }
       }

       void OnGUI()
       {
           Render();
       }
    }
}
