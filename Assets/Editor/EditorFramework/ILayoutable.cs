using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework {

    public interface ILayoutable { 
        GUILayoutOption[] LayoutOptions { get;}
        float FixedWidth { get; set; }
        float MinWidth { get; set; }
        float MaxWidth { get; set; }
        float FixedHeight { get; set; }
        float MinHeight { get; set; }
        float MaxHeight { get; set; }
        bool ExpandWidth { get; set; }
        bool ExpandHeight { get; set; }

        bool AutoWidth { get; set; }
        bool AutoHeight { get; set; }
        void RenderLayout();
    }
}
