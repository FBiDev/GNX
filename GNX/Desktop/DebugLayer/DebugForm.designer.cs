﻿namespace GNX.Desktop
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.tabControl = new GNX.Desktop.FlatTabControl();
            this.tabMessage = new System.Windows.Forms.TabPage();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.tabError = new System.Windows.Forms.TabPage();
            this.tabSQLSistema = new System.Windows.Forms.TabPage();
            this.lblDgv1NoRows = new System.Windows.Forms.Label();
            this.dgvSQLSistema = new GNX.Desktop.FlatDataGrid();
            this.tabSQLBase = new System.Windows.Forms.TabPage();
            this.lblDgv2NoRows = new System.Windows.Forms.Label();
            this.dgvSQLBase = new GNX.Desktop.FlatDataGrid();
            this.mnuSqlBase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSqlBaseCopyCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSqlBaseCopyLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSqlSystem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniSqlSystemCopyCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSqlSystemCopyLog = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGarbageCollect = new GNX.Desktop.FlatButton();
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
            this.mnuSqlBase.SuspendLayout();
            this.mnuSqlSystem.SuspendLayout();
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
            this.tabControl.MyBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabControl.MyBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.tabControl.MyBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(435, 238);
            this.tabControl.TabIndex = 2;
            // 
            // tabMessage
            // 
            this.tabMessage.BackColor = System.Drawing.Color.White;
            this.tabMessage.Controls.Add(this.btnGarbageCollect);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSQLSistema.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSQLSistema.ColorBackground = System.Drawing.Color.White;
            this.dgvSQLSistema.ColorColumnHeader = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.dgvSQLSistema.ColorColumnSelection = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.dgvSQLSistema.ColorFontRow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSQLSistema.ColorFontRowSelection = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSQLSistema.ColorGrid = System.Drawing.Color.Silver;
            this.dgvSQLSistema.ColorRow = System.Drawing.Color.White;
            this.dgvSQLSistema.ColorRowAlternate = System.Drawing.Color.White;
            this.dgvSQLSistema.ColorRowMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.dgvSQLSistema.ColorRowSelection = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSQLSistema.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSQLSistema.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSQLSistema.Location = new System.Drawing.Point(0, 0);
            this.dgvSQLSistema.MultiSelect = true;
            this.dgvSQLSistema.Name = "dgvSQLSistema";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSQLSistema.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSQLSistema.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvSQLBase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSQLBase.ColorBackground = System.Drawing.Color.White;
            this.dgvSQLBase.ColorColumnHeader = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.dgvSQLBase.ColorColumnSelection = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.dgvSQLBase.ColorFontRow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSQLBase.ColorFontRowSelection = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvSQLBase.ColorGrid = System.Drawing.Color.Silver;
            this.dgvSQLBase.ColorRow = System.Drawing.Color.White;
            this.dgvSQLBase.ColorRowAlternate = System.Drawing.Color.White;
            this.dgvSQLBase.ColorRowMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.dgvSQLBase.ColorRowSelection = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSQLBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSQLBase.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSQLBase.Location = new System.Drawing.Point(0, 0);
            this.dgvSQLBase.MultiSelect = true;
            this.dgvSQLBase.Name = "dgvSQLBase";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSQLBase.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSQLBase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSQLBase.Size = new System.Drawing.Size(428, 209);
            this.dgvSQLBase.TabIndex = 1;
            // 
            // mnuSqlBase
            // 
            this.mnuSqlBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSqlBaseCopyCommand,
            this.mniSqlBaseCopyLog});
            this.mnuSqlBase.Name = "mnuBase";
            this.mnuSqlBase.Size = new System.Drawing.Size(163, 48);
            // 
            // mniSqlBaseCopyCommand
            // 
            this.mniSqlBaseCopyCommand.Name = "mniSqlBaseCopyCommand";
            this.mniSqlBaseCopyCommand.Size = new System.Drawing.Size(162, 22);
            this.mniSqlBaseCopyCommand.Text = "Copy Command";
            // 
            // mniSqlBaseCopyLog
            // 
            this.mniSqlBaseCopyLog.Name = "mniSqlBaseCopyLog";
            this.mniSqlBaseCopyLog.Size = new System.Drawing.Size(162, 22);
            this.mniSqlBaseCopyLog.Text = "Copy Log";
            // 
            // mnuSqlSystem
            // 
            this.mnuSqlSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSqlSystemCopyCommand,
            this.mniSqlSystemCopyLog});
            this.mnuSqlSystem.Name = "mnuBase";
            this.mnuSqlSystem.Size = new System.Drawing.Size(163, 48);
            // 
            // mniSqlSystemCopyCommand
            // 
            this.mniSqlSystemCopyCommand.Name = "mniSqlSystemCopyCommand";
            this.mniSqlSystemCopyCommand.Size = new System.Drawing.Size(162, 22);
            this.mniSqlSystemCopyCommand.Text = "Copy Command";
            // 
            // mniSqlSystemCopyLog
            // 
            this.mniSqlSystemCopyLog.Name = "mniSqlSystemCopyLog";
            this.mniSqlSystemCopyLog.Size = new System.Drawing.Size(162, 22);
            this.mniSqlSystemCopyLog.Text = "Copy Log";
            // 
            // btnGarbageCollect
            // 
            this.btnGarbageCollect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(223)))), ((int)(((byte)(229)))));
            this.btnGarbageCollect.FlatAppearance.BorderSize = 0;
            this.btnGarbageCollect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.btnGarbageCollect.Location = new System.Drawing.Point(2, 28);
            this.btnGarbageCollect.Name = "btnGarbageCollect";
            this.btnGarbageCollect.Size = new System.Drawing.Size(100, 24);
            this.btnGarbageCollect.TabIndex = 3;
            this.btnGarbageCollect.Text = "Garbage Collect";
            this.btnGarbageCollect.Click += new System.EventHandler(this.GarbageCollectOnClick);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 259);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DebugForm";
            this.Text = "Debug";
            this.Controls.SetChildIndex(this.pnlBorder1, 0);
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
            this.mnuSqlBase.ResumeLayout(false);
            this.mnuSqlSystem.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip mnuSqlBase;
        private System.Windows.Forms.ToolStripMenuItem mniSqlBaseCopyCommand;
        private System.Windows.Forms.ContextMenuStrip mnuSqlSystem;
        private System.Windows.Forms.ToolStripMenuItem mniSqlSystemCopyCommand;
        private System.Windows.Forms.ToolStripMenuItem mniSqlBaseCopyLog;
        private System.Windows.Forms.ToolStripMenuItem mniSqlSystemCopyLog;
        private FlatButton btnGarbageCollect;

    }
}