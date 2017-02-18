using System;

namespace EditorFramework {
    public class CheckedEventArgs:EventArgs {

        public bool OldValue { get; set; }
        public bool NewValue { get; set; }
    }
}