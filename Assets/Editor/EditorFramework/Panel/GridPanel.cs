using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panel
{
    public class GridPanel:Panel
    {
        private Vector2 cellSize=new Vector2(-1,-1);
        private Vector2 space = new Vector2(4, 4);
        private int col = 4;
        public int Col
        {
            get { return col; }
            set { col = value; }
        }


        public Vector2 Space
        {
            get
            {
                return space;
            }

            set
            {
                space = value;
            }
        }
        public Vector2 CellSize
        {
            get { return cellSize; }
            set { cellSize = value; }
        }


        protected override void UpdatePosition()
        {
            cellSize.x = Width / Col - space.x;
            base.UpdatePosition();
        }

        public override void RenderLayout()
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
            base.RenderLayout();
        }
    }
}
