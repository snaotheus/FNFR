using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace FNFR2
{
    class MyStringCollection : StringCollection
    {
        public MyStringCollection() { }
        public string ToString()
        {
            StringBuilder AllToString = new StringBuilder();
            foreach (string ThisString in this)
            {
                AllToString.AppendLine(ThisString);
            }
            
            return AllToString.ToString();
        }

    }
}
