using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    /// <summary>
    /// 编辑器绘图工具类，用于绘制2d图形之用。
    /// </summary>
    public static class Drawing
    {

        public static void DrawRectangle(Rect rect,Color color)
        {
            Handles.color = color;
            Handles.DrawLine(rect.position, new Vector2(rect.position.x + rect.width, rect.position.y));
            Handles.DrawLine(new Vector2(rect.x + rect.width, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height));
            Handles.DrawLine(new Vector2(rect.x + rect.width, rect.y + rect.height), new Vector2(rect.x, rect.y + rect.height));
            Handles.DrawLine(new Vector2(rect.x, rect.y + rect.height), rect.position);
        }

    }
}
