
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

        public event EventHandler InitializedEvent;


        private string stylename;
        public string StyleName
        {
            get
            {
                return stylename;
            }
            set
            {
                if (stylename == value)
                    return;
                stylename = value;
                style = null;
            }
        }
        private GUIStyle style;
        public GUIStyle Style
        {
            get
            {
                if (style == null)
                    style = string.IsNullOrEmpty(StyleName) ? GUIStyle.none : new GUIStyle(StyleName) { richText = EnableRichText };

                return style;
            }
            set
            {
                style = value;
            }
        }

        public bool EnableRichText { get; set; }

        public Control()
        {
            StyleName = "";
            initialized = false;
            Visable = true;
        }


        public int ControlID
        {
            get
            {
                return GetHashCode();
            }
        }

        public bool Visable { get; set; }

        public float FixedWidth { get; set; }
        public float MinWidth { get; set; }
        public float MaxWidth { get; set; }

        public float FixedHeight
        {
            get;
            set;
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

        protected bool initialized = false;
        public virtual bool Initialized
        {
            get { return initialized; }
            set
            {
                if (value == true && initialized == false)
                    OnInitialized();

                initialized = value;
            }
        }

        public virtual void RenderLayout()
        {
            AfterLayout();
        }

        protected void AfterLayout()
        {
            UpdatePosition();
            CheckMouseEvent();
            OnRender();
        }

        protected virtual void UpdatePosition()
        {
            if (Event.current.type == EventType.repaint)
            {
                Rect newPosition = GUILayoutUtility.GetLastRect();
                Position = newPosition;
                Initialized = true;
            }
        }

        public override void OnRender()
        {
            base.OnRender();
        }



        public virtual Vector2 ContentSize
        {
            get
            {
                float height = AdaptHeight == AdaptMode.Fixed ? Height : -1;
                float width = AdaptWidth == AdaptMode.Fixed ? Width : -1;

                if (height != -1 && width != -1)
                    return new Vector2(FixedWidth, FixedHeight);

                return Style.CalcSize(this);
            }
        }


        protected void OnInitialized()
        {
            if (InitializedEvent != null)
                InitializedEvent(this, new EventArgs());
        }

        public Control Clone()
        {
            return (Control)MemberwiseClone();
        }
    }
}
