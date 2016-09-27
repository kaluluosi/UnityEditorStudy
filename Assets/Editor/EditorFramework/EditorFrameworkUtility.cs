using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class EditorFrameworkUtility
    {
        public const string MENU_DESIGN_MODE_ON = "EditorFramework/Design Mode On";
        public const string MENU_DESIGN_MODE_OFF = "EditorFramework/Design Mode Off";
        public static bool IsDesignMode { get; set; }

        [MenuItem(EditorFrameworkUtility.MENU_DESIGN_MODE_ON)]
        public static void DesignModeOn()
        {
            IsDesignMode = true;
        }

        [MenuItem(EditorFrameworkUtility.MENU_DESIGN_MODE_OFF)]
        public static void DesignModeOff()
        {
            IsDesignMode = false;
        }

    }
}
