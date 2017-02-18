using System;
using EditorFramework.Input;
using UnityEngine;

namespace EditorFramework
{
    public abstract class UIElement : Visual, IInputElement {


        public event EventHandler<MouseEventArgs> MouseLeftDownEvent;
        public event EventHandler<MouseEventArgs> MouseRightDownEvent;
        public event EventHandler<MouseEventArgs> MouseMiddleDownEvent;
        public event EventHandler<MouseEventArgs> MouseLeftUpEvent;
        public event EventHandler<MouseEventArgs> MouseRightUpEvent;
        public event EventHandler<MouseEventArgs> MouseMiddleUpEvent;
        public event EventHandler<MouseEventArgs> MouseDoubleClickEvent;

        public event EventHandler<MouseEventArgs> DragEvent;
        public event EventHandler<MouseEventArgs> DragExitEvent;

        /// <summary>
        /// ²¶×½Êó±ê
        /// </summary>
        public bool CapMouse { get; set; }

        protected bool IsMousePositionInside
        {
            get
            {
                if (CapMouse) return true;
                return Position.Contains(Event.current.mousePosition);
            }
        }

        protected virtual void OnMouseLeftDown() {
            if (MouseLeftDownEvent != null)
            {
                MouseLeftDownEvent(this,new MouseEventArgs());
            }

            if (MouseDoubleClickEvent != null && Event.current.clickCount > 1)
            {
                MouseDoubleClickEvent(this, new MouseEventArgs());
            }
        }

        protected virtual void OnMouseRightDown() {
            if (MouseRightDownEvent != null)
                MouseRightDownEvent(this, new MouseEventArgs());
        }

        protected virtual void OnMouseMiddleDown() {
            if (MouseMiddleDownEvent != null)
                MouseMiddleDownEvent(this, new MouseEventArgs());
        }
        protected virtual void OnMouseLeftUp()
        {
            if (MouseLeftUpEvent != null)
                MouseLeftUpEvent(this, new MouseEventArgs());
        }

        protected virtual void OnMouseRightUp()
        {
            if (MouseRightUpEvent != null)
                MouseRightUpEvent(this, new MouseEventArgs());
        }

        protected virtual void OnMouseMiddleUp()
        {
            if (MouseMiddleUpEvent != null)
                MouseMiddleUpEvent(this, new MouseEventArgs());
        }



        protected virtual void OnMouseDrag()
        {
            if (DragEvent != null)
                DragEvent(this, new MouseEventArgs());
        }

        protected virtual void OnMouseDragExist()
        {
            if (DragExitEvent != null)
                DragExitEvent(this, new MouseEventArgs());
        }

        public override void Render() {
            base.Render();
            CheckMouseEvent();
        }

        protected void CheckMouseEvent()
        {
            if (!IsMousePositionInside) return;

            if (Event.current.type == EventType.MouseDown)
            {
                switch (Event.current.button)
                {
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

            if (Event.current.type == EventType.MouseUp)
            {
                switch (Event.current.button)
                {
                    case 0:
                        OnMouseLeftUp();
                        break;
                    case 1:
                        OnMouseRightUp();
                        break;
                    case 2:
                        OnMouseMiddleUp();
                        break;
                }
            }


            if (Event.current.type == EventType.mouseDrag)
            {
                OnMouseDrag();
            }


            if (Event.current.type == EventType.DragExited)
            {
                OnMouseDragExist();
            }
        }
    }
}
