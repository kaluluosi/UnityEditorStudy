using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;
using UnityEditor;
using UnityEngine;
using EditorFramework.Controls;

namespace Assets.Editor.Sample.EditorFramework
{
   public  class EditorStylesDemo:EditorWindowEx
    {
        [MenuItem("EditorFramework/EditorStyles")]
        static void Init()
        {
            GetWindow<EditorStylesDemo>();
        }

        public EditorStylesDemo()
        {
            var properties = typeof(EditorStyles).GetProperties();

            foreach (var prop in properties)
            {
                string name = prop.Name;
                GUIStyle style = prop.GetValue(null, null) as GUIStyle;
                Controls.Add(new Button(name,"This is "+name) { Style = style, Width = 200 });
            }

        }
    }
}
