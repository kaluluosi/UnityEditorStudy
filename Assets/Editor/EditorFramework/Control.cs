
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

        public Control()
        {
            Style = GUIStyle.none;
        }

        private Rect position;

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


        public GUILayoutOption[] LayoutOptions
        {
            get
            {
                List<GUILayoutOption> layoutOptions = new List<GUILayoutOption>();

                //如果扩展宽度，那么就只设置扩展宽度；
                //如果不扩展宽度并且不自适应宽度，那么就只设置固定宽度；
                //如果不扩展宽度但自适应宽度，那么就不设置扩展宽度也不设置固定宽度；

                switch (AdaptWidth)
                {
                    case AdaptMode.Auto:
                        layoutOptions.Add(GUILayout.ExpandWidth(false));
                        break;
                    case AdaptMode.Expand:
                        layoutOptions.Add(GUILayout.ExpandWidth(true));
                        break;
                    case AdaptMode.Fixed:
                        layoutOptions.Add(GUILayout.Width(FixedWidth));
                        break;
                }

                switch (AdaptHeight)
                {
                    case AdaptMode.Auto:
                        layoutOptions.Add(GUILayout.ExpandHeight(false));
                        break;
                    case AdaptMode.Expand:
                        layoutOptions.Add(GUILayout.ExpandHeight(true));
                        break;
                    case AdaptMode.Fixed:
                        layoutOptions.Add(GUILayout.Height(FixedHeight));
                        break;
                }


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


        public AdaptMode AdaptWidth { get; set; }
        public AdaptMode AdaptHeight { get; set; }
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
