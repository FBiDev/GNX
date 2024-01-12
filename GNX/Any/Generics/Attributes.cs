﻿namespace System.ComponentModel
{
    public enum AutoSizeColumnMode
    {
        NotSet = 0,
        None = 1,
        ColumnHeader = 2,
        AllCellsExceptHeader = 4,
        AllCells = 6,
        DisplayedCellsExceptHeader = 8,
        DisplayedCells = 10,
        Fill = 16,
    }

    public enum ColumnAlign
    {
        NotSet = 0,
        Left = 16,
        Center = 32,
        Right = 64
    }

    public enum ColumnFormat
    {
        NotSet,
        StringCenter,
        Number,
        NumberCenter,
        Date,
        DateCenter,
        Image
    }

    public class DisplayAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AutoGenerateField { get; set; }
        public int Order { get; set; }
        public string Format { get; set; }

        public DisplayAttribute()
        {
            Name = null;
            AutoGenerateField = true;
            Order = -1;
        }
    }

    public class DisplayStyleAttribute : Attribute
    {
        public ColumnAlign Align { get; set; }
        public ColumnFormat FormatStyle { get; set; }
        public int ColumnWidth { get; set; }
        public AutoSizeColumnMode AutoSizeMode { get; set; }

        public DisplayStyleAttribute()
        {
            ColumnWidth = -1;
        }
    }
}