using System.Collections.Generic;
using System.Reflection;

namespace EditorFramework
{
    public struct PropertyCache
    {
        public object Instance { get; private set; }
        public PropertyInfo PropertyInfo { get; private set; }

        public object Value
        {
            get
            {
                return PropertyInfo.GetValue(Instance, null);
            }

            set
            {
                PropertyInfo.SetValue(Instance, value, null);
            }
        }

        public PropertyCache(object instance, PropertyInfo property)
        {
            Instance = instance;
            PropertyInfo = property;
        }
    }

    public struct FieldCache
    {
        public object Instance { get; private set; }
        public FieldInfo FieldInfo { get; private set; }

        public object Value
        {
            get
            {
                return FieldInfo.GetValue(Instance);
            }

            set
            {
                FieldInfo.SetValue(Instance, value);
            }
        }

        public FieldCache(object instance, FieldInfo field)
        {
            Instance = instance;
            FieldInfo = field;
        }
    }

    public static class PropertyExtension
    {
        private static Dictionary<string, PropertyCache> propertyCache = new Dictionary<string, PropertyCache>();
        private static Dictionary<string, FieldCache> fieldCache = new Dictionary<string, FieldCache>();

        public static string GetCacheHash(this object obj, string propertyPath)
        {
            return obj.GetType().FullName+obj.GetHashCode().ToString() + propertyPath;
        }

        public static object GetPropertyValue(this object obj, string propertyPath)
        {
            return obj.GetPropertyValue(propertyPath, propertyPath);
        }

        public static void SetPropertyValue(this object obj, string propertyPath, object value)
        {
            obj.SetPropertyValue(propertyPath, value, propertyPath);
        }

        public static PropertyCache GetPropertyCache(this object obj, string propertyPath)
        {
            return GetPropertyCache(obj, propertyPath, propertyPath);
        }

        private static PropertyCache GetPropertyCache(this object obj,string propertyPath,string fullPropertyPath){
            //如果有缓存就从缓存里拿
            if (propertyCache.ContainsKey(propertyPath))
            {
                return propertyCache[obj.GetCacheHash(fullPropertyPath)];
            }

            string[] paths = propertyPath.Split('.');
            if (paths.Length == 1)
            {
                PropertyInfo propInfo = obj.GetType().GetProperty(paths[0]);
                if (propInfo == null)
                    throw new MemberNotFoundException(obj.GetType().Name, paths[0]);

                //缓存属性
                return propertyCache[obj.GetCacheHash(fullPropertyPath)] = new PropertyCache(obj, propInfo);
            }
            else
            {
                int index = propertyPath.IndexOf('.');
                string nextPath = propertyPath.Substring(index + 1);
                object value = obj.GetType().GetProperty(paths[0]).GetValue(obj, null);
                return value.GetPropertyCache(nextPath, fullPropertyPath);
            }
        }

        private static object GetPropertyValue(this object obj, string propertyPath, string fullPropertyPath)
        {

            //如果有缓存就从缓存里拿
            if (propertyCache.ContainsKey(propertyPath))
            {
                return propertyCache[obj.GetCacheHash(fullPropertyPath)].Value;
            }

            if (propertyPath == ".")
                return obj;

            string[] paths = propertyPath.Split('.');
            if (paths.Length == 1)
            {
                PropertyInfo propInfo = obj.GetType().GetProperty(paths[0]);
                if (propInfo == null)
                    throw new MemberNotFoundException(obj.GetType().Name, paths[0]);

                //缓存属性
                propertyCache[obj.GetCacheHash(fullPropertyPath)] = new PropertyCache(obj, propInfo);

                object value = propInfo.GetValue(obj, null);
                return value;
            }
            else
            {
                int index = propertyPath.IndexOf('.');
                string nextPath = propertyPath.Substring(index + 1);
                object value = obj.GetType().GetProperty(paths[0]).GetValue(obj, null);
                return value.GetPropertyValue(nextPath, fullPropertyPath);
            }
        }

        private static void SetPropertyValue(this object obj, string propertyPath, object value, string fullPropertyPath)
        {
            //如果有缓存就从缓存里拿
            if (propertyCache.ContainsKey(propertyPath))
            {
                PropertyCache pc = propertyCache[obj.GetCacheHash(fullPropertyPath)];
                pc.Value = value;
            }

            string[] paths = propertyPath.Split('.');
            if (paths.Length == 1)
            {
                PropertyInfo propInfo = obj.GetType().GetProperty(paths[0]);
                if (propInfo == null)
                    throw new MemberNotFoundException(obj.GetType().Name, paths[0]);

                //缓存属性
                propertyCache[obj.GetCacheHash(fullPropertyPath)] = new PropertyCache(obj, propInfo);

                propInfo.SetValue(obj, value, null);
            }
            else
            {
                int index = propertyPath.IndexOf('.');
                string nextPath = propertyPath.Substring(index + 1);
                object curObj = obj.GetType().GetProperty(paths[0]).GetValue(obj, null);
                curObj.SetPropertyValue(nextPath, value, fullPropertyPath);
            }
        }


    }

}
