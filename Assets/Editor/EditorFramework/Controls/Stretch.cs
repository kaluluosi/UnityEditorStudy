﻿using EditorFramework.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorFramework.Controls
{
    public class Stretch:Control
    {
        public Stretch(Direction direction)
        {
            if (direction == Direction.Horiziontal)
            {
                AdaptWidth = AdaptMode.Expand;
            }
            else if(direction==Direction.Vertical)
            {
                AdaptHeight = AdaptMode.Expand;
            }
        }
    }
}
