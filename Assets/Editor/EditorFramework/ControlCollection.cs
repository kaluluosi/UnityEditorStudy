

using System;
using System.Collections.ObjectModel;

namespace EditorFramework{

    /// <summary>
    /// 控件集合
    /// </summary>
    public class ControlCollection:Collection<Control>
    {   
        private Control owner;

        public ControlCollection(Control owner){
            this.owner = owner;
        }

        protected override void InsertItem(int index, Control item){
            if(item is Window)
                throw new ArgumentException("item 不能是Window类型");

            item.Owner = owner;
            base.InsertItem(index,item);
        }

        protected override void RemoveItem(int index){
            this[index].Owner = null;
            base.RemoveItem(index);
        }

        public void DrawAll()
        {
            foreach(Control ctrl in this)
            {
                ctrl.Draw();
            }
        }
    }


}