namespace FG5EParser
{
    partial class LandingPage
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
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Set Paths");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Start Here", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("HP&Proffs");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Descriptions");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Class", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Stats");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Actions");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Innate Spells");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Spellcasting");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("NPC", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.rtcDisplay = new System.Windows.Forms.RichTextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMainButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode11.Name = "_setPath";
            treeNode11.Text = "Set Paths";
            treeNode12.Name = "_startHere";
            treeNode12.Text = "Start Here";
            treeNode13.Name = "_hpproff";
            treeNode13.Text = "HP&Proffs";
            treeNode14.Name = "_classDescriptions";
            treeNode14.Text = "Descriptions";
            treeNode15.Name = "_Class";
            treeNode15.Text = "Class";
            treeNode16.Name = "_stats";
            treeNode16.Tag = "NPC_BLOCKS";
            treeNode16.Text = "Stats";
            treeNode17.Name = "_actions";
            treeNode17.Tag = "NPC_BLOCKS";
            treeNode17.Text = "Actions";
            treeNode18.Name = "_innate_spellcasting";
            treeNode18.Tag = "NPC_BLOCKS";
            treeNode18.Text = "Innate Spells";
            treeNode19.Name = "_spellcasting";
            treeNode19.Tag = "NPC_BLOCKS";
            treeNode19.Text = "Spellcasting";
            treeNode20.Name = "_NPC";
            treeNode20.Tag = "NPC_BLOCKS";
            treeNode20.Text = "NPC";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode15,
            treeNode20});
            this.treeView1.Size = new System.Drawing.Size(173, 788);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // rtcDisplay
            // 
            this.rtcDisplay.Location = new System.Drawing.Point(912, 12);
            this.rtcDisplay.Name = "rtcDisplay";
            this.rtcDisplay.Size = new System.Drawing.Size(505, 788);
            this.rtcDisplay.TabIndex = 1;
            this.rtcDisplay.Text = "";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(767, 12);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(141, 23);
            this.btnParse.TabIndex = 3;
            this.btnParse.Text = "PARSE";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Location = new System.Drawing.Point(191, 84);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(717, 716);
            this.pnlMain.TabIndex = 4;
            // 
            // pnlMainButtons
            // 
            this.pnlMainButtons.Location = new System.Drawing.Point(191, 41);
            this.pnlMainButtons.Name = "pnlMainButtons";
            this.pnlMainButtons.Size = new System.Drawing.Size(717, 37);
            this.pnlMainButtons.TabIndex = 5;
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1429, 812);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.pnlMainButtons);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.rtcDisplay);
            this.Controls.Add(this.treeView1);
            this.Name = "LandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FG5EParser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox rtcDisplay;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.FlowLayoutPanel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel pnlMainButtons;
    }
}

