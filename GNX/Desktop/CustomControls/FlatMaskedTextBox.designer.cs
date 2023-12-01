namespace GNX.Desktop
{
    partial class FlatMaskedTextBox
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
            this.txtMain = new System.Windows.Forms.MaskedTextBox();
            this.lblPlaceholder = new System.Windows.Forms.Label();
            this.pnlText = new System.Windows.Forms.Panel();
            this.btnAction = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlText);
            this.pnlContent.Controls.Add(this.btnAction);
            this.pnlContent.Controls.SetChildIndex(this.btnAction, 0);
            this.pnlContent.Controls.SetChildIndex(this.lblSubtitle, 0);
            this.pnlContent.Controls.SetChildIndex(this.pnlText, 0);
            // 
            // txtMain
            // 
            this.txtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMain.BackColor = System.Drawing.Color.White;
            this.txtMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txtMain.Location = new System.Drawing.Point(8, 0);
            this.txtMain.Margin = new System.Windows.Forms.Padding(0);
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(187, 16);
            this.txtMain.TabIndex = 0;
            // 
            // lblPlaceholder
            // 
            this.lblPlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlaceholder.BackColor = System.Drawing.Color.Transparent;
            this.lblPlaceholder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPlaceholder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.lblPlaceholder.Location = new System.Drawing.Point(5, -1);
            this.lblPlaceholder.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlaceholder.Name = "lblPlaceholder";
            this.lblPlaceholder.Size = new System.Drawing.Size(190, 16);
            this.lblPlaceholder.TabIndex = 0;
            // 
            // pnlText
            // 
            this.pnlText.BackColor = System.Drawing.Color.Transparent;
            this.pnlText.Controls.Add(this.lblPlaceholder);
            this.pnlText.Controls.Add(this.txtMain);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlText.Location = new System.Drawing.Point(1, 15);
            this.pnlText.Name = "pnlText";
            this.pnlText.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pnlText.Size = new System.Drawing.Size(178, 16);
            this.pnlText.TabIndex = 0;
            // 
            // btnAction
            // 
            this.btnAction.BackgroundImage = global::GNX.Properties.Resources.img_calendar_dark;
            this.btnAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAction.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(179, 2);
            this.btnAction.MaximumSize = new System.Drawing.Size(24, 0);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(24, 29);
            this.btnAction.TabIndex = 1;
            this.btnAction.TabStop = false;
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Visible = false;
            // 
            // FlatMaskedTextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "FlatMaskedTextBox";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.MaskedTextBox txtMain;
        protected System.Windows.Forms.Label lblPlaceholder;
        private System.Windows.Forms.Panel pnlText;
        private System.Windows.Forms.Button btnAction;

    }
}
