using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNX
{
    public class cDataBaseConfig
    {
        //DB_SOLUTION
        public static DatabaseType SolutionType { get; set; }
        public static string SolutionFile { get; set; }
        public static string SolutionDataSource { get; set; }

        //DB_GERAL
        public static DatabaseType GeralType { get; set; }
        public static string GeralDataSource { get; set; }
    }
}
