using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Controls {
    public abstract class SliderBase:Control {

        public float Value { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public GUIStyle SliderStyle { get; set; }
        public GUIStyle ThumbStyle { get; set; }
        protected bool horizontal = true;


    }
}
