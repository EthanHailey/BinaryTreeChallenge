namespace BTreeChallenge
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
            this.PnlDrawTree = new System.Windows.Forms.Panel();
            this.PnlButtons = new System.Windows.Forms.Panel();
            this.btnRandomNodes = new System.Windows.Forms.Button();
            this.PnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlDrawTree
            // 
            this.PnlDrawTree.BackColor = System.Drawing.Color.White;
            this.PnlDrawTree.Location = new System.Drawing.Point(0, 0);
            this.PnlDrawTree.Name = "PnlDrawTree";
            this.PnlDrawTree.Size = new System.Drawing.Size(522, 359);
            this.PnlDrawTree.TabIndex = 0;
            this.PnlDrawTree.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlDrawTree_Paint);
            // 
            // PnlButtons
            // 
            this.PnlButtons.Controls.Add(this.btnRandomNodes);
            this.PnlButtons.Location = new System.Drawing.Point(0, 365);
            this.PnlButtons.Name = "PnlButtons";
            this.PnlButtons.Size = new System.Drawing.Size(522, 37);
            this.PnlButtons.TabIndex = 1;
            // 
            // btnRandomNodes
            // 
            this.btnRandomNodes.Location = new System.Drawing.Point(12, 3);
            this.btnRandomNodes.Name = "btnRandomNodes";
            this.btnRandomNodes.Size = new System.Drawing.Size(498, 31);
            this.btnRandomNodes.TabIndex = 0;
            this.btnRandomNodes.Text = "Find Random Parent";
            this.btnRandomNodes.UseVisualStyleBackColor = true;
            this.btnRandomNodes.Click += new System.EventHandler(this.btnRandomNodes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 402);
            this.Controls.Add(this.PnlButtons);
            this.Controls.Add(this.PnlDrawTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BTree Challenge Visualization";
            this.PnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlDrawTree;
        private System.Windows.Forms.Panel PnlButtons;
        private System.Windows.Forms.Button btnRandomNodes;
    }
}

