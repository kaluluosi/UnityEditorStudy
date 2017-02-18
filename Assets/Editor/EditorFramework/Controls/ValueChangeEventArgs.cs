using System;

namespace EditorFramework
{
    public class ValueChangeEventArgs : EventArgs
    {
        public float NewValue { get; internal set; }
        public float OldValue { get; internal set; }
    }
}