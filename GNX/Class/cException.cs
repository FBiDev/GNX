using System;
//
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;

namespace GNX
{
    public class cException
    {
        public static void ShowBox(Exception ex, string ArgumentString = null)
        {
            string errormsg = ex.ToString();
            string CustomMessage = "";
            string errorLineBreak = "\r\n\r\n";

            Exception Error = ex;
            Type ExType = ex.GetType();

            OleDbError ErrorDb = default(OleDbError);
            bool OleDb = false;

            bool link = false;
            string linkStr = string.Empty;

            if (ExType == typeof(Exception))
            {
                if (Error.TargetSite.Module.Name == "ControleCasamentos.exe")
                {
                    //No Database File
                    if (Error.TargetSite.Name == "CreateConnection")
                    {
                        CustomMessage = "Arquivo de Banco de dados não encontrado";
                    }
                }
            }

            else if (ExType == typeof(InvalidOperationException))
            {
                Error = ((InvalidOperationException)ex);

                if (Error.TargetSite.Module.Name == "System.Data.dll")
                {
                    //Engine not Installed
                    if (Error.TargetSite.Name == "GetDataSource")
                    {
                        link = true;
                        linkStr = "https://www.microsoft.com/en-us/download/confirmation.aspx?id=54920";

                        CustomMessage = "Motor Excel não instalado, clique em OK para ir fazer o download";
                    }

                    //Not Closed Connection
                    else if (Error.TargetSite.Name == "TryOpenConnection")
                    {
                        CustomMessage = "Falha na conexão com o Banco de Dados";
                    }
                }
            }

            else if (ExType == typeof(ArgumentException))
            {
                Error = ((ArgumentException)ex);

                if (Error.TargetSite.Module.Name == "System.Data.dll")
                {
                    //Provider
                    if (Error.TargetSite.Name == "ValidateProvider")
                    {
                        CustomMessage = "Falha ao validar Provider do arquivo";
                    }
                }

                else if (Error.TargetSite.Module.Name == "System.Data.SQLite.dll")
                {
                    //Datasource
                    if (Error.TargetSite.Name == "Open")
                    {
                        CustomMessage = "Falha na conexão com o Banco de Dados";
                    }
                }
            }

            else if (ExType == typeof(FormatException))
            {
                Error = ((FormatException)ex);

                if (Error.TargetSite.Module.Name == "mscorlib.dll")
                {
                    //Conversion
                    if (Error.TargetSite.Name == "StringToNumber")
                    {
                        CustomMessage = "Falha ao converter Texto para Número:\r\n" + ArgumentString;
                    }
                    else if (Error.TargetSite.Name == "ParseExactMultiple")
                    {
                        CustomMessage = "Falha ao converter Texto para Data:\r\n" + ArgumentString;
                    }
                    else if (Error.TargetSite.Name == "ParseDouble")
                    {
                        CustomMessage = "Falha ao converter Texto para Double:\r\n" + ArgumentString;
                    }
                    else if (Error.TargetSite.Name == "Parse")
                    {
                        CustomMessage = "Falha ao converter Texto para Boolean:\r\n" + ArgumentString;
                    }
                }
            }

            else if (ExType == typeof(InvalidCastException))
            {
                Error = ((InvalidCastException)ex);

                if (Error.TargetSite.Module.Name == "System.Data.SQLite.dll")
                {
                    //Conversion
                    if (Error.TargetSite.Name == "BindParameter")
                    {
                        CustomMessage = "Falha ao converter Parâmetro:\r\n" + ArgumentString;
                    }
                }
            }

            else if (ExType == typeof(BadImageFormatException))
            {
                Error = ((BadImageFormatException)ex);

                if (Error.TargetSite.Module.Name == "System.Data.SQLite.dll")
                {
                    //No ODBC Driver installed
                    if (Error.TargetSite.Name == "sqlite3_config_none")
                    {
                        CustomMessage = "Falha na conexão com o Banco de Dados";
                    }
                }
            }

            else if (ExType == typeof(NotSupportedException))
            {
                Error = ((NotSupportedException)ex);

                if (Error.TargetSite.Module.Name == "System.Data.SQLite.dll")
                {
                    //SQLite Version
                    if (Error.TargetSite.Name == "Open")
                    {
                        CustomMessage = "Versão do SQLite incorreta";
                    }
                }
            }

            else if (ExType == typeof(SQLiteException))
            {
                Error = ((SQLiteException)ex);

                if (Error.TargetSite.Module.Name == "System.Data.SQLite.dll")
                {
                    //SQL Syntax
                    if (Error.TargetSite.Name == "Prepare")
                    {
                        CustomMessage = "Sintaxe do SQL errada:\r\n" + ArgumentString;
                    }
                }
            }

            else if (ExType == typeof(DllNotFoundException))
            {
                Error = ((DllNotFoundException)ex);

                CustomMessage = "Arquivo DLL não encontrado";
            }

            else if (ExType == typeof(OleDbException))
            {
                OleDb = true;
                ErrorDb = ((OleDbException)ex).Errors[0];

                //ISAM Extended Properties
                if (ErrorDb.NativeError == -69141536)
                {
                }

                //Opened File
                else if (ErrorDb.NativeError == -67568648)
                {
                }

                //Excel Tab Wrong Name
                else if (ErrorDb.NativeError == -537199594)
                {
                }
            }

            else
            {
                string ExTypeStr = "ExType  : " + ExType.ToString();
                string Target = "\r\nTarget   : " + Error.TargetSite.Module.Name;
                string Method = "\r\nMethod : " + Error.TargetSite.Name;

                CustomMessage = "Erro inesperado não tratado";
                CustomMessage += errorLineBreak + ExTypeStr + Target + Method;
            }

            if (link)
            {
                if (MessageBox.Show(CustomMessage + errorLineBreak + Error.Message, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.OK)
                {
                    ProcessStartInfo sInfo = new ProcessStartInfo(linkStr);
                    Process.Start(sInfo);
                }
            }
            else if (OleDb)
            {
                MessageBox.Show(ErrorDb.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(CustomMessage + errorLineBreak + Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
