namespace GNX
{
    partial class MainBaseForm
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
            this.pnlFoot = new GNX.FlatPanel();
            this.staStatus = new GNX.FlatStatusBar();
            this.pnlHead = new GNX.FlatPanel();
            this.pnlBody = new GNX.FlatPanel();
            this.pnlContent = new GNX.FlatPanel();
            this.pnlFoot.SuspendLayout();
            this.pnlHead.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFoot
            // 
            this.pnlFoot.BackColor = System.Drawing.Color.Transparent;
            this.pnlFoot.BorderRound = false;
            this.pnlFoot.Controls.Add(this.staStatus);
            this.pnlFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFoot.Location = new System.Drawing.Point(0, 246);
            this.pnlFoot.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFoot.Name = "pnlFoot";
            this.pnlFoot.Size = new System.Drawing.Size(480, 24);
            this.pnlFoot.TabIndex = 0;
            // 
            // staStatus
            // 
            this.staStatus.BackColor = System.Drawing.Color.Transparent;
            this.staStatus.BorderEnable = false;
            this.staStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staStatus.Location = new System.Drawing.Point(0, 0);
            this.staStatus.Movimento = GNX.Movimento.Nenhum;
            this.staStatus.Name = "staStatus";
            this.staStatus.Registros = null;
            this.staStatus.Size = new System.Drawing.Size(480, 24);
            this.staStatus.TabIndex = 0;
            // 
            // pnlHead
            // 
            this.pnlHead.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlHead.BorderRound = false;
            this.pnlHead.BorderSize = 0;
            this.pnlHead.Controls.Add(this.pnlBody);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Padding = new System.Windows.Forms.Padding(8, 8, 8, 32);
            this.pnlHead.Size = new System.Drawing.Size(480, 270);
            this.pnlHead.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.pnlBody.Controls.Add(this.pnlContent);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(8, 8);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBody.Size = new System.Drawing.Size(464, 230);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.pnlContent.BorderRound = false;
            this.pnlContent.BorderSize = 0;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(3, 3);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(458, 224);
            this.pnlContent.TabIndex = 0;
            // 
            // MainBaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.ClientSize = new System.Drawing.Size(480, 270);
            this.Controls.Add(this.pnlFoot);
            this.Controls.Add(this.pnlHead);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "MainBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainBaseForm";
            this.pnlFoot.ResumeLayout(false);
            this.pnlHead.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatPanel pnlFoot;
        private FlatPanel pnlHead;
        private FlatPanel pnlBody;
        protected FlatPanel pnlContent;
        protected FlatStatusBar staStatus;

    }
}