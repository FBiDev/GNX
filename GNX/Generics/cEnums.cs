using System;
//

namespace GNX
{
    public enum OSVersion
    {
        Unknown = 0,
        Windows_95 = 40,
        Windows_98 = 410,
        Windows_98SE = 411,
        Windows_ME = 490,
        Windows_NT3 = 300,
        Windows_NT4 = 400,
        Windows_2000 = 50,
        Windows_XP = 51,
        Windows_Vista = 60,
        Windows_7 = 61,
        Windows_8 = 62,
        Windows_8_1 = 63,
        Windows_10 = 100
    }

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

    public enum Movimento
    {
        Nenhum,
        Consulta,
        Inclusão,
        Alteração,
        Exclusão
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
