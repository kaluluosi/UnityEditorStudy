using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework
{
    /// <summary>
    /// 窗口容器
    /// </summary>
    public interface IWindowContainer
    {
        List<Window> Windows { get;  }
    }
}
