using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework {
    public abstract class ScrollBarBase:Control {

        public event EventHandler<ValueChangeEventArgs> ValueChangedEvent;


        public ScrollBarBase() {
            BarSize = 5f;
        }

        public float Value { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public float BarSize { get; set; }

        protected void OnValueChanged(float oldValue, float newValue)
        {
            if (ValueChangedEvent != null)
                ValueChangedEvent(this, new ValueChangeEventArgs() { OldValue = oldValue, NewValue = newValue });
        }

    }
}
