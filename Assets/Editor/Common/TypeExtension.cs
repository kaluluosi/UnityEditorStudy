using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TestTool.Common
{
    public static class TypeExtension
    {

        public static TResult Invoke<TResult>(this Type type, string methodName, params object[] param)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;
            MethodInfo method = type.GetMethod(methodName, flag);
            return (TResult)method.Invoke(null, param);
        }

        public static void Invoke(this Type type, string methodName, params object[] param)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static;
            MethodInfo method = type.GetMethod(methodName, flag);
            method.Invoke(null, param);
        }

    }
}
