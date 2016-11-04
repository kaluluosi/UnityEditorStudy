using System;

namespace EditorFramework.Input {
    public interface IClickHandler {
        event EventHandler<MouseEventArgs> ClickEvent;
    }
}