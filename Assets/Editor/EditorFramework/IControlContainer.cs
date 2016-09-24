using UnityEngine;
using UnityEditor;

namespace EditorFramework
{

    public interface IControlContainer
    {
         ControlCollection Controls { get; }
    }

}