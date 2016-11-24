using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Controls {
    public class Image:Control{

        public string Path { get; set; }
        public ScaleMode Mode { get; set; }
        public bool AlphaBlend { get; set; }

        public Image() {
            Path = "Texture2D Icon";
            Mode = ScaleMode.ScaleToFit;
            image = LoadImage(Path);
            AlphaBlend = true;
        }

        public override void Render() {
            GUI.Box(Position, this, Style);
            base.Render();
        }

        public override void RenderLayout() {
            GUILayout.Box(this,Style,LayoutOptions);
            base.RenderLayout();
        }

    }
}
