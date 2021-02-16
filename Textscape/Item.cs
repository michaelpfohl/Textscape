using System;
using System.Collections.Generic;
using System.Text;

namespace Textscape
{
    class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

        public Item(string name)
        {
            Name = name;
        }
    }
}
