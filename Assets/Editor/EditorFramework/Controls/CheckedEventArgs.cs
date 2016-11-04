using System;

namespace EditorFramework.Controls {
    public class CheckedEventArgs:EventArgs {

        public bool OldValue { get; set; }
        public bool NewValue { get; set; }
    }
}