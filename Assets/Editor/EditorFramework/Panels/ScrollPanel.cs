using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;


namespace EditorFramework
{
    public class ScrollPanel:StackPanel
    {
        public Vector2 ScrollPosistion { get; set; }

        public bool VerticalScrollBarVisibility { get; set; }
        public bool HorizontalScrollBarVisibility { get; set; }


        protected override void RenderContent()
        {

            ScrollPosistion = GUILayout.BeginScrollView(ScrollPosistion,Style,LayoutOptions);
            base.RenderContent();
            GUILayout.EndScrollView();
            UpdatePosition();
        }
    }
}
