using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework {
    public class ItemsControl:ControlContainer {

        public event EventHandler<SelectedChangedEventArgs> SelectedChangedEvent;


        private int selected = 0;
        public int Selected {
            get
            {
                return selected;
            }
            set
            {
                if (selected != value) {
                    int old = selected;
                    selected = value;
                    OnSelectedChanged(old, value);
                }
            }
        }

        private Control selectedItem;
        public Control SelectedItem
        {
            get
            {
                return selectedItem = Items[Selected];
            }
            set
            {
                if (Items.Contains(value)) {
                    Selected = Items.IndexOf(value);
                    selectedItem = value;
                }
            }
        }


        public void OnSelectedChanged(int oldSelected,int newSelected) {
            if (SelectedChangedEvent != null)
                SelectedChangedEvent(
                    this,
                    new SelectedChangedEventArgs() {
                        OldSelected = oldSelected,
                        NewSelected = newSelected
                    });
        }

    }
}
