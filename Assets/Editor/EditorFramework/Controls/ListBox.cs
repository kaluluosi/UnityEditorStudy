using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    /// <summary>
    /// 列表控件，仅支持固定高度的内容控件
    /// </summary>
    public class ListBox : ItemsControl
    {

        public class Styles
        {
            public const string EvenBackground = "CN EntryBackEven";
            public const string OddBackground = "CN EntryBackodd";
        }

        public Vector2 ScrollPosistion { get; set; }
        public float RowHeight { get; set; }
        public bool Selectable { get; set; }

        private Vector2 scrollToPosistion = Vector2.zero;
        public void ScrollToPosition(Vector2 position)
        {
            scrollToPosistion = position;
        }

        public void ScrollToEnd()
        {
            scrollToPosistion = new Vector2(0, RowHeight * Items.Count);
        }

        public override void RenderLayout()
        {

            if (scrollToPosistion != Vector2.zero && Event.current.type == EventType.repaint)
            {
                ScrollPosistion = scrollToPosistion;
                scrollToPosistion = Vector2.zero;
            }

            ScrollPosistion = GUILayout.BeginScrollView(ScrollPosistion, Style, LayoutOptions);
            float totalHeight = Items.Count * RowHeight;
            GUILayout.Box("", GUIStyle.none, GUILayout.Height(totalHeight));

            for (int i = 0; i < Items.Count; i++)
            {
                Control curItem = Items[i];

                //取第一个item的fixedheight来初始化Row高度
                if(i==0)
                    RowHeight = curItem.AdaptHeight==AdaptMode.Fixed?curItem.FixedHeight:curItem.ContentSize.y;

                float x = 0f;
                float y = i * RowHeight;

                float w = this.Width;
                float h = RowHeight;

                Rect rect = new Rect(x, y, w, h);

                curItem.Position = rect;

                bool result = IsInView(x, y, w, h);

                if (result)
                {
                    GUIStyle style = i % 2 == 0 ? Styles.EvenBackground : Styles.OddBackground;

                    if (Event.current.type == EventType.repaint)
                        style.Draw(rect, false, false, Selectable == true ?Selected == i : false, false);

                    curItem.Render();


                    if (Event.current.isMouse && Event.current.type == EventType.mouseDown)
                    {
                        if (rect.Contains(Event.current.mousePosition))
                        {
                            Selected = i;
                            GUIUtility.keyboardControl = 0;
                            EditorWindow.focusedWindow.Repaint();
                        }
                    }

                }
            }
            GUILayout.EndScrollView();

            base.RenderLayout();
        }

        private bool IsInView(float x, float y, float w, float h)
        {
            Rect rect = new Rect(x, y, w, h);
            Rect area = new Rect() { position = ScrollPosistion, size = Size };

            Vector2 p1 = rect.position;
            Vector2 p2 = new Vector2(rect.x + rect.width, rect.y);
            Vector2 p3 = new Vector2(rect.x, rect.y + rect.height);
            Vector2 p4 = new Vector2(rect.x + rect.width, rect.y + rect.height);

            bool result = area.Contains(p1) || area.Contains(p2) || area.Contains(p3) || area.Contains(p4);

            return result;
        }


    }
}
