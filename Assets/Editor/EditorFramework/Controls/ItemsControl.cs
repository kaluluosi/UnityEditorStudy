using System;
using System.Collections.Generic;
using UnityEngine;
using EditorFramework;
using System.Collections;
using System.Reflection;

namespace EditorFramework
{
    public class ItemsControl : Control, IControlContainer
    {

        public event EventHandler<SelectedChangedEventArgs> SelectedChangedEvent;


        public  ControlCollection Items { get; set; }

        public ItemsControl()
        {
            Items = new ControlCollection(this);
        }


        private int selected = 0;
        public int Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (selected != value)
                {
                    int old = selected;
                    selected = value;
                    OnSelectedChanged(old, value);
                }
            }
        }

        public Control SelectedItem
        {
            get
            {
                if (Items.Count == 0)
                    return null;
                else
                    return Items[selected];
            }
            set
            {
                if (Items.Contains(value))
                {
                    Selected = Items.IndexOf(value);
                }
            }
        }

        public void OnSelectedChanged(int oldSelected, int newSelected)
        {
            if (SelectedChangedEvent != null)
                SelectedChangedEvent(
                    this,
                    new SelectedChangedEventArgs()
                    {
                        OldSelected = oldSelected,
                        NewSelected = newSelected
                    });
        }
    }
}
