using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FNFR2
{
   public class MacroSet
   {
      private Dictionary<int, MacroPair> DataStore;
      public int count { get { return DataStore.Count; } }

      public MacroSet()
      {
         DataStore = new Dictionary<int, MacroPair>();
      }

      public bool AddPair(string FindString, string ReplaceString)
      {
         MacroPair PotentialPair = new MacroPair(FindString, ReplaceString);

         if (DataStore.ContainsValue(PotentialPair))
         {
            return false;
         }

         DataStore.Add(DataStore.Count + 1, PotentialPair);
         return true;
      }

      public MacroPair GetPair(int i)
      {
         if (i > DataStore.Count || i <= 0)
         {
            return new MacroPair();
         }

         return DataStore[i];
      }
   }
}
