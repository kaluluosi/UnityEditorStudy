

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace EditorFramework
{
    public enum GUILayoutOptionType
    {
        Width,
        Height,
        MinWidth,
        MinHeight,
        MaxWidth,
        MaxHeight
    }

    /// <summary>
    /// 所有控件的基类
    /// </summary>
    public abstract class Control : IControlContainer
    {
        private bool enable = true;
        private ControlCollection controls;

        private Dictionary<GUILayoutOptionType, float> guiLayoutOptions;

        public Control() {
            controls = new ControlCollection(this);
            guiLayoutOptions = new Dictionary<GUILayoutOptionType, float>();
            Enable = true;
            Style = "box";
            Dock = Dock.Top;
        }

        public string Text { get; set; }

        public string ToolTip { get; set; }

        public GUIContent Content { get; set; }

        public int ID {
            get {
                return GetHashCode();
            }
        }

        /// <summary>
        /// 子控件集合
        /// </summary>
        public ControlCollection Controls {
            get { return controls; }
        }

        /// <summary>
        /// 父控件
        /// </summary>
        public Control Owner { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enable {
            get {
                return enable;
            }
            set {
                enable = value;
            }
        }

        public Rect Rect { get; set; }

        public GUIStyle Style { get; set; }

        public Dock Dock { get; set; }

        public Vector2 Position
        {
            get
            {
                return Rect.position;
            }
            set
            {
                Rect = new Rect(value.x, value.y, Rect.width, Rect.height);
            }
        }

        public Vector2 Size
        {
            get
            {
                return Rect.size;
            }
            set
            {
                Rect.Set(Rect.x, Rect.y, value.x, value.y);
            }
        }

        public bool AutoSize
        {
            get;set;
        }

        /// <summary>
        /// 无视布局,Dock是None类型的都是无视布局绘制
        /// </summary>
        public bool IgnoreLayout
        {
            get
            {
                return Dock == Dock.None;
            }
        }


        #region GUILayoutOptions

        public float Width
        {
            get
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.Width))
                    return guiLayoutOptions[GUILayoutOptionType.Width];
                else
                    return -1;
            }
            set
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.Width))
                {
                    //如果value为-1则直接删除这个记录
                    if (value == -1)
                        guiLayoutOptions.Remove(GUILayoutOptionType.Width);
                    else
                    {
                        //否则将值赋予原来记录
                        guiLayoutOptions[GUILayoutOptionType.Width] = value;
                    }
                }
                else
                {
                    guiLayoutOptions.Add(GUILayoutOptionType.Width, value);
                }
            }
        }
        public float Height
        {
            get
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.Height))
                    return guiLayoutOptions[GUILayoutOptionType.Height];
                else
                    return -1;
            }
            set
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.Height))
                {
                    //如果value为-1则直接删除这个记录
                    if (value == -1)
                        guiLayoutOptions.Remove(GUILayoutOptionType.Height);
                    else
                    {
                        //否则将值赋予原来记录
                        guiLayoutOptions[GUILayoutOptionType.Height] = value;
                    }
                }
                else
                {
                    guiLayoutOptions.Add(GUILayoutOptionType.Height, value);
                }
            }
        }

        public float MinWidth
        {
            get
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MinWidth))
                    return guiLayoutOptions[GUILayoutOptionType.MinWidth];
                else
                    return -1;
            }
            set
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MinWidth))
                {
                    //如果value为-1则直接删除这个记录
                    if (value == -1)
                        guiLayoutOptions.Remove(GUILayoutOptionType.MinWidth);
                    else
                    {
                        //否则将值赋予原来记录
                        guiLayoutOptions[GUILayoutOptionType.MinWidth] = value;
                    }
                }
                else
                {
                    guiLayoutOptions.Add(GUILayoutOptionType.MinWidth, value);
                }
            }
        }

        public float MinHeight
        {
            get
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MinHeight))
                    return guiLayoutOptions[GUILayoutOptionType.MinHeight];
                else
                    return -1;
            }
            set
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MinHeight))
                {
                    //如果value为-1则直接删除这个记录
                    if (value == -1)
                        guiLayoutOptions.Remove(GUILayoutOptionType.MinHeight);
                    else
                    {
                        //否则将值赋予原来记录
                        guiLayoutOptions[GUILayoutOptionType.MinHeight] = value;
                    }
                }
                else
                {
                    guiLayoutOptions.Add(GUILayoutOptionType.MinHeight, value);
                }
            }
        }

        public float MaxWidth
        {
            get
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MaxWidth))
                    return guiLayoutOptions[GUILayoutOptionType.MaxWidth];
                else
                    return -1;
            }
            set
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MaxWidth))
                {
                    //如果value为-1则直接删除这个记录
                    if (value == -1)
                        guiLayoutOptions.Remove(GUILayoutOptionType.MaxWidth);
                    else
                    {
                        //否则将值赋予原来记录
                        guiLayoutOptions[GUILayoutOptionType.MaxWidth] = value;
                    }
                }
                else
                {
                    guiLayoutOptions.Add(GUILayoutOptionType.MaxWidth, value);
                }
            }
        }

        public float MaxHeight
        {
            get
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MaxHeight))
                    return guiLayoutOptions[GUILayoutOptionType.MaxHeight];
                else
                    return -1;
            }
            set
            {
                if (guiLayoutOptions.ContainsKey(GUILayoutOptionType.MaxHeight))
                {
                    //如果value为-1则直接删除这个记录
                    if (value == -1)
                        guiLayoutOptions.Remove(GUILayoutOptionType.MaxHeight);
                    else
                    {
                        //否则将值赋予原来记录
                        guiLayoutOptions[GUILayoutOptionType.MaxHeight] = value;
                    }
                }
                else
                {
                    guiLayoutOptions.Add(GUILayoutOptionType.MaxHeight, value);
                }
            }
        }

        #endregion

        protected GUILayoutOption[] GetGUILayoutOptions()
        {
            List<GUILayoutOption> options = new List<GUILayoutOption>();

            foreach(KeyValuePair<GUILayoutOptionType,float> kv in guiLayoutOptions)
            {
                switch (kv.Key)
                {
                    case GUILayoutOptionType.Width:
                        options.Add(GUILayout.Width(kv.Value));
                        break;
                    case GUILayoutOptionType.Height:
                        options.Add(GUILayout.Height(kv.Value));
                        break;
                    case GUILayoutOptionType.MinWidth:
                        options.Add(GUILayout.MinWidth(kv.Value));
                        break;
                    case GUILayoutOptionType.MinHeight:
                        options.Add(GUILayout.MinHeight(kv.Value));
                        break;
                    case GUILayoutOptionType.MaxWidth:
                        options.Add(GUILayout.MaxWidth(kv.Value));
                        break;
                    case GUILayoutOptionType.MaxHeight:
                        options.Add(GUILayout.MaxHeight(kv.Value));
                        break;
                }
            }

            return options.ToArray();
        }

        /// <summary>
        /// 绘制控件
        /// </summary>
        public abstract void Draw();

        
    }
}