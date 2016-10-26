using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework {

    public struct LayoutSetting {
        public float Width { get; set; }
        public float MinWidth { get; set; }
        public float MaxWidth { get; set; }
        public float Height { get; set; }
        public float MinHeight { get; set; }
        public float MaxHeight { get; set; }
        public bool ExpandWidth { get; set; }
        public bool ExpandHeight { get; set; }
    }

    public interface ILayoutable { 
        GUILayoutOption[] LayoutOptions { get;}
        float Width { get; set; }
        float MinWidth { get; set; }
        float MaxWidth { get; set; }
        float Height { get; set; }
        float MinHeight { get; set; }
        float MaxHeight { get; set; }
        bool ExpandWidth { get; set; }
        bool ExpandHeight { get; set; }

        void RenderLayout();
    }
}
