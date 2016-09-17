
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;


public class SelectionGridSimple:EditorWindow
{
        [MenuItem("GUI/SelectionGridSimple")]
    static void Init(){
        GetWindow<SelectionGridSimple>();
    }

    int selected=0;


    void OnGUI(){
        GUILayout.Label("Button Style");
        selected = GUILayout.SelectionGrid(selected,new string[]{"1","2","3"},1);
        GUILayout.Label("EditorStyles.label Style");
        selected = GUILayout.SelectionGrid(selected,new string[]{"1","2","3"},1,EditorStyles.label);
        GUILayout.Label("EditorStyles.helpBox Style");
        selected = GUILayout.SelectionGrid(selected,new string[]{"1","2","3"},1,EditorStyles.helpBox);
        GUILayout.Label("EditorStyles.objectFieldThumb Style");
        selected = GUILayout.SelectionGrid(selected,new string[]{"1","2","3"},1,EditorStyles.objectFieldThumb);
        GUILayout.Label("EditorStyles.whiteLargeLabel Style");
        selected = GUILayout.SelectionGrid(selected,new string[]{"1","2","3"},1,EditorStyles.whiteLargeLabel);
        GUILayout.Label("EditorStyles.toggle Style");
        selected = GUILayout.SelectionGrid(selected,new string[]{"1","2","3"},1,EditorStyles.toggle);
        GUILayout.Label("EditorStyles.toolbarButton Style");
        selected = GUILayout.SelectionGrid(selected,new string[]{"1","2","3"},1,EditorStyles.toolbarButton);
        
    }
}