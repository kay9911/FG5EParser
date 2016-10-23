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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Set Paths");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Start Here", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("NPC");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.rctDisplay = new System.Windows.Forms.RichTextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "_setPath";
            treeNode1.Text = "Set Paths";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Start Here";
            treeNode3.Name = "_NPC";
            treeNode3.Text = "NPC";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.treeView1.Size = new System.Drawing.Size(173, 788);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // rctDisplay
            // 
            this.rctDisplay.Location = new System.Drawing.Point(923, 12);
            this.rctDisplay.Name = "rctDisplay";
            this.rctDisplay.Size = new System.Drawing.Size(494, 788);
            this.rctDisplay.TabIndex = 1;
            this.rctDisplay.Text = "";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(776, 12);
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
            this.pnlMain.Size = new System.Drawing.Size(726, 716);
            this.pnlMain.TabIndex = 4;
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 812);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.rctDisplay);
            this.Controls.Add(this.treeView1);
            this.Name = "LandingPage";
            this.Text = "FG5EParser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox rctDisplay;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.FlowLayoutPanel pnlMain;
    }
}

