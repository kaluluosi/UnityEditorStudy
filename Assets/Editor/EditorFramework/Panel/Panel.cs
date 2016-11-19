

using UnityEditor;
using UnityEngine;

namespace EditorFramework.Panel {
    public class Panel:ControlContainer {


        public override void Render()
        {
            GUI.BeginGroup(Position,this,Style);
            foreach (var item in Items)
                item.Render();
            GUI.EndGroup();
            base.Render();
        }

        public override void RenderLayout()
        {

            foreach (var item in Items)
                item.Render();
            GUI.EndGroup();
            base.RenderLayout();
        }

    }
}
