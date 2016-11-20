using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework
{
    public abstract class ControlContainer:Control
    {

        public List<Control> Items { get; set; }

        public ControlContainer()
        {
            Items = new List<Control>();
        }
    }
}
