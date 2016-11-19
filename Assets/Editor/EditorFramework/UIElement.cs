using System;
using EditorFramework.Input;
using UnityEditor;
using UnityEngine;

namespace EditorFramework {
    public abstract class UIElement : Visual, IInputElement {
        public event EventHandler<MouseEventArgs> MouseLeftDownEvent;
        public event EventHandler<MouseEventArgs> MouseRightDownEvent;
        public event EventHandler<MouseEventArgs> MouseMiddleDownEvent;

        protected bool IsMousePositionInside
        {
            get
            {
                return Position.Contains(Event.current.mousePosition);
            }
        }

        protected virtual void OnMouseLeftDown() {
            if (MouseLeftDownEvent != null)
                MouseLeftDownEvent(this,new MouseEventArgs());
        }
        protected virtual void OnMouseRightDown() {
            if (MouseRightDownEvent != null)
                MouseRightDownEvent(this, new MouseEventArgs());
        }

        protected virtual void OnMouseMiddleDown() {
            if (MouseMiddleDownEvent != null)
                MouseMiddleDownEvent(this, new MouseEventArgs());
        }

        public override void Render() {
            base.Render();
            CheckMouseEvent();
        }

        protected void CheckMouseEvent() {
            if (IsMousePositionInside && Event.current.type == EventType.MouseDown) {
                switch (Event.current.button) {
                    case 0:
                        OnMouseLeftDown();
                        break;
                    case 1:
                        OnMouseRightDown();
                        break;
                    case 2:
                        OnMouseMiddleDown();
                        break;
                }
            }
        }
    }
}
