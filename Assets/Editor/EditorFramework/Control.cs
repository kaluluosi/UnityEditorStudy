
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
                return Position.width;
            }

            set
            {
                Position = new Rect(Position) { width = value };
                layoutOptions["width"] = GUILayout.Width(value);
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
                layoutOptions["MinWidth"]=GUILayout.MinWidth(value);
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
                layoutOptions["MaxWidth"]= GUILayout.MaxWidth(value);
            }
        }

        public float Height
        {
            get
            {
                return Position.height;
            }

            set
            {
                Position = new Rect(Position) { height = value };
                layoutOptions["Height"]=GUILayout.Height(value);
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
                Position = new Rect(Position) { height = value };
                layoutOptions["MinHeight"]= GUILayout.MinHeight(value);
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
                layoutOptions["MaxHeight"]=GUILayout.MaxHeight(value);
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
                layoutOptions["ExpandWidth"]=GUILayout.ExpandWidth(value);
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
                layoutOptions["ExpandHeight"]= GUILayout.ExpandHeight(value);
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
            Rect newPosition = GUILayoutUtility.GetLastRect();
            if (newPosition.size.sqrMagnitude != 2)
                Position = newPosition;
            CheckMouseEvent();
            OnRender(new DrawCanvas(Position));
        }



    }
}
