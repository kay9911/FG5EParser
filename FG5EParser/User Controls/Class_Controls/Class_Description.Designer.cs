namespace FG5EParser.User_Controls.Class_Controls
{
    partial class Class_Description
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtbClassDescriptions = new System.Windows.Forms.RichTextBox();
            this.cmsFormattingText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makeHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeBoldPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.makeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFormattingText.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbClassDescriptions
            // 
            this.rtbClassDescriptions.ContextMenuStrip = this.cmsFormattingText;
            this.rtbClassDescriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbClassDescriptions.Location = new System.Drawing.Point(3, 48);
            this.rtbClassDescriptions.Name = "rtbClassDescriptions";
            this.rtbClassDescriptions.Size = new System.Drawing.Size(679, 646);
            this.rtbClassDescriptions.TabIndex = 0;
            this.rtbClassDescriptions.Text = "";
            this.rtbClassDescriptions.TextChanged += new System.EventHandler(this.rtbClassDescriptions_TextChanged);
            // 
            // cmsFormattingText
            // 
            this.cmsFormattingText.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFormattingText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeHeaderToolStripMenuItem,
            this.makeBoldPointToolStripMenuItem,
            this.makeTableToolStripMenuItem,
            this.makeListToolStripMenuItem});
            this.cmsFormattingText.Name = "cmsFormattingText";
            this.cmsFormattingText.Size = new System.Drawing.Size(193, 136);
            // 
            // makeHeaderToolStripMenuItem
            // 
            this.makeHeaderToolStripMenuItem.Name = "makeHeaderToolStripMenuItem";
            this.makeHeaderToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.makeHeaderToolStripMenuItem.Text = "Make Header";
            this.makeHeaderToolStripMenuItem.Click += new System.EventHandler(this.makeHeaderToolStripMenuItem_Click);
            // 
            // makeBoldPointToolStripMenuItem
            // 
            this.makeBoldPointToolStripMenuItem.Name = "makeBoldPointToolStripMenuItem";
            this.makeBoldPointToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.makeBoldPointToolStripMenuItem.Text = "Make Bold Point";
            this.makeBoldPointToolStripMenuItem.Click += new System.EventHandler(this.makeBoldPointToolStripMenuItem_Click);
            // 
            // makeTableToolStripMenuItem
            // 
            this.makeTableToolStripMenuItem.Name = "makeTableToolStripMenuItem";
            this.makeTableToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.makeTableToolStripMenuItem.Text = "Make Table";
            this.makeTableToolStripMenuItem.Click += new System.EventHandler(this.makeTableToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(152, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(380, 38);
            this.label4.TabIndex = 4;
            this.label4.Text = "CLASS DESCRIPTIONS";
            // 
            // makeListToolStripMenuItem
            // 
            this.makeListToolStripMenuItem.Name = "makeListToolStripMenuItem";
            this.makeListToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.makeListToolStripMenuItem.Text = "Make List";
            this.makeListToolStripMenuItem.Click += new System.EventHandler(this.makeListToolStripMenuItem_Click);
            // 
            // Class_Description
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbClassDescriptions);
            this.Name = "Class_Description";
            this.Size = new System.Drawing.Size(685, 699);
            this.cmsFormattingText.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbClassDescriptions;
        private System.Windows.Forms.ContextMenuStrip cmsFormattingText;
        private System.Windows.Forms.ToolStripMenuItem makeHeaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeBoldPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeTableToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem makeListToolStripMenuItem;
    }
}
