using UnityEngine;

namespace EditorFramework
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
