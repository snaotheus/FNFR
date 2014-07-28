using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FNFR2
{
   public class MacroPair
   {
      public static string XML_NODE_PAIR_LOCALNAME = "MacroPair";
      public static string XML_NODE_FIND_STRING_NAME = "FindString";
      public static string XML_NODE_REPLACEMENT_STRING_NAME = "ReplacementString";

      private KeyValuePair<string, string> StringPair;
      public string FindString { get { return StringPair.Key; } }
      public string ReplaceString { get { return StringPair.Value; } }

      public MacroPair()
      {
         StringPair = new KeyValuePair<string, string>("", "");
      }

      public MacroPair(string FindString, string ReplaceWithString)
      {
         StringPair = new KeyValuePair<string, string>(FindString, ReplaceWithString);
      }

      public MacroPair(XmlReader xreader)
      {
         string ReplaceThisString = "";
         string WithThisString = "";
         xreader.MoveToElement(); // Advance to first child
         xreader.Read(); // read the first child
         string ThisProperty = xreader.LocalName;
         xreader.Read();
         string ThisValue = xreader.Value;
         if (ThisProperty == XML_NODE_FIND_STRING_NAME)
         {
            ReplaceThisString = ThisValue;
         }
         else
         {
            WithThisString = ThisValue;
         }
         
         xreader.MoveToElement();
         xreader.Read();
         xreader.Read();
         ThisProperty = xreader.LocalName;
         xreader.Read();
         ThisValue = xreader.Value;
         if (ThisProperty == XML_NODE_FIND_STRING_NAME)
         {
            ReplaceThisString = ThisValue;
         }
         else
         {
            WithThisString = ThisValue;
         }

         StringPair = new KeyValuePair<string, string>(ReplaceThisString, WithThisString);
      }

      public void ToXML(XmlWriter xwriter)
      {
         xwriter.WriteStartElement(XML_NODE_PAIR_LOCALNAME);
         xwriter.WriteElementString(XML_NODE_FIND_STRING_NAME, FindString);
         xwriter.WriteElementString(XML_NODE_REPLACEMENT_STRING_NAME, ReplaceString);
         xwriter.WriteEndElement();
      }

      public override string ToString()
      {
         return "Replace " + FindString + " with " + ReplaceString;
      }

      public static bool IsAMacroPairNode(XmlReader xreader)
      {
         return xreader.LocalName == XML_NODE_PAIR_LOCALNAME;
      }
   }
}
