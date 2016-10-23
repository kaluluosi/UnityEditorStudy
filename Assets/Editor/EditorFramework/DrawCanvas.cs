using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class DrawCanvas
    {
        public Vector2 Scale { get; set; }
        public Rect Rect { get; set; }
        public DrawCanvas(Rect rect)
        {
            this.Rect = rect;
        }

        public DrawCanvas(Rect rect, Vector2 scale) : this(rect)
        {
            this.Scale = scale;
        }

        public void DrawLine(Vector2 p1, Vector2 p2)
        {
            p1.Scale(Scale);
            p2.Scale(Scale);
            Handles.DrawLine(PointToScreen(p1), PointToScreen(p2));
        }

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            DrawLine(new Vector2(x1, y1), new Vector2(x2,y2));
        }

        public void DrawRectangle(Rect rect)
        {
            DrawLine(rect.position, new Vector2(rect.position.x + rect.width, rect.position.y));
            DrawLine(new Vector2(rect.x + rect.width, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height));
            DrawLine(new Vector2(rect.x + rect.width, rect.y + rect.height), new Vector2(rect.x, rect.y + rect.height));
            DrawLine(new Vector2(rect.x, rect.y + rect.height), rect.position);
        }

        public Vector2 PointToScreen(Vector2 point)
        {
            Vector2 p = point;
            p.x += Rect.x;
            p.y += Rect.y;
            return p;
        }
    }
}
