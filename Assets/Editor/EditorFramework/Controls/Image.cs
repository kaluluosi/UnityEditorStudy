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
            AlphaBlend = true;
        }

        public override void Render() {
            GUI.DrawTexture(Position, LoadImage(Path), Mode, AlphaBlend);

            base.Render();
        }

        public override void RenderLayout() {
            GUILayout.Box(new GUIContent(LoadImage(Path)), GUIStyle.none);

            base.RenderLayout();
        }

    }
}
