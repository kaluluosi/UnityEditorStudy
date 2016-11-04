using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;

namespace EditorFramework.Controls {
    public class TabItem:Control {

        public TabItem(string text) {
            this.text = text;
        }

        public TabItem(string text,string iconPath):this(text) {
            ImagePath = iconPath;
        }

    }
}
