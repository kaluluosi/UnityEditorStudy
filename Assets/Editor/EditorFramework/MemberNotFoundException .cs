using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework
{
    public class MemberNotFoundException : Exception
    {
        public string PropertyName { get; set; }
        public string TypeName { get; set; }

        public MemberNotFoundException(string typeName,string propName)
        {
            PropertyName = propName;
            TypeName = typeName;
        }

        public override string Message
        {
            get
            {
                return string.Format("{0}的{1} 属性没有找到，是不是没有这个属性？",TypeName, PropertyName);
            }
        }

    }
}
