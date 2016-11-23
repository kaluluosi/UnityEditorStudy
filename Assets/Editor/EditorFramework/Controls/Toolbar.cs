using System;
using EditorFramework.Panel;
using UnityEngine;

namespace EditorFramework.Controls
{

    public class Toolbar : StackPanel
    {

        public Toolbar()
        {
            StyleName = "toolbar";
            AdaptWidth = AdaptMode.Expand;
            Orientation = Direction.Horiziontal;
        }


//         public override void Render()
//         {
//             GUI.BeginGroup(Position, this);
//             GUILayout.BeginHorizontal(Style, GUILayout.Width(Width), GUILayout.Height(Height));
//             foreach (var item in Items)
//             {
//                 item.RenderLayout();
//             }
//             GUILayout.EndHorizontal();
//             GUI.EndGroup();
//             base.Render();
//         }
// 
//         public override void RenderLayout()
//         {
//             GUILayout.BeginHorizontal(Style,LayoutOptions);
//             foreach (var item in Items)
//             {
//                 item.RenderLayout();
//             }
//             GUILayout.EndHorizontal();
//             base.RenderLayout();
//         }

    }
}
