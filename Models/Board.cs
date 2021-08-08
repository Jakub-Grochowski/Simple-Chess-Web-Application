using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple_Chess_Web_Application.Models
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        public Board()
        {
            Size = 8;
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i,j);
                }
            }
        }

        public Board(int size)
        {
            Size = size;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }
    }
}