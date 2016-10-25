namespace FG5EParser.User_Controls.NPC_Controls
{
    partial class NPC_Buttons
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
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnRefreshAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(3, 3);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(119, 31);
            this.btnAddToList.TabIndex = 0;
            this.btnAddToList.Text = "Add To List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnRefreshAll
            // 
            this.btnRefreshAll.Location = new System.Drawing.Point(128, 3);
            this.btnRefreshAll.Name = "btnRefreshAll";
            this.btnRefreshAll.Size = new System.Drawing.Size(119, 31);
            this.btnRefreshAll.TabIndex = 1;
            this.btnRefreshAll.Text = "Refresh All";
            this.btnRefreshAll.UseVisualStyleBackColor = true;
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            // 
            // NPC_Buttons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefreshAll);
            this.Controls.Add(this.btnAddToList);
            this.Name = "NPC_Buttons";
            this.Size = new System.Drawing.Size(252, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnRefreshAll;
    }
}
