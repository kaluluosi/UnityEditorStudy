using System;
using UnityEngine;

namespace EditorFramework {
    public interface IVisual {
        string Name { get; set; }
        Rect Position { get; set; }

        float X { get; set; }
        float Y { get; set; }

        float Width { get; set; }
        float Height { get; set; }

        Quaternion Rotation { get; set; }
        Vector2 Scale { get; set; }
        Rect ScreenPosition { get; }
        Vector2 Size { get; }
        int VisualChildCount { get; set; }
        IVisual VisualParent { get; set; }

        event EventHandler<RenderEventArgs> RenderEvent;

        void OnRender();
        void Render();

        void Repaint();
    }
}