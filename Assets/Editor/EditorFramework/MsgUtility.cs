using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using TestTool.Common;
using EditorFramework.Controls;

namespace EditorFramework
{
    public static class MsgUtility
    {
        public static void ShowNotification(string msg)
        {
            EditorWindow.focusedWindow.ShowNotification(new GUIContent(msg));
        }

        public static void ShowNotification(string msg, string tooltip, string icon)
        {
            object resource = EditorGUIUtility.Load(icon);

            resource=resource==null?EditorGUIUtility.Load("Texture2D Icon"):resource;

            EditorWindow.focusedWindow.ShowNotification(new GUIContent(msg, resource as Texture, tooltip));
        }


        static bool waiting = false;
        static readonly string waitingIcon = "d_WaitSpin0{0}";
        public static void ShowWaiting()
        {
            EditorWindow window = EditorWindow.focusedWindow;
            waiting = true;
            EditorCoroutineRunner.StartEditorCoroutine(displayWaiting(window));
        }

        private static IEnumerator displayWaiting(EditorWindow window)
        {
            int index = 0;
            while (waiting)
            {
                window.ShowNotification(new Image() { ImagePath = string.Format(waitingIcon, index++) });
                if (index > 9)
                    index = 0;
                yield return new WaitForSeconds(1/10f);
            }

            yield return null;
        }

        public static void ClearWaiting()
        {
            waiting = false;
        }

    }
}
