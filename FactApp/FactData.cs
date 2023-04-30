using System;
using System.Collections.Generic;
using System.Text;

namespace FactApp
{
    public class FactData
    {
        public FactData() { }
        public static IEnumerable<FactData> All { private set; get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
