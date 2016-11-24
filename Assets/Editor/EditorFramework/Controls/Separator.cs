using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Controls
{
    public class Separator:Control
    {
        public float Pixels { get; set; }

        public Separator(float pixels)
        {
            Pixels = pixels;
        }

        public override void RenderLayout()
        {
            if (initialized)
                GUILayout.Box(this,Style);
            else
                GUILayout.Space(Pixels);
            base.RenderLayout();
        }
    }
}
