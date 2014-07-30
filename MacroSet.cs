using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace FNFR2
{
   public class MacroSet
   {
      public static string XML_NODE_SET_LOCALNAME = "MacroSet";

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

      public bool AddPair(MacroPair NewPair)
      {
         if (DataStore.ContainsValue(NewPair))
         {
            return false;
         }

         DataStore.Add(DataStore.Count + 1, NewPair);
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

      /// <summary>
      /// Assumes reader is pointing at a MacroSet node. Returns with reader pointing at the MacroSet end node.
      /// </summary>
      /// <param name="reader"></param>
      /// <returns>MacroSet containing all the MacroPairs from the XML node.</returns>
      public static MacroSet FromXML(XmlReader reader)
      {
         MacroSet newset = new MacroSet();
         if (reader.NodeType != XmlNodeType.Element || reader.LocalName != XML_NODE_SET_LOCALNAME)
            return newset;

         while (reader.Read() && reader.NodeType != XmlNodeType.EndElement && reader.LocalName != XML_NODE_SET_LOCALNAME)
         {
            if (reader.NodeType == XmlNodeType.Element && reader.LocalName == MacroPair.XML_NODE_PAIR_LOCALNAME)
               newset.AddPair(new MacroPair(reader));
         }

         return newset;
      }

      public void ToXML(XmlWriter xw)
      {
         xw.WriteStartElement(XML_NODE_SET_LOCALNAME);

         foreach(KeyValuePair<int,MacroPair> kvp in DataStore)
         {
            kvp.Value.ToXML(xw);
         }
         xw.WriteEndElement();

      }

      public override string ToString()
      {
         return ToString(true);
      }

      public string ToString(bool pretty)
      {
         string retstring = "";
         if (pretty)
         {
            retstring = "Macroset contains: ";
            int i = 0;

            foreach (KeyValuePair<int, MacroPair> kvp in DataStore)
            {
               i++;
               retstring += "\r\n   " + i + ". " + kvp.Value.ToString();
            }

         }
         else
         {
            retstring = "";
            foreach (KeyValuePair<int, MacroPair> kvp in DataStore)
            {
               retstring += kvp.Value.ToString(":") + "\r\n";
            }
         }
            return retstring;
      }
   }
}
