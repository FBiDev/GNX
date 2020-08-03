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
            this.pnlBg = new System.Windows.Forms.Panel();
            this.pnlBgWhite = new System.Windows.Forms.Panel();
            this.lblLegend = new System.Windows.Forms.Label();
            this.lblPlaceholder = new System.Windows.Forms.Label();
            this.txtBlue = new System.Windows.Forms.MaskedTextBox();
            this.pnlBg.SuspendLayout();
            this.pnlBgWhite.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBg
            // 
            this.pnlBg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.pnlBg.Controls.Add(this.pnlBgWhite);
            this.pnlBg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBg.Location = new System.Drawing.Point(0, 0);
            this.pnlBg.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBg.Name = "pnlBg";
            this.pnlBg.Size = new System.Drawing.Size(206, 43);
            this.pnlBg.TabIndex = 0;
            // 
            // pnlBgWhite
            // 
            this.pnlBgWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBgWhite.BackColor = System.Drawing.Color.White;
            this.pnlBgWhite.Controls.Add(this.lblLegend);
            this.pnlBgWhite.Controls.Add(this.lblPlaceholder);
            this.pnlBgWhite.Controls.Add(this.txtBlue);
            this.pnlBgWhite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBgWhite.Location = new System.Drawing.Point(1, 1);
            this.pnlBgWhite.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBgWhite.Name = "pnlBgWhite";
            this.pnlBgWhite.Size = new System.Drawing.Size(204, 41);
            this.pnlBgWhite.TabIndex = 1;
            this.pnlBgWhite.Click += new System.EventHandler(this.pnlBgWhite_Click);
            this.pnlBgWhite.MouseEnter += new System.EventHandler(this.pnlBgWhite_MouseEnter);
            this.pnlBgWhite.MouseLeave += new System.EventHandler(this.pnlBgWhite_MouseLeave);
            // 
            // lblLegend
            // 
            this.lblLegend.AutoSize = true;
            this.lblLegend.BackColor = System.Drawing.Color.White;
            this.lblLegend.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.lblLegend.Location = new System.Drawing.Point(4, 5);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(90, 13);
            this.lblLegend.TabIndex = 0;
            this.lblLegend.Text = "Nome Completo";
            this.lblLegend.Click += new System.EventHandler(this.lblLegend_Click);
            this.lblLegend.MouseEnter += new System.EventHandler(this.lblLegend_MouseEnter);
            // 
            // lblPlaceholder
            // 
            this.lblPlaceholder.AutoSize = true;
            this.lblPlaceholder.BackColor = System.Drawing.Color.White;
            this.lblPlaceholder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlaceholder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.lblPlaceholder.Location = new System.Drawing.Point(5, 18);
            this.lblPlaceholder.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlaceholder.Name = "lblPlaceholder";
            this.lblPlaceholder.Size = new System.Drawing.Size(85, 17);
            this.lblPlaceholder.TabIndex = 2;
            this.lblPlaceholder.Text = "João da Silva";
            this.lblPlaceholder.Click += new System.EventHandler(this.lblPlaceholder_Click);
            this.lblPlaceholder.MouseEnter += new System.EventHandler(this.lblPlaceholder_MouseEnter);
            // 
            // txtBlue
            // 
            this.txtBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlue.AsciiOnly = true;
            this.txtBlue.BackColor = System.Drawing.Color.White;
            this.txtBlue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(85)))));
            this.txtBlue.Location = new System.Drawing.Point(8, 18);
            this.txtBlue.Margin = new System.Windows.Forms.Padding(0);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.PromptChar = ' ';
            this.txtBlue.ResetOnSpace = false;
            this.txtBlue.Size = new System.Drawing.Size(188, 18);
            this.txtBlue.TabIndex = 1;
            this.txtBlue.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtBlue.TextChanged += new System.EventHandler(this.txtBlue_TextChanged);
            this.txtBlue.Enter += new System.EventHandler(this.txtBlue_Enter);
            this.txtBlue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBlue_KeyPress);
            this.txtBlue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBlue_KeyUp);
            this.txtBlue.Leave += new System.EventHandler(this.txtBlue_Leave);
            this.txtBlue.MouseEnter += new System.EventHandler(this.txtBlue_MouseEnter);
            // 
            // TextBoxBlue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlBg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(300, 43);
            this.MinimumSize = new System.Drawing.Size(100, 43);
            this.Name = "TextBoxBlue";
            this.Size = new System.Drawing.Size(206, 43);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TextBoxBlue_Paint);
            this.pnlBg.ResumeLayout(false);
            this.pnlBgWhite.ResumeLayout(false);
            this.pnlBgWhite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBg;
        private System.Windows.Forms.Panel pnlBgWhite;
        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.MaskedTextBox txtBlue;
        private System.Windows.Forms.Label lblPlaceholder;
    }
}
