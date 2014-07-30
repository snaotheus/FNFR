using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace FNFR2
{
    public partial class Form1 : Form
    {
        public MacroSet myset;
        private FileSearchThing MySearch = new FileSearchThing();
        private double OpTime = 0; // I could have been fancy and put this sort of information in the FileSearchThing.

        public Form1()
        {
            InitializeComponent();

           XmlReader reader = XmlReader.Create(Application.StartupPath + "\\mp.xml");
           while(reader.Read() && (reader.NodeType != XmlNodeType.Element || reader.LocalName != MacroSet.XML_NODE_SET_LOCALNAME))
           {
              //reader.Read();
           }
           myset = MacroSet.FromXML(reader);
           reader.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Only shows you what the search finds.
        private void PreviewButton_Click(object sender, EventArgs e)
        {
            if (UpdateSearchParameters())
            {
                double starttime = Environment.TickCount;
                MySearch.Search();
                OpTime = Environment.TickCount - starttime;
                UpdateUI(ActionType.Search);
            }
        }
        
        // Doesn't change any file names. Just shows you what WOULD happen.
        // It lets you see into the FUTURE.
        private void PreviewReplaceButton_Click(object sender, EventArgs e)
        {
            if (UpdateSearchParameters())
            {
                int starttime = Environment.TickCount;
                MySearch.PreviewReplace();
                OpTime = Environment.TickCount - starttime;
                UpdateUI(ActionType.PreviewReplace);
            }
        }

        // Actually changes file names.
        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            if (UpdateSearchParameters())
            {
                int starttime = Environment.TickCount;
                MySearch.Replace();
                OpTime = Environment.TickCount - starttime;
                UpdateUI(ActionType.Replace);
            }
        }

        // Makes the UI field background colors normal again.
        private void ClearBackgroundColors()
        {
            BaseDirectoryString.BackColor  = SystemColors.Window;
            FilterString.BackColor         = SystemColors.Window;
            ContainsAllString.BackColor    = SystemColors.Window;
            DoesNotContainString.BackColor = SystemColors.Window;
            ReplaceThisString.BackColor    = SystemColors.Window;
            ReplacementString.BackColor    = SystemColors.Window;
            BaseDirectoryString.BackColor  = SystemColors.Window;
        }

        // Takes UI entries and enters them into a new SearchParameters object.
        // If the new SearchParameters is different from the old one, it replaces
        // the old Search. That way we don't redo a search unless we changed the
        // search.
        private bool UpdateSearchParameters()
        {
            SearchParameters NewSearchParameters = new SearchParameters(BaseDirectoryString.Text, FilterString.Text, ContainsAllString.Text, DoesNotContainString.Text, SeparatorString.Text, ReplaceThisString.Text, ReplacementString.Text, Recursiveness.Checked, CaseSensitive.Checked);
            return UpdateSearchParameters(NewSearchParameters);
        }

        private bool UpdateSearchParameters(MacroPair myPair)
        {
           SearchParameters NewSearchParameters = new SearchParameters(BaseDirectoryString.Text, FilterString.Text, ContainsAllString.Text, DoesNotContainString.Text, SeparatorString.Text, myPair.FindString, myPair.ReplaceString, Recursiveness.Checked, CaseSensitive.Checked);
           return UpdateSearchParameters(NewSearchParameters);
        }

        private bool UpdateSearchParameters(SearchParameters sp)
        {
           InputErrors MyErrors = sp.AreValid();

           ClearBackgroundColors();

           if (MyErrors == InputErrors.NoProblems)
           {
              if (!MySearch.UsesTheseParameters(sp))
              {
                 MySearch = new FileSearchThing(sp);
              }
              return true;
           }
           else
           {
              HandleUIErrors(MyErrors);
              return false;
           }
        }

        private void HandleUIErrors(InputErrors MyErrors)
        {
            string ErrorMessage = "You've given me the following problems:\n\n";
            int ErrorCount = 1;
            if ((int)(MyErrors & InputErrors.InvalidBaseDirectory) > 0)
            {
                ErrorMessage += ErrorCount + ". Bad base directory.\n";
                BaseDirectoryString.BackColor = Color.Red;
                ErrorCount++;
            }

            if ((int)(MyErrors & InputErrors.InvalidFilterCharacters) > 0)
            {
                ErrorMessage += ErrorCount + ". Filter contains invalid characters.\n";
                FilterString.BackColor = Color.Red;
                ErrorCount++;
            }

            if ((int)(MyErrors & InputErrors.InvalidCharactersInReplacement) > 0)
            {
                ErrorMessage += ErrorCount + ". The replacement string contains characters that aren't allowed in filenames.\n";
                ReplacementString.BackColor = Color.Red;
                ErrorCount++;
            }

            if ((int)(MyErrors & InputErrors.ConflictingFindThisWithContainsNone) > 0)
            {
                ErrorMessage += ErrorCount + ". \"Does Not Contain Any\" and \"Replace\" conflict.\n";
                ReplaceThisString.BackColor = Color.Red;
                DoesNotContainString.BackColor = Color.Red;
                ErrorCount++;
            }

            if ((int)(MyErrors & InputErrors.ConflictingContainsAllWithContainsNone) > 0)
            {
                ErrorMessage += ErrorCount + ". \"Does Not Contain Any\" and \"Contains All\" conflict.\n";
                DoesNotContainString.BackColor = Color.Red;
                ContainsAllString.BackColor = Color.Red;
                ErrorCount++;
            }

            MessageBox.Show(ErrorMessage.Substring(0, ErrorMessage.Length - 2)); // subtraction to remove the extra \n.
        }

        // Updates the UI based on the action that calls for the UI update
        private void UpdateUI(ActionType ThisAction)
        {
            int starttime = Environment.TickCount;
            treeView1.Nodes.Clear();
            DisallowedTextBox.Text = MySearch.Results.BannedDirectories.ToString();
            tabControl1.TabPages["BannedDirectories"].Text = "Disallowed Directories (" + MySearch.Results.BannedDirectories.Count + ")";
            switch (ThisAction)
            {
                case ActionType.Search:
                    ResultsTextBox.Text = MySearch.Results.FileNames.ToString();
                    treeView1.Nodes.Add(MySearch.Results.FileNamesToTree());
                    toolStripStatusLabel1.Text = MySearch.Results.FileNames.Count + " hits found in " + OpTime/1000 + " seconds.";
                    break;
                case ActionType.PreviewReplace:
                    ResultsTextBox.Text = MySearch.Results.RenamedFiles.ToString();
                    treeView1.Nodes.Add(MySearch.Results.ReplacementsToTree());
                    toolStripStatusLabel1.Text = MySearch.Results.RenamedFiles.Count + " hits found in " + OpTime/1000 + " seconds.";
                    break;
                case ActionType.Replace:
                    ResultsTextBox.Text = MySearch.Results.RenamedFiles.ToString();
                    treeView1.Nodes.Add(MySearch.Results.ReplacementsToTree());
                    toolStripStatusLabel1.Text = MySearch.Results.RenamedFiles.Count + " Files renamed in " + OpTime / 1000 + " seconds.";
                    break;
               case ActionType.Macro:
                    ResultsTextBox.Text = "Macro run";
                    toolStripStatusLabel1.Text = "Macro completed in " + OpTime / 1000 + " seconds.";
                    break;
            }
            toolStripStatusLabel1.Text += " GUI updated in " + (double)(Environment.TickCount - starttime) / 1000 + " seconds.";
        }

        // Expands the tree
        private void ExpandAllButton_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        // Collapses the tree
        private void CollapseAllButton_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        public enum ActionType { Search, PreviewReplace, Replace, Macro }

        private void MacroButton_Click(object sender, EventArgs e)
        {
           MacroSet m = GetMacroSet();

           int starttime = Environment.TickCount;
           for (int i = 1; i <= m.count; i++)
           {
              if (UpdateSearchParameters(m.GetPair(i)))
              {
                 MySearch.Replace();
              }
           }
           OpTime = Environment.TickCount - starttime;
           UpdateUI(ActionType.Macro);
        }

        private MacroSet GetMacroSet()
        {
           return myset;
        }

        private void EditMacroButton_Click(object sender, EventArgs e)
        {
           MessageBox.Show(myset.ToString());
        }




    }


}
