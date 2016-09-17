using UnityEditor;
using UnityEngine;


public class SimpleEditorWindow:EditorWindow
{
    
    [MenuItem("EditorWindow/Simple Editor")]
    public static void Init(){
        GetWindow<SimpleEditorWindow>(false,"SimpleEditor");
    }


}