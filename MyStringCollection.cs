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
            string AllToString = "";
            foreach (string ThisString in this)
            {
                AllToString += ThisString + "\n";
            }
            if (AllToString.Length > 0) AllToString = AllToString.Remove(AllToString.Length - 1);
            return AllToString;
        }

    }
}
