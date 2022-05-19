using System;
using System.Windows.Forms;

namespace GNX
{
    public static class Messages
    {
        public static string ConfigReadError()
        {
            return "Não foi possível ler o arquivo de configuração do sistema (Config.xml).";
        }

        public static string ColumnError(string columnName)
        {
            return "Coluna: [" + columnName + "] nao encontrada";
        }
    }
}
