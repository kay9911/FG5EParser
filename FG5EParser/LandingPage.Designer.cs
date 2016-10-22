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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Set Paths");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Start Here", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Test");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Classes", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.rctDisplay = new System.Windows.Forms.RichTextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "_setPath";
            treeNode5.Text = "Set Paths";
            treeNode6.Name = "Node2";
            treeNode6.Text = "Start Here";
            treeNode7.Name = "Node3";
            treeNode7.Text = "Test";
            treeNode8.Name = "Node2";
            treeNode8.Text = "Classes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(240, 788);
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
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(258, 96);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(659, 704);
            this.pnlMain.TabIndex = 2;
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
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 812);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.rctDisplay);
            this.Controls.Add(this.treeView1);
            this.Name = "LandingPage";
            this.Text = "FG5EParser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox rctDisplay;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnParse;
    }
}

