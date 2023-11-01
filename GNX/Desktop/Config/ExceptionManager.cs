﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class ExceptionManager
    {
        public static void Resolve(Exception ex, string customMessage = "")
        {
            var exProc = GNX.ExceptionManager.Process(ex);
            
            if (exProc.HasLink)
            {
                // + errorLineBreak + Error.Message
                if (MessageBox.Show(exProc.Message + customMessage, "Erro", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    var sInfo = new ProcessStartInfo(exProc.Link);
                    Process.Start(sInfo);
                }
            }
            else if (exProc.OleDb)
            {
                //+ errorLineBreak + ErrorDb.Message
                MessageBox.Show(exProc.Message + customMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!exProc.ExternalDll)
            {
                MessageBox.Show(exProc.Message + customMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(CustomMessage + errorLineBreak + Error.Message + errorLineBreak + Error.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new Exception(CustomMessage + errorLineBreak + Error.Message);
            }
        }
    }
}