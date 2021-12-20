﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountStore.UI.Pages
{
    public class Option
    {
        public string Name { get; private set; }
        public Action Callback { get; private set; }

        public Option(string name, Action callback)
        {
            Name = name;
            Callback = callback;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
