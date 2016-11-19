
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    /// <summary>
    /// 控件基类
    /// </summary>
    public abstract class Control : UIFramework, ILayoutable
    {

        public GUIStyle Style { get; set; }

        private Rect position;
        private bool expandWidth=false,expandHeight = false;
        private bool autoWidth=true,autoHeight = true;

        public override Rect Position
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

        public int ControlID
        {
            get
            {
                return GetHashCode();
            }
        }

        public float FixedWidth { get; set; }
        public float MinWidth { get; set; }
        public float MaxWidth { get; set; }

        public float FixedHeight { get; set;
        }
        public float MinHeight { get; set; }

        public float MaxHeight { get; set; }

        public bool ExpandWidth
        {
            get
            {
                return expandWidth;
            }

            set
            {
                expandWidth = value;
            }
        }

        public bool ExpandHeight
        {
            get
            {
                return expandHeight;
            }

            set
            {
                expandHeight = value;
            }
        }

        public GUILayoutOption[] LayoutOptions
        {
            get
            {
                List<GUILayoutOption> layoutOptions = new List<GUILayoutOption>();

                //如果扩展宽度，那么就只设置扩展宽度；
                //如果不扩展宽度并且不自适应宽度，那么就只设置固定宽度；
                //如果不扩展宽度但自适应宽度，那么就不设置扩展宽度也不设置固定宽度；
                if (AutoWidth)
                    layoutOptions.Add(GUILayout.ExpandWidth(false));
                else if (ExpandWidth)
                    layoutOptions.Add(GUILayout.ExpandWidth(true));
                else
                    layoutOptions.Add(GUILayout.Width(FixedWidth));


                if (AutoHeight)
                    layoutOptions.Add(GUILayout.ExpandHeight(false));
                else if(ExpandHeight)
                    layoutOptions.Add(GUILayout.ExpandHeight(true));
                else
                    layoutOptions.Add(GUILayout.Height(FixedHeight));


                if (MinWidth > 0)
                    layoutOptions.Add(GUILayout.MinWidth(MinWidth));
                if (MaxWidth > 0)
                    layoutOptions.Add(GUILayout.MaxWidth(MaxWidth));

                if (MinHeight > 0)
                    layoutOptions.Add(GUILayout.MinHeight(MinHeight));
                if (MaxHeight > 0)
                    layoutOptions.Add(GUILayout.MaxHeight(MaxHeight));


                return layoutOptions.ToArray();
            }
        }

        public bool AutoWidth { get { return autoWidth; } set { autoWidth = value; }}
        public bool AutoHeight { get { return autoHeight; } set { autoHeight = value; } }

        public virtual void RenderLayout()
        {
            Rect newPosition = GUILayoutUtility.GetLastRect();
            if (newPosition.size.sqrMagnitude != 2)
                position = newPosition;
            CheckMouseEvent();
            OnRender(new DrawCanvas(Position));
        }



    }
}
