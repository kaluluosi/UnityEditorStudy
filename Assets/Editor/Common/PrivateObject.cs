using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestTool.Common
{
    /// <summary>
    /// 私有对象代理，用这个类可以包装任何对象间接调用对象的私有方法和成员。
    /// </summary>
    public class PrivateObject
    {
        private object instance;
        public PrivateObject(object instance)
        {
            this.instance = instance;
        }

        public object Instance
        {
            get
            {
                return instance;
            }
        }

        public object this[string field]
        {
            get
            {
                return GetPrivateField<object>(instance, field);
            }
            set
            {
                SetPrivateField(instance, field, value);
            }
        }

        public T GetField<T>(string field)
        {
            return (T)GetPrivateField<object>(instance, field);
        }

        public void SetField<T>(string field, T value)
        {
            SetPrivateField(instance, field, value);
        }

        public T Invoke<T>(string method, params object[] values)
        {
            return CallPrivateMethod<T>(instance, method, false, values);
        }

        public void Invoke(string method)
        {
            CallPrivateMethod<object>(instance, method, false, null);
        }

        public T InvokeStatic<T>(string method, params object[] values)
        {
            return CallPrivateMethod<T>(instance, method, true, values);
        }
        public T MemberwiseClone<T>()
        {
            return CallPrivateMethod<T>(instance, "MemberwiseClone");
        }

        #region 反射方法
        private T GetPrivateField<T>(object instance, string fieldname)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();
            FieldInfo field = type.GetField(fieldname, flag);
            return (T)field.GetValue(instance);
        }

        private void SetPrivateField(object instance, string fieldname, object value)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();
            FieldInfo field = type.GetField(fieldname, flag);
            field.SetValue(instance, value);
        }

        private T GetPrivateProperty<T>(object instance, string propertyname)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();
            PropertyInfo field = type.GetProperty(propertyname, flag);
            return (T)field.GetValue(instance, null);
        }

        private void SetPrivateProperty(object instance, string propertyname, object value)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            Type type = instance.GetType();
            PropertyInfo field = type.GetProperty(propertyname, flag);
            field.SetValue(instance, value, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="instance"></param>
        /// <param name="name"></param>
        /// <param name="param"></param>
        /// <param name="isStatic"></param>
        /// <returns></returns>
        private T CallPrivateMethod<T>(object instance, string name, bool isStatic = false, params object[] param)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.NonPublic;
            if (isStatic)
                flag |= BindingFlags.Static;
            Type type = instance.GetType();
            MethodInfo method = type.GetMethod(name, flag);
            return (T)method.Invoke(instance, param);
        }



        #endregion
    }
}

