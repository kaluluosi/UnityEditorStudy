using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panel
{
    public class GridPanel:Panel
    {
        public int Col { get; set; }
        private Vector2 cellSize=new Vector2(-1,-1);

        public Vector2 CellSize
        {
            get { return cellSize; }
            set { cellSize = value; }
        }

        protected override void UpdatePosition()
        {
            cellSize.x = Width / Col - 4;

            base.UpdatePosition();
        }

        protected override void RenderContent()
        {
            GUILayout.BeginVertical(this,Style,LayoutOptions);
            for (int i = 0; i < Items.Count; i+=Col)
            {
                GUILayout.BeginHorizontal(LayoutOptions);

                for (int c = 0; c < Col; c++)
                {
                    if (i + c < Items.Count)
                    {
                        Control item= Items[i + c];
                        if (!initialized){
                            item.AdaptWidth = AdaptMode.Expand;
                        }
                        else
                        {
                            item.AdaptWidth = AdaptMode.Fixed;
                            item.FixedWidth = cellSize.x;
                        }
                        item.RenderLayout();
                    }
                }

                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }

    }
}
