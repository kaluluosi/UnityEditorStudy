using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework
{
    public abstract class ControlContainer:Control
    {

        public ControlCollection Items { get; set; }

        public ControlContainer()
        {
            Items = new ControlCollection(this);
        }
    }
}
