using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace GNX
{
    public static class cExcel
    {
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static DataTable Import(string ExcelTab, int IgnoreRowsCount = 0)
        {
            var data = new DataTable();

            try
            {
                //{ Filter = "Excel WorkBook 97-2003|*.xls|Excel WorkBook|*.xlsx", ValidateNames = true }
                using (OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Excel|*.xls;*.xlsx",
                    ValidateNames = true
                })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string constr = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                        "Data Source=" + ofd.FileName + ";" +
                                        "Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        var con = new OleDbConnection(constr);

                        var oconn = new OleDbCommand();
                        oconn.Connection = con;
                        oconn.CommandText = "SELECT * FROM [" + ExcelTab + "$]";

                        var sda = new OleDbDataAdapter(oconn);
                        sda.Fill(data);

                        sda.Dispose();
                        con.Close();

                        for (int i = 0; i < IgnoreRowsCount; i++)
                        {
                            data.Rows.RemoveAt(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cException.ShowBox(ex);
            }

            return data;
        }
    }
}