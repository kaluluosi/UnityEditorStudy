
using System;

namespace EditorFramework.Input {
    /// <summary>
    /// 让对象支持鼠标键盘输入事件的接口
    /// </summary>
    public interface IInputElement {
        event EventHandler<ClickEventArgs> ClickEvent;
        event EventHandler<MouseLeftDownEvenArgs> MouseLeftDownEvent;
        event EventHandler<MouseRightDownEventArgs> MouseRightDownEvent;
    }
}
