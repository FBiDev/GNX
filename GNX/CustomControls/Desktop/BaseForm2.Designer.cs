﻿namespace GNX
{
    partial class BaseForm2
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
            this.pnlBorder1 = new System.Windows.Forms.Panel();
            this.pnlBorder2.SuspendLayout();
            this.pnlContent.SuspendLayout();
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
            this.pnlBorder2.Location = new System.Drawing.Point(1, 1);
            this.pnlBorder2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBorder2.Name = "pnlBorder2";
            this.pnlBorder2.Size = new System.Drawing.Size(350, 296);
            this.pnlBorder2.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlContent.Controls.Add(this.lblCenter);
            this.pnlContent.Controls.Add(this.pnlMargin);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(350, 296);
            this.pnlContent.TabIndex = 1;
            // 
            // lblCenter
            // 
            this.lblCenter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCenter.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCenter.Location = new System.Drawing.Point(6, 0);
            this.lblCenter.Margin = new System.Windows.Forms.Padding(0);
            this.lblCenter.Name = "lblCenter";
            this.lblCenter.Size = new System.Drawing.Size(169, 6);
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
            this.pnlMargin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlMargin.Location = new System.Drawing.Point(6, 6);
            this.pnlMargin.Margin = new System.Windows.Forms.Padding(9, 9, 9, 15);
            this.pnlMargin.Name = "pnlMargin";
            this.pnlMargin.Size = new System.Drawing.Size(338, 284);
            this.pnlMargin.TabIndex = 0;
            // 
            // pnlBorder1
            // 
            this.pnlBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBorder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlBorder1.Controls.Add(this.pnlBorder2);
            this.pnlBorder1.Location = new System.Drawing.Point(1, 1);
            this.pnlBorder1.Name = "pnlBorder1";
            this.pnlBorder1.Size = new System.Drawing.Size(352, 298);
            this.pnlBorder1.TabIndex = 0;
            // 
            // BaseForm2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(354, 300);
            this.Controls.Add(this.pnlBorder1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(246, 246);
            this.Name = "BaseForm2";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "BaseForm2";
            this.pnlBorder2.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlBorder1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlContent;
        protected System.Windows.Forms.Panel pnlBorder1;
        protected System.Windows.Forms.Panel pnlBorder2;
        protected System.Windows.Forms.Label lblCenter;
        protected System.Windows.Forms.Panel pnlMargin;
    }
}