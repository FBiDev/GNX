using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GNX.Properties;
using System.Drawing;

namespace GNX
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
            dgvSQLBase.Visible = false;
            dgvSQLSistema.RowsAdded += dgv_RowsAdded;
            dgvSQLBase.RowsAdded += dgv_RowsAdded;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //TopMost = true;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height;
            Left = 0;

            dgvSQLSistema.AutoGenerateColumns = false;
            dgvSQLSistema.AddColumn<int>("Line", "Linha", "", "", 0, null, true, 50);
            dgvSQLSistema.AddColumn<DateTime>("Date", "Data");
            dgvSQLSistema.AddColumn<string>("Method", "Função");
            dgvSQLSistema.AddColumn<string>("Action", "Ação", "", "", 0, null, true, 50);
            dgvSQLSistema.AddColumn<string>("Command", "Comando");
            dgvSQLSistema.DataSource = cDebug.LogSQLSistema;

            dgvSQLBase.AutoGenerateColumns = false;
            dgvSQLBase.AddColumn<int>("Line", "Linha", "", "", 0, null, true, 50);
            dgvSQLBase.AddColumn<DateTime>("Date", "Data");
            dgvSQLBase.AddColumn<string>("Method", "Função");
            dgvSQLBase.AddColumn<string>("Action", "Ação", "", "", 0, null, true, 50);
            dgvSQLBase.AddColumn<string>("Command", "Comando");
            dgvSQLBase.DataSource = cDebug.LogSQLBase;

            UpdateErrors();
            UpdateMessages();
        }

        private void Form_Shown(object sender, EventArgs e) { }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                dgvSQLSistema.Focus();
            }
        }

        public void TabSelectIndex(int index)
        {
            tabControl.SelectedIndex = index;
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
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

        public void UpdateErrors()
        {
            UpdateErrorTitle();
            List<KeyValuePair<string, int>> errors = cDebug.GetErrors();

            txtErrors.Text = string.Empty;
            foreach (KeyValuePair<string, int> item in errors)
            {
                txtErrors.Text += "[" + item.Value + "x] " + item.Key;
            }
        }

        public void UpdateErrorTitle()
        {
            List<KeyValuePair<string, int>> errors = cDebug.GetErrors();
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
            string messages = cDebug.GetMessages();
            int total = (messages.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)).Length - 1;
            string title = total + " Message";
            if (total == 0 || total > 1) { title += "s"; }
            tabMessage.Text = title;
        }
    }
}
