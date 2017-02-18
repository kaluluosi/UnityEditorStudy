using System.Collections.ObjectModel;

namespace EditorFramework
{
    public class ControlCollection :Collection<Control> {

        public Control Owner { get; set; }

        public ControlCollection(Control owner) {
            Owner = owner;
        }

        protected override void InsertItem(int index, Control item) {
            item.VisualParent = Owner;
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index) {
            base.RemoveItem(index);
            this[index].VisualParent = null;
        }

        protected override void SetItem(int index, Control item) {
            item.VisualParent = Owner;
            base.SetItem(index, item);
        }


    }
}
