using System;
using UnityEngine;

namespace EditorFramework.Input {
    public class MouseEventArgs :EventArgs{

        public Vector2 Position { get; set; }

        public MouseEventArgs() {
            Position = Event.current.mousePosition;
        }
    }
}