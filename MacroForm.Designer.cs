﻿namespace FNFR2
{
   partial class MacroForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.OKButton = new System.Windows.Forms.Button();
         this.CancelButton = new System.Windows.Forms.Button();
         this.PairsTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // OKButton
         // 
         this.OKButton.Location = new System.Drawing.Point(227, 422);
         this.OKButton.Name = "OKButton";
         this.OKButton.Size = new System.Drawing.Size(75, 23);
         this.OKButton.TabIndex = 1;
         this.OKButton.Text = "OK";
         this.OKButton.UseVisualStyleBackColor = true;
         this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
         // 
         // CancelButton
         // 
         this.CancelButton.Location = new System.Drawing.Point(308, 422);
         this.CancelButton.Name = "CancelButton";
         this.CancelButton.Size = new System.Drawing.Size(75, 23);
         this.CancelButton.TabIndex = 2;
         this.CancelButton.Text = "Cancel";
         this.CancelButton.UseVisualStyleBackColor = true;
         this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
         // 
         // PairsTextBox
         // 
         this.PairsTextBox.AcceptsReturn = true;
         this.PairsTextBox.Location = new System.Drawing.Point(12, 12);
         this.PairsTextBox.Multiline = true;
         this.PairsTextBox.Name = "PairsTextBox";
         this.PairsTextBox.Size = new System.Drawing.Size(371, 404);
         this.PairsTextBox.TabIndex = 3;
         // 
         // MacroForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(395, 457);
         this.Controls.Add(this.PairsTextBox);
         this.Controls.Add(this.CancelButton);
         this.Controls.Add(this.OKButton);
         this.Name = "MacroForm";
         this.Text = "MacroForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button OKButton;
      private System.Windows.Forms.Button CancelButton;
      private System.Windows.Forms.TextBox PairsTextBox;

   }
}