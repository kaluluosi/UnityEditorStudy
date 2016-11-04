using System;
using UnityEngine;

namespace EditorFramework {
    public class SelectedChangedEventArgs:EventArgs {
        public int OldSelected { get; set; }
        public int NewSelected { get; set; }
    }
}