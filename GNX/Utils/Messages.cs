using System;
using System.Windows.Forms;

namespace GNX
{
    public static class Messages
    {
        public static void ConfigError()
        {
            MessageBox.Show("Não foi possível ler o arquivo de configuração do sistema.", "ERRO CRÍTICO...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cApp.Exit();
        }
    }
}
