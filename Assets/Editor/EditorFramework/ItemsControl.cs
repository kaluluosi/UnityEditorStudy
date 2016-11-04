using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework {
    public class ItemsControl:Control {

        public event EventHandler<SelectedChangedEventArgs> SelectedChangedEvent;
        public List<GUIContent> Items { get; set; }

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

        private GUIContent selectedItem;
        public GUIContent SelectedItem
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
