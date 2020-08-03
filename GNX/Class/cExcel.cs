using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
//

namespace GNX
{
    public class cExcel
    {
        public static DataTable Import(string ExcelTab, int IgnoreRowsCount = 0)
        {
            DataTable data = new DataTable();

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog()
                    //{ Filter = "Excel WorkBook 97-2003|*.xls|Excel WorkBook|*.xlsx", ValidateNames = true }
                    { Filter = "Excel|*.xls;*.xlsx", ValidateNames = true }
                )
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string name = ExcelTab;
                        string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        ofd.FileName +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);

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
                GNX.cException.ShowBox(ex);
            }

            return data;
        }
    }
}
