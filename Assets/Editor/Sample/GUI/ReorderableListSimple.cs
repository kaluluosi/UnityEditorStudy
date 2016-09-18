using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
using System.Collections.Generic;


public class ReorderableListSimple:EditorWindow
{
    [MenuItem("GUI/ReorderableListSimple")]
    static void Init(){
        GetWindow<ReorderableListSimple>();
    }

    ReorderableList reorderableList;
    List<string> strs = new List<string>(){"1","2","3"};

    void OnGUI(){
        reorderableList.DoLayoutList();
    }

    void OnEnable(){
        Debug.Log(this.GetType().Name+" Enable");
        reorderableList = new ReorderableList(strs,typeof(string));
        reorderableList.drawHeaderCallback+=drawHeaderCallback;
    }

    void drawHeaderCallback(Rect rect){
        GUI.Label(rect,"test header");
    }
}