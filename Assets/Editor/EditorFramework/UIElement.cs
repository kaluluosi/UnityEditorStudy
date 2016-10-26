using System;
using EditorFramework.Input;
using UnityEditor;
using UnityEngine;

namespace EditorFramework {
    public abstract class UIElement : Visual, IInputElement {
        public event EventHandler<ClickEventArgs> ClickEvent;
        public event EventHandler<MouseLeftDownEvenArgs> MouseLeftDownEvent;
        public event EventHandler<MouseRightDownEventArgs> MouseRightDownEvent;

        protected bool IsMousePositionInside
        {
            get
            {
                return Position.Contains(Event.current.mousePosition);
            }
        }

        protected virtual void OnMouseLeftDown() {
            if (MouseLeftDownEvent != null)
                MouseLeftDownEvent(this,new MouseLeftDownEvenArgs() { Position=Event.current.mousePosition});
        }
        protected virtual void OnMouseRightDown() {
            if (MouseRightDownEvent != null)
                MouseRightDownEvent(this, new MouseRightDownEventArgs() { Position = Event.current.mousePosition });
        }

        protected virtual void OnClick() {
            if (ClickEvent != null)
                ClickEvent(this, new ClickEventArgs() { Position = Event.current.mousePosition });
        }

    }
}
