using System;
//

namespace GNX
{
    public enum DatabaseType
    {
        SQLite,
        SQLiteODBC,
        SQLServer,
        MySQL,
        PostgreSQL,
        DB2,
        SyBase,
        Oracle,
        Access,
        Undefined
    }

    public enum DatabaseName
    {
        DB_SOLUTION,
        DB_GERAL
    }

    public enum TextMask
    {
        None,
        CPF,
        CNPJ,
        DATA,
        HORA,
        CELULAR,
        NUMERO,
        DINHEIRO
    }

    public enum MenuMode
    {
        Consulta,
        Inclusão,
        Edição
    }

    public enum CultureID
    {
        UnitedStates_English = 1033,
        Brazil_Portuguese = 1046,
        Czech_CzechRepublic = 1029
    }
}
