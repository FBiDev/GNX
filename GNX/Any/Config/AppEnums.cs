﻿namespace GNX
{
    public enum CultureID
    {
        UnitedStates_English = 1033,
        Brazil_Portuguese = 1046,
        Czech_CzechRepublic = 1029
    }

    public enum DatabaseType
    {
        Undefined,
        SQLServer,
        MySQL,
        PostgreSQL,
        SQLite,
        SQLiteODBC,
        Access,
        Oracle,
        DB2,
        SyBase,
    }

    public enum DatabaseMode
    {
        Desenvolvimento,
        Producao
    }

    public enum DatabaseAction
    {
        Null = -1,
        Update = 0,
        Delete = 1,
        Select = 3,
        Insert = 4,
    }

    public enum GravarLog
    {
        Nao = 0,
        Sim = 1,
    }

    public enum MovimentoLog
    {
        Alteração = 0,
        Exclusão = 1,
        Gravação = 2,
        Impressão = 3,
        Inclusão = 4,
        Todos = 5,
    }
}