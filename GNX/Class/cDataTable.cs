using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
//

namespace GNX
{
    [Serializable]
    public class cDataTable : DataTable
    {
        protected cDataTable(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public cDataTable()
            : base()
        {
        }

        //public List<cDataRow> RowsList()
        //{
        //    List<cDataRow> lRows = new List<cDataRow>();

        //    foreach (DataRow row in Rows)
        //    {
        //        cDataRow cRow = (cDataRow)row;

        //        lRows.Add(cRow);
        //    }

        //    return lRows;
        //}
    }
}
