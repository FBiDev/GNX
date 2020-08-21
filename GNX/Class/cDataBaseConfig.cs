using System;
using System.Data;
//

namespace GNX
{
    public class cDataBaseConfig
    {
        public static bool SQLiteEnable { get; set; }

        //DB_SOLUTION
        public static DatabaseType SolutionType { get; set; }
        public static IDbConnection SolutionConnection { get; set; }
        public static string SolutionFile { get; set; }
        public static string SolutionDataSource { get; set; }

        //DB_GERAL
        public static DatabaseType GeralType { get; set; }
        public static string GeralDataSource { get; set; }
    }
}
