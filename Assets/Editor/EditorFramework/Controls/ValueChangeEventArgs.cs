using System;

namespace EditorFramework.Controls
{
    public class ValueChangeEventArgs : EventArgs
    {
        public float NewValue { get; internal set; }
        public float OldValue { get; internal set; }
    }
}