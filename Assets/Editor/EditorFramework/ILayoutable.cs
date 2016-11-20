using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework {

    public enum AdaptMode
    {
        Auto,
        Expand,
        Fixed
    }

    public interface ILayoutable { 
        GUILayoutOption[] LayoutOptions { get;}

        float FixedWidth { get; set; }
        float MinWidth { get; set; }
        float MaxWidth { get; set; }
        float FixedHeight { get; set; }
        float MinHeight { get; set; }
        float MaxHeight { get; set; }


        AdaptMode AdaptWidth { get; set; }
        AdaptMode AdaptHeight { get; set; }
        void RenderLayout();
    }
}
