using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EditorFramework
{
    public class BindingCollection : Collection<DataBinding>
    {
        public UIFramework Owner { get; set; }

        public BindingCollection(UIFramework owner)
        {
            Owner = owner;
        }

        protected override void InsertItem(int index, DataBinding item) {
            item.HostInstance = Owner;
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index) {
            base.RemoveItem(index);
            this[index].HostInstance = null;
        }

        protected override void SetItem(int index, DataBinding item)
        {
            item.HostInstance = Owner;
            base.SetItem(index, item);
        }


    }
}
