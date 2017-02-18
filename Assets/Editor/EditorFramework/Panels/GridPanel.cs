using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panels
{
    /// <summary>
    /// 网格式面板
    /// </summary>
    public class GridPanel:Panel
    {
        public int Col { get; set; }
        private Vector2 cellSize=new Vector2(-1,-1);

        public GridPanel()
        {
            Col = 4;
        }

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
            int row = Mathf.CeilToInt(Items.Count / (float)Col);

            if (Initialized)
            {
                cellSize.x = Width / Col;
                cellSize.y = Height / row;
            }


            GUILayout.BeginVertical(this,Style,LayoutOptions);


            for (int r = 0; r < row; r++)
            {
                GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                for (int c = 0; c < Col; c++)
                {
                    GUILayout.BeginHorizontal(GUILayout.Width(cellSize.x),GUILayout.Height(cellSize.y));

                    int index = r * Col + c;
                    if (index < Items.Count)
                    {
                        Control item = Items[index];
                        item.RenderLayout();
                    }

                    GUILayout.EndHorizontal();

                }
                GUILayout.EndHorizontal();

            }

            GUILayout.EndVertical();

        }

    }
}
