using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework.Controls {
    public abstract class ScrollBarBase:Control {

        public ScrollBarBase() {
            BarSize = 5f;
        }

        public float Value { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public float BarSize { get; set; }
    }
}
