﻿namespace FNFR2
{
    partial class Form1
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
         this.BaseDirectoryString = new System.Windows.Forms.TextBox();
         this.BaseDirectoryLabel = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.FilterString = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.SeparatorString = new System.Windows.Forms.TextBox();
         this.label = new System.Windows.Forms.Label();
         this.ContainsAllString = new System.Windows.Forms.TextBox();
         this.Recursiveness = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.DoesNotContainString = new System.Windows.Forms.TextBox();
         this.CaseSensitive = new System.Windows.Forms.CheckBox();
         this.ResultsTextBox = new System.Windows.Forms.RichTextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.ReplaceThisString = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.ReplacementString = new System.Windows.Forms.TextBox();
         this.PreviewSearchButton = new System.Windows.Forms.Button();
         this.ReplaceButton = new System.Windows.Forms.Button();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.TextResults = new System.Windows.Forms.TabPage();
         this.BannedDirectories = new System.Windows.Forms.TabPage();
         this.DisallowedTextBox = new System.Windows.Forms.RichTextBox();
         this.TreeResults = new System.Windows.Forms.TabPage();
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.CollapseAllButton = new System.Windows.Forms.Button();
         this.ExpandAllButton = new System.Windows.Forms.Button();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.PreviewReplaceButton = new System.Windows.Forms.Button();
         this.MacroButton = new System.Windows.Forms.Button();
         this.EditMacroButton = new System.Windows.Forms.Button();
         this.tabControl1.SuspendLayout();
         this.TextResults.SuspendLayout();
         this.BannedDirectories.SuspendLayout();
         this.TreeResults.SuspendLayout();
         this.statusStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // BaseDirectoryString
         // 
         this.BaseDirectoryString.Location = new System.Drawing.Point(12, 30);
         this.BaseDirectoryString.Name = "BaseDirectoryString";
         this.BaseDirectoryString.Size = new System.Drawing.Size(310, 20);
         this.BaseDirectoryString.TabIndex = 0;
         this.BaseDirectoryString.Text = "C:\\";
         // 
         // BaseDirectoryLabel
         // 
         this.BaseDirectoryLabel.AutoSize = true;
         this.BaseDirectoryLabel.Location = new System.Drawing.Point(13, 13);
         this.BaseDirectoryLabel.Name = "BaseDirectoryLabel";
         this.BaseDirectoryLabel.Size = new System.Drawing.Size(60, 13);
         this.BaseDirectoryLabel.TabIndex = 1;
         this.BaseDirectoryLabel.Text = "Look Here:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 61);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(47, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Filter By:";
         // 
         // FilterString
         // 
         this.FilterString.Location = new System.Drawing.Point(12, 78);
         this.FilterString.Name = "FilterString";
         this.FilterString.Size = new System.Drawing.Size(251, 20);
         this.FilterString.TabIndex = 2;
         this.FilterString.Text = "*";
         this.FilterString.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(266, 61);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(56, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "Separator:";
         // 
         // SeparatorString
         // 
         this.SeparatorString.Location = new System.Drawing.Point(269, 78);
         this.SeparatorString.MaxLength = 1;
         this.SeparatorString.Name = "SeparatorString";
         this.SeparatorString.Size = new System.Drawing.Size(53, 20);
         this.SeparatorString.TabIndex = 3;
         this.SeparatorString.Text = "|";
         // 
         // label
         // 
         this.label.AutoSize = true;
         this.label.Location = new System.Drawing.Point(13, 110);
         this.label.Name = "label";
         this.label.Size = new System.Drawing.Size(65, 13);
         this.label.TabIndex = 7;
         this.label.Text = "Contains All:";
         // 
         // ContainsAllString
         // 
         this.ContainsAllString.Location = new System.Drawing.Point(12, 127);
         this.ContainsAllString.Name = "ContainsAllString";
         this.ContainsAllString.Size = new System.Drawing.Size(310, 20);
         this.ContainsAllString.TabIndex = 4;
         // 
         // Recursiveness
         // 
         this.Recursiveness.AutoSize = true;
         this.Recursiveness.Checked = true;
         this.Recursiveness.CheckState = System.Windows.Forms.CheckState.Checked;
         this.Recursiveness.Location = new System.Drawing.Point(349, 32);
         this.Recursiveness.Name = "Recursiveness";
         this.Recursiveness.Size = new System.Drawing.Size(74, 17);
         this.Recursiveness.TabIndex = 1;
         this.Recursiveness.Text = "Recursive";
         this.Recursiveness.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 163);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(115, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "Does Not Contain Any:";
         // 
         // DoesNotContainString
         // 
         this.DoesNotContainString.Location = new System.Drawing.Point(12, 180);
         this.DoesNotContainString.Name = "DoesNotContainString";
         this.DoesNotContainString.Size = new System.Drawing.Size(310, 20);
         this.DoesNotContainString.TabIndex = 6;
         // 
         // CaseSensitive
         // 
         this.CaseSensitive.AutoSize = true;
         this.CaseSensitive.Location = new System.Drawing.Point(349, 129);
         this.CaseSensitive.Name = "CaseSensitive";
         this.CaseSensitive.Size = new System.Drawing.Size(96, 17);
         this.CaseSensitive.TabIndex = 5;
         this.CaseSensitive.Text = "Case Sensitive";
         this.CaseSensitive.UseVisualStyleBackColor = true;
         // 
         // ResultsTextBox
         // 
         this.ResultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.ResultsTextBox.Location = new System.Drawing.Point(6, 6);
         this.ResultsTextBox.Name = "ResultsTextBox";
         this.ResultsTextBox.Size = new System.Drawing.Size(509, 303);
         this.ResultsTextBox.TabIndex = 13;
         this.ResultsTextBox.Text = "";
         this.ResultsTextBox.WordWrap = false;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(13, 215);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(50, 13);
         this.label4.TabIndex = 14;
         this.label4.Text = "Replace:";
         // 
         // ReplaceThisString
         // 
         this.ReplaceThisString.Location = new System.Drawing.Point(12, 232);
         this.ReplaceThisString.Name = "ReplaceThisString";
         this.ReplaceThisString.Size = new System.Drawing.Size(144, 20);
         this.ReplaceThisString.TabIndex = 7;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(179, 215);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(32, 13);
         this.label5.TabIndex = 16;
         this.label5.Text = "With:";
         // 
         // ReplacementString
         // 
         this.ReplacementString.Location = new System.Drawing.Point(178, 232);
         this.ReplacementString.Name = "ReplacementString";
         this.ReplacementString.Size = new System.Drawing.Size(144, 20);
         this.ReplacementString.TabIndex = 8;
         // 
         // PreviewSearchButton
         // 
         this.PreviewSearchButton.Location = new System.Drawing.Point(327, 205);
         this.PreviewSearchButton.Name = "PreviewSearchButton";
         this.PreviewSearchButton.Size = new System.Drawing.Size(96, 23);
         this.PreviewSearchButton.TabIndex = 9;
         this.PreviewSearchButton.Text = "Preview Search";
         this.PreviewSearchButton.UseVisualStyleBackColor = true;
         this.PreviewSearchButton.Click += new System.EventHandler(this.PreviewButton_Click);
         // 
         // ReplaceButton
         // 
         this.ReplaceButton.Location = new System.Drawing.Point(429, 234);
         this.ReplaceButton.Name = "ReplaceButton";
         this.ReplaceButton.Size = new System.Drawing.Size(111, 23);
         this.ReplaceButton.TabIndex = 11;
         this.ReplaceButton.Text = "Replace";
         this.ReplaceButton.UseVisualStyleBackColor = true;
         this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
         // 
         // tabControl1
         // 
         this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControl1.Controls.Add(this.TextResults);
         this.tabControl1.Controls.Add(this.BannedDirectories);
         this.tabControl1.Controls.Add(this.TreeResults);
         this.tabControl1.Location = new System.Drawing.Point(12, 258);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(529, 341);
         this.tabControl1.TabIndex = 12;
         // 
         // TextResults
         // 
         this.TextResults.Controls.Add(this.ResultsTextBox);
         this.TextResults.Location = new System.Drawing.Point(4, 22);
         this.TextResults.Name = "TextResults";
         this.TextResults.Padding = new System.Windows.Forms.Padding(3);
         this.TextResults.Size = new System.Drawing.Size(521, 315);
         this.TextResults.TabIndex = 0;
         this.TextResults.Text = "Results (text)";
         this.TextResults.UseVisualStyleBackColor = true;
         // 
         // BannedDirectories
         // 
         this.BannedDirectories.Controls.Add(this.DisallowedTextBox);
         this.BannedDirectories.Location = new System.Drawing.Point(4, 22);
         this.BannedDirectories.Name = "BannedDirectories";
         this.BannedDirectories.Padding = new System.Windows.Forms.Padding(3);
         this.BannedDirectories.Size = new System.Drawing.Size(521, 315);
         this.BannedDirectories.TabIndex = 1;
         this.BannedDirectories.Text = "Disallowed Directories";
         this.BannedDirectories.UseVisualStyleBackColor = true;
         // 
         // DisallowedTextBox
         // 
         this.DisallowedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.DisallowedTextBox.Location = new System.Drawing.Point(6, 6);
         this.DisallowedTextBox.Name = "DisallowedTextBox";
         this.DisallowedTextBox.Size = new System.Drawing.Size(509, 304);
         this.DisallowedTextBox.TabIndex = 13;
         this.DisallowedTextBox.Text = "";
         this.DisallowedTextBox.WordWrap = false;
         // 
         // TreeResults
         // 
         this.TreeResults.Controls.Add(this.treeView1);
         this.TreeResults.Controls.Add(this.CollapseAllButton);
         this.TreeResults.Controls.Add(this.ExpandAllButton);
         this.TreeResults.Location = new System.Drawing.Point(4, 22);
         this.TreeResults.Name = "TreeResults";
         this.TreeResults.Size = new System.Drawing.Size(521, 315);
         this.TreeResults.TabIndex = 2;
         this.TreeResults.Text = "Results (tree)";
         this.TreeResults.UseVisualStyleBackColor = true;
         // 
         // treeView1
         // 
         this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.treeView1.Location = new System.Drawing.Point(4, 34);
         this.treeView1.Name = "treeView1";
         this.treeView1.Size = new System.Drawing.Size(514, 278);
         this.treeView1.TabIndex = 15;
         // 
         // CollapseAllButton
         // 
         this.CollapseAllButton.Location = new System.Drawing.Point(86, 4);
         this.CollapseAllButton.Name = "CollapseAllButton";
         this.CollapseAllButton.Size = new System.Drawing.Size(75, 23);
         this.CollapseAllButton.TabIndex = 14;
         this.CollapseAllButton.Text = "Collapse All";
         this.CollapseAllButton.UseVisualStyleBackColor = true;
         this.CollapseAllButton.Click += new System.EventHandler(this.CollapseAllButton_Click);
         // 
         // ExpandAllButton
         // 
         this.ExpandAllButton.Location = new System.Drawing.Point(4, 4);
         this.ExpandAllButton.Name = "ExpandAllButton";
         this.ExpandAllButton.Size = new System.Drawing.Size(75, 23);
         this.ExpandAllButton.TabIndex = 13;
         this.ExpandAllButton.Text = "Expand All";
         this.ExpandAllButton.UseVisualStyleBackColor = true;
         this.ExpandAllButton.Click += new System.EventHandler(this.ExpandAllButton_Click);
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
         this.statusStrip1.Location = new System.Drawing.Point(0, 607);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(549, 22);
         this.statusStrip1.TabIndex = 20;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(228, 17);
         this.toolStripStatusLabel1.Text = "Welcome! You haven\'t done anything yet.";
         // 
         // PreviewReplaceButton
         // 
         this.PreviewReplaceButton.Location = new System.Drawing.Point(429, 205);
         this.PreviewReplaceButton.Name = "PreviewReplaceButton";
         this.PreviewReplaceButton.Size = new System.Drawing.Size(111, 23);
         this.PreviewReplaceButton.TabIndex = 10;
         this.PreviewReplaceButton.Text = "Preview Replace";
         this.PreviewReplaceButton.UseVisualStyleBackColor = true;
         this.PreviewReplaceButton.Click += new System.EventHandler(this.PreviewReplaceButton_Click);
         // 
         // MacroButton
         // 
         this.MacroButton.Location = new System.Drawing.Point(429, 176);
         this.MacroButton.Name = "MacroButton";
         this.MacroButton.Size = new System.Drawing.Size(111, 23);
         this.MacroButton.TabIndex = 21;
         this.MacroButton.Text = "Macro";
         this.MacroButton.UseVisualStyleBackColor = true;
         this.MacroButton.Click += new System.EventHandler(this.MacroButton_Click);
         // 
         // EditMacroButton
         // 
         this.EditMacroButton.Location = new System.Drawing.Point(466, 147);
         this.EditMacroButton.Name = "EditMacroButton";
         this.EditMacroButton.Size = new System.Drawing.Size(75, 23);
         this.EditMacroButton.TabIndex = 22;
         this.EditMacroButton.Text = "See Macro";
         this.EditMacroButton.UseVisualStyleBackColor = true;
         this.EditMacroButton.Click += new System.EventHandler(this.EditMacroButton_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(549, 629);
         this.Controls.Add(this.EditMacroButton);
         this.Controls.Add(this.MacroButton);
         this.Controls.Add(this.PreviewReplaceButton);
         this.Controls.Add(this.statusStrip1);
         this.Controls.Add(this.tabControl1);
         this.Controls.Add(this.ReplaceButton);
         this.Controls.Add(this.PreviewSearchButton);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.ReplacementString);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.ReplaceThisString);
         this.Controls.Add(this.CaseSensitive);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.DoesNotContainString);
         this.Controls.Add(this.Recursiveness);
         this.Controls.Add(this.label);
         this.Controls.Add(this.ContainsAllString);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.SeparatorString);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.FilterString);
         this.Controls.Add(this.BaseDirectoryLabel);
         this.Controls.Add(this.BaseDirectoryString);
         this.Name = "Form1";
         this.Text = "File Name Find & Replace 2";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.tabControl1.ResumeLayout(false);
         this.TextResults.ResumeLayout(false);
         this.BannedDirectories.ResumeLayout(false);
         this.TreeResults.ResumeLayout(false);
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BaseDirectoryString;
        private System.Windows.Forms.Label BaseDirectoryLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FilterString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SeparatorString;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox ContainsAllString;
        private System.Windows.Forms.CheckBox Recursiveness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DoesNotContainString;
        private System.Windows.Forms.CheckBox CaseSensitive;
        private System.Windows.Forms.RichTextBox ResultsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ReplaceThisString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ReplacementString;
        private System.Windows.Forms.Button PreviewSearchButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TextResults;
        private System.Windows.Forms.TabPage BannedDirectories;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.RichTextBox DisallowedTextBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage TreeResults;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button CollapseAllButton;
        private System.Windows.Forms.Button ExpandAllButton;
        private System.Windows.Forms.Button PreviewReplaceButton;
        private System.Windows.Forms.Button MacroButton;
        private System.Windows.Forms.Button EditMacroButton;
    }
}

