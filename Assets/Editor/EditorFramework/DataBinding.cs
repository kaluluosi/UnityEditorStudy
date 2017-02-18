using System;
using UnityEngine;

namespace EditorFramework
{



    public class DataBinding
    {
        /// <summary>
        /// 数据源路径
        /// </summary>
        public string SourcePath { get; set; }
        /// <summary>
        /// 目标变量路径
        /// </summary>
        public string TargetPath { get; set; }

        public Func<object, object> Converter;

        public string StringFormat { get; set; }

        /// <summary>
        /// 宿主实例
        /// </summary>
        public UIFramework HostInstance { get; set; }

        public DataBinding(string target, string source)
        {
            SourcePath = source;
            TargetPath = target;
        }


        public virtual void Init(UIFramework hostInstance)
        {
            HostInstance = hostInstance;
        }

        public virtual void Update()
        {
            try
            {
                object sourceValue = HostInstance.DataContext.GetPropertyValue(SourcePath);
                object targetValue = null;
                if (Converter == null)
                {
                    Type targetType = HostInstance.GetPropertyCache(TargetPath).PropertyInfo.PropertyType;
                    if (targetType == typeof(string) && !string.IsNullOrEmpty(StringFormat))
                        targetValue = string.Format(StringFormat, Convert.ChangeType(sourceValue, targetType));
                    else
                        targetValue = Convert.ChangeType(sourceValue, targetType);
                }
                else
                {
                    targetValue = Converter(sourceValue);
                }

                HostInstance.SetPropertyValue(TargetPath, targetValue);
            }
            catch (Exception e)
            {
                Debug.LogFormat("[DataBinding]{0}", e.Message);
            }
        }
    }

}
