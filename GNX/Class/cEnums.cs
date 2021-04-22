using System;
//

namespace GNX
{
    public enum DbAction
    {
        Null,
        Select,
        Insert,
        Update,
        Delete
    }

    public enum DbSystem
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

    public enum TextMask
    {
        None,
        CELULAR,
        CEP,
        CNPJ,
        CPF,
        DATA,
        DINHEIRO,
        HORA,
        NUMERO
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
