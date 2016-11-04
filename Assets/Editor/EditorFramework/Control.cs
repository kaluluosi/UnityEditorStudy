
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework {
    /// <summary>
    /// 控件基类
    /// </summary>
    public abstract class Control:UIFramework,ILayoutable {
        public GUIStyle Style { get; set; }

        private Dictionary<string, GUILayoutOption> layoutOptions = new Dictionary<string,GUILayoutOption>();
        private LayoutSetting layoutSetting = new LayoutSetting();

        public int ControlID {
            get
            {
                return GetHashCode();
            }
        }

        public float Width
        {
            get
            {
                return layoutSetting.Width;
            }

            set
            {
                layoutSetting.Width = value;
                layoutOptions.Add("Width", GUILayout.Width(value));
            }
        }
        public float MinWidth
        {
            get
            {
                return layoutSetting.MinWidth;
            }

            set
            {
                layoutSetting.MinWidth = value;
                layoutOptions.Add("MinWidth", GUILayout.MinWidth(value));
            }
        }

        public float MaxWidth
        {
            get
            {
                return layoutSetting.MaxWidth;
            }
            set
            {
                layoutSetting.MaxWidth = value;
                layoutOptions.Add("MaxWidth", GUILayout.MaxWidth(value));
            }
        }

        public float Height
        {
            get
            {
                return layoutSetting.Height;
            }

            set
            {
                layoutSetting.Height = value;
                layoutOptions.Add("Height", GUILayout.Height(value));
            }
        }

        public float MinHeight
        {
            get
            {
                return layoutSetting.MinHeight;
            }

            set
            {
                layoutSetting.MinHeight = value;
                layoutOptions.Add("MinHeight", GUILayout.MinHeight(value));
            }
        }

        public float MaxHeight
        {
            get
            {
                return layoutSetting.MaxHeight;
            }

            set
            {
                layoutSetting.MaxHeight = value;
                layoutOptions.Add("MaxHeight", GUILayout.MaxHeight(value));
            }
        }

        public bool ExpandWidth
        {
            get
            {
                return layoutSetting.ExpandWidth;
            }

            set
            {
                layoutSetting.ExpandWidth = value;
                layoutOptions.Add("ExpandWidth", GUILayout.ExpandWidth(value));
            }
        }

        public bool ExpandHeight
        {
            get
            {
                return layoutSetting.ExpandWidth;
            }

            set
            {
                layoutSetting.ExpandHeight = value;
                layoutOptions.Add("ExpandHeight", GUILayout.ExpandHeight(value));
            }
        }

        public GUILayoutOption[] LayoutOptions
        {
            get
            {
                return layoutOptions.Values.ToArray();
            }
        }

        public virtual void RenderLayout() {
            Position = GUILayoutUtility.GetLastRect();
            CheckMouseEvent();
            OnRender(new DrawCanvas(Position));
        }



    }
}
