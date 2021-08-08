using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_Chess_Web_Application.Models
{
    public class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool IsLegalMove { get; set; }
        public bool IsOccupaied { get; set; }

        public Cell(int rowNumber, int columnNumber)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
            IsLegalMove = false;
            IsOccupaied = false;
        }
    }
}