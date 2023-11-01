using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GNX.Properties;

namespace GNX.Desktop
{
    public partial class DebugForm : BaseForm2
    {
        public DebugForm()
        {
            InitializeComponent();

            Icon = Resources.ico_debug;

            Load += Form_Load;
            Shown += Form_Shown;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;

            dgvSQLSistema.Visible = false;
            dgvSQLSistema.RowsAdded += dgv_RowsAdded;
            dgvSQLSistema.MouseDown += (sender, e) => dgvSQLSistema.ShowContextMenu(e, mnuSqlSystem);

            mniSqlSystemCopyCommand.MouseDown += mniSqlSystemCopyCommand_MouseDown;
            mniSqlSystemCopyLog.MouseDown += mniSqlSystemCopyLog_MouseDown;

            dgvSQLBase.Visible = false;
            dgvSQLBase.RowsAdded += dgv_RowsAdded;
            dgvSQLBase.MouseDown += (sender, e) => dgvSQLBase.ShowContextMenu(e, mnuSqlBase);

            mniSqlBaseCopyCommand.MouseDown += mniSqlBaseCopyCommand_MouseDown;
            mniSqlBaseCopyLog.MouseDown += mniSqlBaseCopyLog_MouseDown;
        }

        void Form_Load(object sender, EventArgs e)
        {
            //TopMost = true;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
            Left = 0;

            dgvSQLSistema.AutoGenerateColumns = false;
            dgvSQLSistema.AddColumn<int>("Line", "Linha", "", "", DataGridViewContentAlignment.MiddleCenter, null, true, 64);
            dgvSQLSistema.AddColumn<DateTime>("Date", "Data", "", "", DataGridViewContentAlignment.MiddleCenter, null, true, 85);
            dgvSQLSistema.AddColumn<string>("Method", "Função");
            dgvSQLSistema.AddColumn<string>("Action", "Ação", "", "", 0, null, true, 60);
            dgvSQLSistema.AddColumn<string>("Command", "Comando");
            dgvSQLSistema.Columns["Command"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSQLSistema.DataSource = cDebug.LogSQLSistema;

            dgvSQLBase.AutoGenerateColumns = false;
            dgvSQLBase.AddColumn<int>("Line", "Linha", "", "", DataGridViewContentAlignment.MiddleCenter, null, true, 64);
            dgvSQLBase.AddColumn<DateTime>("Date", "Data", "", "", DataGridViewContentAlignment.MiddleCenter, null, true, 85);
            dgvSQLBase.AddColumn<string>("Method", "Função");
            dgvSQLBase.AddColumn<string>("Action", "Ação", "", "", 0, null, true, 60);
            dgvSQLBase.AddColumn<string>("Command", "Comando");
            dgvSQLBase.Columns["Command"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSQLBase.DataSource = cDebug.LogSQLBase;

            UpdateErrors();
            UpdateMessages();
        }

        void Form_Shown(object sender, EventArgs e) { }

        void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabSQLSistema)
            {
                dgvSQLSistema.Focus();
            }
            else if (tabControl.SelectedTab == tabSQLBase)
            {
                dgvSQLBase.Focus();
            }
        }

        public void TabSelectIndex(int index)
        {
            tabControl.SelectedIndex = index;
        }

        void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridView)sender).Visible = true;
            if (((DataGridView)sender) == dgvSQLSistema)
            {
                lblDgv1NoRows.Visible = false;
            }
            else
            {
                lblDgv2NoRows.Visible = false;
            }

            if (((DataGridView)sender).RowCount > 0)
            {
                ((DataGridView)sender).FirstDisplayedScrollingRowIndex = 0;
            }
        }

        void mniSqlSystemCopyCommand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var log = dgvSQLSistema.GetCurrentRowObject<cLogSQL>();
            Clipboard.SetText(log.Command + Environment.NewLine);
        }

        void mniSqlBaseCopyCommand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var log = dgvSQLBase.GetCurrentRowObject<cLogSQL>();
            Clipboard.SetText(log.Command + Environment.NewLine);
        }

        void mniSqlSystemCopyLog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var log = dgvSQLSistema.GetCurrentRowValue(true);
            Clipboard.SetText(log);
        }

        void mniSqlBaseCopyLog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var log = dgvSQLBase.GetCurrentRowValue(true);
            Clipboard.SetText(log);
        }

        public void UpdateErrors()
        {
            UpdateErrorTitle();
            var errors = cDebug.GetErrors();

            txtErrors.Text = string.Empty;
            foreach (KeyValuePair<string, int> item in errors)
            {
                txtErrors.Text += "[" + item.Value + "x] " + item.Key;
            }
        }

        public void UpdateErrorTitle()
        {
            var errors = cDebug.GetErrors();
            string title = errors.Count + " Error";

            if (errors.Count == 0 || errors.Count > 1) { title += "s"; }
            tabError.Text = title;
        }

        public void UpdateMessages()
        {
            UpdateMessageTitle();
            txtMessages.Text = cDebug.GetMessages();
        }

        public void UpdateMessageTitle()
        {
            var messages = cDebug.GetMessages();
            int total = (messages.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)).Length - 1;
            string title = total + " Message";

            if (total == 0 || total > 1) { title += "s"; }
            tabMessage.Text = title;
        }
    }
}