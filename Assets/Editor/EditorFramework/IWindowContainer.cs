using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework
{
    public interface IWindowContainer
    {
        List<Window> Windows { get;  }
    }
}
