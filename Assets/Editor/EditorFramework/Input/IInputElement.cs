
using System;

namespace EditorFramework.Input {
    /// <summary>
    /// 让对象支持鼠标键盘输入事件的接口
    /// </summary>
    public interface IInputElement {
        #region Mouse Events
        event EventHandler<MouseEventArgs> MouseLeftDownEvent;
        event EventHandler<MouseEventArgs> MouseRightDownEvent;
        event EventHandler<MouseEventArgs> MouseMiddleDownEvent;
        event EventHandler<MouseEventArgs> MouseLeftUpEvent;
        event EventHandler<MouseEventArgs> MouseRightUpEvent;
        event EventHandler<MouseEventArgs> MouseMiddleUpEvent;
        event EventHandler<MouseEventArgs> MouseDoubleClickEvent;
        
        event EventHandler<MouseEventArgs> DragEvent;
        event EventHandler<MouseEventArgs> DragExitEvent;
        #endregion


        #region Keyboard Events

        #endregion
    }
}
