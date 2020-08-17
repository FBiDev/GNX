namespace GNX
{
    partial class TextBoxBaseBlue
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
            this.pnlBg.TabIndex = 1;
            // 
            // pnlBgWhite
            // 
            this.pnlBgWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBgWhite.BackColor = System.Drawing.Color.White;
            this.pnlBgWhite.Controls.Add(this.lblLegend);
            this.pnlBgWhite.Controls.Add(this.lblPlaceholder);
            this.pnlBgWhite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBgWhite.Location = new System.Drawing.Point(1, 1);
            this.pnlBgWhite.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBgWhite.Name = "pnlBgWhite";
            this.pnlBgWhite.Size = new System.Drawing.Size(204, 41);
            this.pnlBgWhite.TabIndex = 1;
            this.pnlBgWhite.MouseEnter += new System.EventHandler(this.pnlBgWhite_MouseEnter);
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
            this.lblPlaceholder.MouseEnter += new System.EventHandler(this.lblPlaceholder_MouseEnter);
            // 
            // TextBoxBaseBlue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlBg);
            this.MaximumSize = new System.Drawing.Size(300, 43);
            this.MinimumSize = new System.Drawing.Size(100, 43);
            this.Name = "TextBoxBaseBlue";
            this.Size = new System.Drawing.Size(206, 43);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TextBoxBaseBlue_Paint);
            this.pnlBg.ResumeLayout(false);
            this.pnlBgWhite.ResumeLayout(false);
            this.pnlBgWhite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBg;
        protected System.Windows.Forms.Panel pnlBgWhite;
        protected System.Windows.Forms.Label lblLegend;
        protected System.Windows.Forms.Label lblPlaceholder;


    }
}
