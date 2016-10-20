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
        [MenuItem("GUI/EditorStyles")]
        static void Init()
        {
            GetWindow<EditorStylesDemo>();
        }

        public EditorStylesDemo()
        {
            //EditorStyles里面不仅仅只有GUIStyle 还有别的类型的属性，因此要过滤一下
            var properties = typeof(EditorStyles).GetProperties().Where(p=> p.PropertyType== typeof(GUIStyle));

            foreach (var prop in properties)
            {
                string name = prop.Name;
                GUIStyle style = prop.GetValue(null, null) as GUIStyle;
                Controls.Add(new Button(name, "This is " + name) { Style = style, Width = 200 });
            }

        }
    }
}
