using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public abstract class ResizeBar:Control
    {
        public Control Target { get; set; }
        public ResizeBar(Control target)
        {
            Target = target;
        }

        public override void RenderLayout()
        {
            GUILayout.Box(this,Style,LayoutOptions);

            EditorGUIUtility.AddCursorRect(Position, MouseCursor.SplitResizeUpDown);
            base.RenderLayout();
        }
    }


    public class ResizeUpDownBar : ResizeBar
    {

        public ResizeUpDownBar(Control target):base(target)
        {
            AdaptWidth = AdaptMode.Expand;
            AdaptHeight = AdaptMode.Fixed;
            FixedHeight = 5;

            StyleName = "EyeDropperHorizontalLine";

            DragEvent += ResizeUpDownBar_DragEvent;
            MouseLeftUpEvent += ResizeUpDownBar_MouseLeftUpEvent;
            MouseLeftDownEvent += ResizeUpDownBar_MouseLeftDownEvent;
        }

        void ResizeUpDownBar_MouseLeftDownEvent(object sender, Input.MouseEventArgs e)
        {
            CapMouse = true;
        }

        void ResizeUpDownBar_MouseLeftUpEvent(object sender, Input.MouseEventArgs e)
        {
            CapMouse = false;
        }


        void ResizeUpDownBar_DragEvent(object sender, Input.MouseEventArgs e)
        {
            if (Target != null)
            {
                if (Target.FixedHeight > VisualParent.Height - 100)
                {
                    Target.FixedHeight = VisualParent.Height - 100;
                    return;
                }
                if (Target.FixedHeight < 50f)
                {
                    Target.FixedHeight = 50f;
                    return;
                }
                Target.FixedHeight += Event.current.delta.y;
            }
            Repaint();
        }

    }

    public class ResizeLeftRightBar : ResizeBar
    {

        public ResizeLeftRightBar(Control target)
            : base(target)
        {
            AdaptHeight = AdaptMode.Expand;
            AdaptWidth = AdaptMode.Fixed;
            FixedWidth = 5;

            StyleName = "EyeDropperVerticalLine";

            DragEvent += ResizeUpDownBar_DragEvent;
            MouseLeftUpEvent += ResizeUpDownBar_MouseLeftUpEvent;
            MouseLeftDownEvent += ResizeUpDownBar_MouseLeftDownEvent;
        }

        void ResizeUpDownBar_MouseLeftDownEvent(object sender, Input.MouseEventArgs e)
        {
            CapMouse = true;
        }

        void ResizeUpDownBar_MouseLeftUpEvent(object sender, Input.MouseEventArgs e)
        {
            CapMouse = false;
        }


        void ResizeUpDownBar_DragEvent(object sender, Input.MouseEventArgs e)
        {
            if (Target != null)
            {
                if (Target.FixedWidth > VisualParent.Width - 50f)
                {
                    Target.FixedWidth = VisualParent.Width - 50f;
                    return;
                }
                if (Target.FixedWidth < 50f)
                {
                    Target.FixedWidth = 50f;
                    return;
                }


                Target.FixedWidth += Event.current.delta.x;

            }

            Repaint();
        }

    }

}
