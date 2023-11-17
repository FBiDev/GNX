﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GNX.Desktop
{
    public static class TaskExtension
    {
#pragma warning disable
        public static async void TryAwait(this Task task)
#pragma warning restore
        {
            try
            {
                GNX.TaskExtension.TryAwait(task);
            }
            catch (Exception ex)
            {
                var exceptionMessage = "[Task Failed]" + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine;
                var stackCalls = ObjectManager.GetStackTrace(ex);
                var errorMessage = exceptionMessage + stackCalls;

                Clipboard.SetText(errorMessage);
                MessageBox.Show(errorMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}