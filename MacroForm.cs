using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FNFR2
{
   public partial class MacroForm : Form
   {
      public MacroSet dlgMacroSet;

      public MacroForm()
      {
         InitializeComponent();
      }

      public MacroForm(MacroSet DialogMacroSet)
         : this()
      {
         dlgMacroSet = DialogMacroSet;
         PairsTextBox.Text = dlgMacroSet.ToString(false);
      }

      private void OKButton_Click(object sender, EventArgs e)
      {
         dlgMacroSet = MacroSet.FromString(PairsTextBox.Text, "\r\n", ":");
         this.Close();
      }

      private void CancelButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
