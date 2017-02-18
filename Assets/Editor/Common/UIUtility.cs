using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;
using System;
using UnityEditor;

/// <summary>
/// UI驱动器
/// </summary>
namespace TestTool.Common
{
	public static class UIUtility  {
	
	
	    /// <summary>
	    /// 直接调用对象的EventTrigger来点击,兼容Botton和IPointerHandler等所有UI的点击时间
	    /// </summary>
	    /// <param name="path"></param>
	    public static void Click(string path)
	    {
	        try
	        {
	            GameObject go = GameObject.Find(path);
	            var eventData = new PointerEventData(EventSystem.current);
	            eventData.position = go.transform.position;
	            eventData.rawPointerPress = go;
	            eventData.pointerPress = go;
	            
	            ExecuteEvents.Execute(go, eventData, ExecuteEvents.pointerClickHandler);

                //Button btn = go.GetComponent<Button>();
                //if (btn != null)
                //{
                //    btn.onClick.Invoke();
                //}
	            Debug.Log("点击事件" + path);
	        }
	        catch (Exception e)
	        {
	            Debug.Log(e.Message);
	        }
	    }
	
	    /// <summary>
	    /// 查找transform对象在hierarchy里的路径
	    /// </summary>
	    /// <param name="transform"></param>
	    /// <param name="path"></param>
	    /// <returns></returns>
	    private static string GetPath(Transform transform, string path)
	    {
	        if (transform.parent == null)
	            return path;
	
	        return GetPath(transform.parent, transform.parent.name + "/" + path);
	    }

        [MenuItem("GameObject/复制GameObject路径", false,20)]
        public static void GetUIPath(MenuCommand menuCommand)
        {
            string path = GetPath((menuCommand.context as GameObject));
            GUIUtility.systemCopyBuffer = path;
        }

	
	    /// <summary>
	    /// 直接获取GameObject在hierarchy里的路径
	    /// </summary>
	    /// <param name="go"></param>
	    /// <returns></returns>
	    public static string GetPath(GameObject go)
	    {
	        return GetPath(go.transform, go.name);
	    }
	    
	    /// <summary>
	    /// 循环等待查找某个元素
	    /// </summary>
	    /// <param name="path"></param>
	    /// <returns></returns>
	    public static IEnumerator WaitForElement(string path)
	    {
	        while (GameObject.Find(path) == null)
	        {
	            yield return new WaitForSeconds(1);
	            Debug.Log("等待查找"+path);
	        }
	        Debug.Log("成功找到" + path);
	        yield return null;
	    }
	
	    public static T Find<T>(string path) where T:MonoBehaviour
	    {
	        return GameObject.Find(path).GetComponent<T>();
	    }


	}
}
