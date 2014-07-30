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

      /// <summary>
      /// Assumes reader is on an appropriate MacroPair node. If not, creates empty pair.
      /// Leaves the reader at the EndElement for the MacroPair.
      /// </summary>
      /// <param name="xreader">XmlReader pointing at a MacroPair Element</param>
      public MacroPair(XmlReader reader)
      {
         string FindString = "";
         string ReplacementString = "";

         if (reader.NodeType != XmlNodeType.Element || reader.LocalName != XML_NODE_PAIR_LOCALNAME)
         {
            // do nothing -- reader was not set right
         }

         else
         {
            while (reader.Read() && reader.NodeType != XmlNodeType.EndElement && reader.LocalName != XML_NODE_PAIR_LOCALNAME)
            {
               if (reader.LocalName == XML_NODE_FIND_STRING_NAME)
               {
                  FindString = reader.ReadString();
               }
               if (reader.LocalName == XML_NODE_REPLACEMENT_STRING_NAME)
               {
                  ReplacementString = reader.ReadString();
               }
            }
         }
         StringPair = new KeyValuePair<string, string>(FindString, ReplacementString);
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
         return ToString(" replaced with ");
      }

      /// <summary>
      /// Prints out the pair separated by the separator.
      /// </summary>
      /// <param name="Separator">String to put between the pair. Default is " replaced with "</param>
      /// <returns>Find string (separator) Replacement string</separator></returns>
      public string ToString(string Separator)
      {
         return FindString + Separator + ReplaceString; 
      }

      public static bool IsAMacroPairNode(XmlReader xreader)
      {
         return xreader.LocalName == XML_NODE_PAIR_LOCALNAME;
      }
   }
}
