using UnityEngine;
using UnityEditor;

namespace EditorFramework
{

    /// <summary>
    /// 控件容器
    /// </summary>
    public interface IControlContainer
    {
         ControlCollection Controls { get; }
    }

}