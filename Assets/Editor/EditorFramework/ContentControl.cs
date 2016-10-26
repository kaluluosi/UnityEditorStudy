
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace EditorFramework {
    public abstract class ContentControl:Control {
        public string Text { get; set; }
        public string ToolTip { get; set; }
        public string Image { get; set; }


        public GUIContent Content
        {
            get
            {
                Texture img = LoadImage(Image);
                return new GUIContent(Text, img, ToolTip);
            }
        }

    }
}
