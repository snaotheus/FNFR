using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace FNFR2
{
    static class Program
    {

       static Form1 myform;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       [STAThread]

        static void Main()
        {
            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            myform = new Form1();
            Application.Run(myform);
        }

        static void OnApplicationExit(object sender, EventArgs e)
        {
           
           XmlWriter myxmlwriter = XmlWriter.Create(Application.StartupPath + "\\mp.xml");

           myxmlwriter.WriteStartDocument();
           myform.myset.ToXML(myxmlwriter);
           myxmlwriter.WriteEndDocument();
           myxmlwriter.Close();

        }
    }
}
