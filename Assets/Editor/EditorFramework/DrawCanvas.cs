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

        public void DrawLine(Vector2 p1, Vector2 p2,Color color)
        {
            Color backup = Handles.color;
            Handles.color = color;

            //p1.Scale(Scale);
            //p2.Scale(Scale);
            Handles.DrawLine(PointToScreen(p1), PointToScreen(p2));

            Handles.color = backup;

        }

        public void DrawLine(float x1, float y1, float x2, float y2,Color color)
        {
            DrawLine(new Vector2(x1, y1), new Vector2(x2,y2),color);
        }

        public void DrawRectangle(Rect rect,Color color)
        {
            DrawLine(rect.position, new Vector2(rect.position.x + rect.width, rect.position.y),color);
            DrawLine(new Vector2(rect.x + rect.width, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height),color);
            DrawLine(new Vector2(rect.x + rect.width, rect.y + rect.height), new Vector2(rect.x, rect.y + rect.height),color);
            DrawLine(new Vector2(rect.x, rect.y + rect.height), rect.position,color);
        }

        public Vector2 PointToScreen(Vector2 point)
        {
            Vector2 p = point;
            p.x += Rect.x;
            p.y += Rect.y;
            return p;
        }

        public void Text(Vector2 position,string content,Color color)
        {
            Vector2 p = PointToScreen(position);
            Color backup = Handles.color;
            Handles.color = color;
            Handles.Label(p, content);
            Handles.color = backup;
        }
    }
}
