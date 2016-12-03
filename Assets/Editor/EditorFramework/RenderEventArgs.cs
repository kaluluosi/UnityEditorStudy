using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;

namespace EditorFramework
{
    public class RenderEventArgs:EventArgs
    {
        public DrawCanvas Canvas { get; set; }
    }
}
