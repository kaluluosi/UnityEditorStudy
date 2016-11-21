using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework {
    public class EditorWindowEx :EditorWindow{

       public void ShowNotification(string message) {
            ShowNotification(new GUIContent(message));
        }

    }
}
