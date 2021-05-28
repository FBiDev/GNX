namespace GNX
{
    partial class BaseForm
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
            this.pnlBorder2 = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblCenter = new System.Windows.Forms.Label();
            this.pnlMargin = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlStatus1 = new System.Windows.Forms.Panel();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.pnlStatus2 = new System.Windows.Forms.Panel();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.pnlBorder1 = new System.Windows.Forms.Panel();
            this.pnlBorder2.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlStatus1.SuspendLayout();
            this.pnlStatus2.SuspendLayout();
            this.pnlBorder1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorder2
            // 
            this.pnlBorder2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBorder2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.pnlBorder2.Controls.Add(this.pnlContent);
            this.pnlBorder2.Controls.Add(this.pnlStatus);
            this.pnlBorder2.Location = new System.Drawing.Point(1, 1);
            this.pnlBorder2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBorder2.Name = "pnlBorder2";
            this.pnlBorder2.Size = new System.Drawing.Size(296, 296);
            this.pnlBorder2.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.SystemColors.Control;
            this.pnlContent.Controls.Add(this.lblCenter);
            this.pnlContent.Controls.Add(this.pnlMargin);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(296, 273);
            this.pnlContent.TabIndex = 1;
            // 
            // lblCenter
            // 
            this.lblCenter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCenter.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCenter.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCenter.Location = new System.Drawing.Point(11, 0);
            this.lblCenter.Margin = new System.Windows.Forms.Padding(0);
            this.lblCenter.Name = "lblCenter";
            this.lblCenter.Size = new System.Drawing.Size(132, 11);
            this.lblCenter.TabIndex = 0;
            this.lblCenter.Text = "Align center";
            this.lblCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCenter.Visible = false;
            // 
            // pnlMargin
            // 
            this.pnlMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMargin.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMargin.Location = new System.Drawing.Point(11, 11);
            this.pnlMargin.Margin = new System.Windows.Forms.Padding(9, 9, 9, 15);
            this.pnlMargin.Name = "pnlMargin";
            this.pnlMargin.Size = new System.Drawing.Size(274, 250);
            this.pnlMargin.TabIndex = 0;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pnlStatus.Controls.Add(this.pnlStatus1);
            this.pnlStatus.Controls.Add(this.pnlStatus2);
            this.pnlStatus.Location = new System.Drawing.Point(0, 274);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(296, 22);
            this.pnlStatus.TabIndex = 2;
            // 
            // pnlStatus1
            // 
            this.pnlStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.pnlStatus1.Controls.Add(this.lblStatus1);
            this.pnlStatus1.Location = new System.Drawing.Point(0, 4);
            this.pnlStatus1.Name = "pnlStatus1";
            this.pnlStatus1.Size = new System.Drawing.Size(116, 15);
            this.pnlStatus1.TabIndex = 0;
            // 
            // lblStatus1
            // 
            this.lblStatus1.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus1.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus1.Location = new System.Drawing.Point(0, 0);
            this.lblStatus1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(115, 15);
            this.lblStatus1.TabIndex = 3;
            this.lblStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatus2
            // 
            this.pnlStatus2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.pnlStatus2.Controls.Add(this.lblStatus2);
            this.pnlStatus2.Location = new System.Drawing.Point(122, 4);
            this.pnlStatus2.Name = "pnlStatus2";
            this.pnlStatus2.Size = new System.Drawing.Size(116, 15);
            this.pnlStatus2.TabIndex = 4;
            // 
            // lblStatus2
            // 
            this.lblStatus2.BackColor = System.Drawing.SystemColors.Control;
            this.lblStatus2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus2.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus2.Location = new System.Drawing.Point(0, 0);
            this.lblStatus2.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(115, 15);
            this.lblStatus2.TabIndex = 3;
            this.lblStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBorder1
            // 
            this.pnlBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBorder1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBorder1.Controls.Add(this.pnlBorder2);
            this.pnlBorder1.Location = new System.Drawing.Point(1, 1);
            this.pnlBorder1.Name = "pnlBorder1";
            this.pnlBorder1.Size = new System.Drawing.Size(298, 298);
            this.pnlBorder1.TabIndex = 0;
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.pnlBorder1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(246, 246);
            this.Name = "BaseForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "TitleBar";
            this.pnlBorder2.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus1.ResumeLayout(false);
            this.pnlStatus2.ResumeLayout(false);
            this.pnlBorder1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlContent;
        protected System.Windows.Forms.Panel pnlBorder1;
        protected System.Windows.Forms.Panel pnlBorder2;
        protected System.Windows.Forms.Panel pnlStatus;
        protected System.Windows.Forms.Label lblCenter;
        protected System.Windows.Forms.Panel pnlMargin;
        protected System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.Panel pnlStatus1;
        private System.Windows.Forms.Panel pnlStatus2;
        protected System.Windows.Forms.Label lblStatus2;
    }
}