﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Controls {
    public abstract class SliderBase:Control {

        public event EventHandler<ValueChangeEventArgs> ValueChangedEvent;

        private float value;
        public float Value {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                OnValueChanged(this.value, value);
            }
        }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public GUIStyle SliderStyle { get; set; }
        public GUIStyle ThumbStyle { get; set; }


        protected void OnValueChanged(float oldValue, float newValue)
        {
            if (ValueChangedEvent != null)
                ValueChangedEvent(this, new ValueChangeEventArgs() { OldValue=oldValue,NewValue=newValue });
        }
    }
}
