using System;

namespace EditorFramework.Controls {
    public class TextChangedEventArgs:EventArgs {

        public string OldValue { get; set; }
        public string NewValue { get; set; }

    }
}