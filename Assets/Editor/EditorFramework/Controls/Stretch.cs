using EditorFramework.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Controls
{
    public class Stretch:Control
    {
        public Stretch(Direction direction)
        {
            if (direction == Direction.Horiziontal)
            {
                AdaptWidth = AdaptMode.Expand;
            }
            else if(direction==Direction.Vertical)
            {
                AdaptHeight = AdaptMode.Expand;
            }
        }

        public override void RenderLayout()
        {
            GUILayout.Box("", GUIStyle.none, LayoutOptions);
            base.RenderLayout();
        }
    }
}
