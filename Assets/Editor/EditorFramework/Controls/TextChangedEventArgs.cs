using System;

namespace EditorFramework {
    public class TextChangedEventArgs:EventArgs {

        public string OldValue { get; set; }
        public string NewValue { get; set; }

    }
}