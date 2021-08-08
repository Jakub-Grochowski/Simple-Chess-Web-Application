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
            theGrid = new Cell[Size, Size];
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
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell,string chessPiece)
        {
            ClearBoard();

            switch (chessPiece)
            {
                case "Knight":
                    theGrid[currentCell.RowNumber+2, currentCell.ColumnNumber+1].IsLegalMove = true;
                    theGrid[currentCell.RowNumber+2, currentCell.ColumnNumber-1].IsLegalMove = true;
                    theGrid[currentCell.RowNumber-2, currentCell.ColumnNumber+1].IsLegalMove = true;
                    theGrid[currentCell.RowNumber-2, currentCell.ColumnNumber-1].IsLegalMove = true;
                    theGrid[currentCell.RowNumber+1, currentCell.ColumnNumber+2].IsLegalMove = true;
                    theGrid[currentCell.RowNumber+1, currentCell.ColumnNumber-2].IsLegalMove = true;
                    theGrid[currentCell.RowNumber-1, currentCell.ColumnNumber+2].IsLegalMove = true;
                    theGrid[currentCell.RowNumber-1, currentCell.ColumnNumber-2].IsLegalMove = true;
                    break;
                case "King":
                    break;
                case "Rook":
                    break;
                case "Pawn":
                    break;
                case "Bishop":
                    break;
                case "Queen":
                    break;

            }
        }
        public void ClearBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].IsLegalMove = false;
                    theGrid[i, j].IsOccupaied = false;
                }
            }
        }
                
    }
}