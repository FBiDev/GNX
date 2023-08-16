namespace GNX.Desktop
{
    partial class DebugForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.tabControl = new FlatTabControl();
            this.tabMessage = new System.Windows.Forms.TabPage();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.tabError = new System.Windows.Forms.TabPage();
            this.tabSQLSistema = new System.Windows.Forms.TabPage();
            this.lblDgv1NoRows = new System.Windows.Forms.Label();
            this.dgvSQLSistema = new FlatDataGrid();
            this.tabSQLBase = new System.Windows.Forms.TabPage();
            this.lblDgv2NoRows = new System.Windows.Forms.Label();
            this.dgvSQLBase = new FlatDataGrid();
            this.pnlContent.SuspendLayout();
            this.pnlBorder1.SuspendLayout();
            this.pnlBorder2.SuspendLayout();
            this.pnlMargin.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMessage.SuspendLayout();
            this.tabError.SuspendLayout();
            this.tabSQLSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQLSistema)).BeginInit();
            this.tabSQLBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQLBase)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Size = new System.Drawing.Size(451, 255);
            // 
            // pnlBorder1
            // 
            this.pnlBorder1.Size = new System.Drawing.Size(453, 257);
            // 
            // pnlBorder2
            // 
            this.pnlBorder2.Size = new System.Drawing.Size(451, 255);
            // 
            // lblCenter
            // 
            this.lblCenter.Size = new System.Drawing.Size(219, 6);
            // 
            // pnlMargin
            // 
            this.pnlMargin.Controls.Add(this.tabControl);
            this.pnlMargin.Margin = new System.Windows.Forms.Padding(9);
            this.pnlMargin.Size = new System.Drawing.Size(439, 243);
            // 
            // txtErrors
            // 
            this.txtErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrors.BackColor = System.Drawing.Color.White;
            this.txtErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtErrors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrors.ForeColor = System.Drawing.Color.Crimson;
            this.txtErrors.Location = new System.Drawing.Point(0, 0);
            this.txtErrors.Margin = new System.Windows.Forms.Padding(0);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrors.Size = new System.Drawing.Size(427, 209);
            this.txtErrors.TabIndex = 1;
            this.txtErrors.WordWrap = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabMessage);
            this.tabControl.Controls.Add(this.tabError);
            this.tabControl.Controls.Add(this.tabSQLSistema);
            this.tabControl.Controls.Add(this.tabSQLBase);
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.myBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(435, 238);
            this.tabControl.TabIndex = 2;
            // 
            // tabMessage
            // 
            this.tabMessage.BackColor = System.Drawing.Color.White;
            this.tabMessage.Controls.Add(this.txtMessages);
            this.tabMessage.Location = new System.Drawing.Point(4, 25);
            this.tabMessage.Name = "tabMessage";
            this.tabMessage.Size = new System.Drawing.Size(427, 209);
            this.tabMessage.TabIndex = 3;
            this.tabMessage.Text = "Message";
            // 
            // txtMessages
            // 
            this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessages.BackColor = System.Drawing.Color.White;
            this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessages.Location = new System.Drawing.Point(0, 0);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(0);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessages.Size = new System.Drawing.Size(427, 209);
            this.txtMessages.TabIndex = 2;
            this.txtMessages.WordWrap = false;
            // 
            // tabError
            // 
            this.tabError.BackColor = System.Drawing.Color.White;
            this.tabError.Controls.Add(this.txtErrors);
            this.tabError.Location = new System.Drawing.Point(4, 25);
            this.tabError.Name = "tabError";
            this.tabError.Padding = new System.Windows.Forms.Padding(3);
            this.tabError.Size = new System.Drawing.Size(427, 209);
            this.tabError.TabIndex = 0;
            this.tabError.Text = "Error";
            // 
            // tabSQLSistema
            // 
            this.tabSQLSistema.BackColor = System.Drawing.Color.White;
            this.tabSQLSistema.Controls.Add(this.lblDgv1NoRows);
            this.tabSQLSistema.Controls.Add(this.dgvSQLSistema);
            this.tabSQLSistema.Location = new System.Drawing.Point(4, 25);
            this.tabSQLSistema.Name = "tabSQLSistema";
            this.tabSQLSistema.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQLSistema.Size = new System.Drawing.Size(427, 209);
            this.tabSQLSistema.TabIndex = 1;
            this.tabSQLSistema.Text = "SQL Sistema";
            // 
            // lblDgv1NoRows
            // 
            this.lblDgv1NoRows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDgv1NoRows.Location = new System.Drawing.Point(0, 0);
            this.lblDgv1NoRows.Name = "lblDgv1NoRows";
            this.lblDgv1NoRows.Size = new System.Drawing.Size(427, 26);
            this.lblDgv1NoRows.TabIndex = 3;
            this.lblDgv1NoRows.Text = "Nenhum Registro";
            this.lblDgv1NoRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSQLSistema
            // 
            this.dgvSQLSistema.Location = new System.Drawing.Point(0, 0);
            this.dgvSQLSistema.Name = "dgvSQLSistema";
            this.dgvSQLSistema.Size = new System.Drawing.Size(428, 209);
            this.dgvSQLSistema.TabIndex = 0;
            // 
            // tabSQLBase
            // 
            this.tabSQLBase.BackColor = System.Drawing.Color.White;
            this.tabSQLBase.Controls.Add(this.lblDgv2NoRows);
            this.tabSQLBase.Controls.Add(this.dgvSQLBase);
            this.tabSQLBase.Location = new System.Drawing.Point(4, 25);
            this.tabSQLBase.Name = "tabSQLBase";
            this.tabSQLBase.Size = new System.Drawing.Size(427, 209);
            this.tabSQLBase.TabIndex = 2;
            this.tabSQLBase.Text = "SQL Base";
            // 
            // lblDgv2NoRows
            // 
            this.lblDgv2NoRows.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDgv2NoRows.Location = new System.Drawing.Point(0, 0);
            this.lblDgv2NoRows.Name = "lblDgv2NoRows";
            this.lblDgv2NoRows.Size = new System.Drawing.Size(427, 26);
            this.lblDgv2NoRows.TabIndex = 2;
            this.lblDgv2NoRows.Text = "Nenhum Registro";
            this.lblDgv2NoRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSQLBase
            // 
            this.dgvSQLBase.Location = new System.Drawing.Point(0, 0);
            this.dgvSQLBase.Name = "dgvSQLBase";
            this.dgvSQLBase.Size = new System.Drawing.Size(428, 209);
            this.dgvSQLBase.TabIndex = 1;
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 259);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DebugForm";
            this.Text = "Debug";
            this.pnlContent.ResumeLayout(false);
            this.pnlBorder1.ResumeLayout(false);
            this.pnlBorder2.ResumeLayout(false);
            this.pnlMargin.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabMessage.ResumeLayout(false);
            this.tabMessage.PerformLayout();
            this.tabError.ResumeLayout(false);
            this.tabError.PerformLayout();
            this.tabSQLSistema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQLSistema)).EndInit();
            this.tabSQLBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSQLBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtErrors;
        private FlatTabControl tabControl;
        private System.Windows.Forms.TabPage tabError;
        private System.Windows.Forms.TabPage tabSQLSistema;
        private System.Windows.Forms.TabPage tabSQLBase;
        private System.Windows.Forms.TabPage tabMessage;
        private System.Windows.Forms.TextBox txtMessages;
        private FlatDataGrid dgvSQLSistema;
        private FlatDataGrid dgvSQLBase;
        private System.Windows.Forms.Label lblDgv2NoRows;
        private System.Windows.Forms.Label lblDgv1NoRows;

    }
}