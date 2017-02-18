using EditorFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
namespace Sample.EditorFramework
{
    public class ListBoxWindow:EditorWindowEx
    {
        [MenuItem("tool/listwindow")]
        public static void Init()
        {
            GetWindow<ListBoxWindow>();
        }

        ListBox listbox;

        public ListBoxWindow()
        {

            listbox = new ListBox();
        }
        

        void OnGUI()
        {
            if (GUILayout.Button("test"))
            {
                for(int i = 0; i < 100; i++)
                {
                    listbox.Items.Add(new StackPanel() { AdaptHeight = AdaptMode.Fixed, FixedHeight = 32,AdaptWidth=AdaptMode.Expand });
                    listbox.ScrollToEnd();
                }
            }
            listbox.RenderLayout();
        }
    }
}
