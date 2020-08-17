namespace GNX
{
    partial class TextBoxBlue
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
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.pnlBgWhite.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBgWhite
            // 
            this.pnlBgWhite.Controls.Add(this.txtBlue);
            this.pnlBgWhite.Click += new System.EventHandler(this.pnlBgWhite_Click);
            this.pnlBgWhite.MouseLeave += new System.EventHandler(this.pnlBgWhite_MouseLeave);
            this.pnlBgWhite.Controls.SetChildIndex(this.txtBlue, 0);
            this.pnlBgWhite.Controls.SetChildIndex(this.lblPlaceholder, 0);
            this.pnlBgWhite.Controls.SetChildIndex(this.lblLegend, 0);
            // 
            // lblLegend
            // 
            this.lblLegend.Click += new System.EventHandler(this.lblLegend_Click);
            // 
            // lblPlaceholder
            // 
            this.lblPlaceholder.Click += new System.EventHandler(this.lblPlaceholder_Click);
            // 
            // txtBlue
            // 
            this.txtBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlue.BackColor = System.Drawing.Color.White;
            this.txtBlue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(85)))));
            this.txtBlue.Location = new System.Drawing.Point(8, 18);
            this.txtBlue.Margin = new System.Windows.Forms.Padding(0);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(188, 18);
            this.txtBlue.TabIndex = 3;
            this.txtBlue.TextChanged += new System.EventHandler(this.txtBlue_TextChanged);
            this.txtBlue.Enter += new System.EventHandler(this.txtBlue_Enter);
            this.txtBlue.Leave += new System.EventHandler(this.txtBlue_Leave);
            // 
            // TextBoxBlue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.MaximumSize = new System.Drawing.Size(758, 43);
            this.Name = "TextBoxBlue";
            this.pnlBgWhite.ResumeLayout(false);
            this.pnlBgWhite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtBlue;

    }
}
