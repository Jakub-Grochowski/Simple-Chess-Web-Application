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

            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].IsOccupaied = true;
            switch (chessPiece)
            {
                case "Knight":
                    if(isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber+2, currentCell.ColumnNumber+1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber+2, currentCell.ColumnNumber-1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber-2, currentCell.ColumnNumber+1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber-2, currentCell.ColumnNumber-1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber+1, currentCell.ColumnNumber+2].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber+1, currentCell.ColumnNumber-2].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber-1, currentCell.ColumnNumber+2].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber-1, currentCell.ColumnNumber-2].IsLegalMove = true;
                    break;
                case "King":
                    if(isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber -1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber +1, currentCell.ColumnNumber + 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber +1, currentCell.ColumnNumber - 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber+1, currentCell.ColumnNumber ].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber -1, currentCell.ColumnNumber + 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber -1, currentCell.ColumnNumber - 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber -1, currentCell.ColumnNumber ].IsLegalMove = true;
                    break;
                case "Rook":
                    for (int i = currentCell.RowNumber+1; i< Size; i++)
                    {
                        theGrid[i, currentCell.ColumnNumber].IsLegalMove = true;
                    }
                    for (int i = currentCell.RowNumber -1; i >= 0; i--)
                    {
                        theGrid[i, currentCell.ColumnNumber].IsLegalMove = true;
                    }
                    
                    for (int i = currentCell.ColumnNumber + 1; i < Size; i++)
                    {
                        theGrid[currentCell.RowNumber, i].IsLegalMove = true;
                    }
                    for (int i = currentCell.ColumnNumber -1; i >=0; i--)
                    {
                        theGrid[currentCell.RowNumber, i].IsLegalMove = true;
                    }
                    break;
                case "Pawn":
                    break;
                case "Bishop":
                    int temp = 0;
                    for (int i = currentCell.RowNumber + 1; i < Size; i++)
                    {
                        temp++;
                        if(isSafe(i, currentCell.ColumnNumber+temp))
                        theGrid[i, currentCell.ColumnNumber+temp].IsLegalMove = true;
                    }
                    temp = 0;
                    for (int i = currentCell.RowNumber + 1; i < Size; i++)
                    {
                        temp++;
                        if (isSafe(i, currentCell.ColumnNumber - temp))
                            theGrid[i, currentCell.ColumnNumber-temp].IsLegalMove = true;
                    }
                    temp = 0;
                    for (int i = currentCell.ColumnNumber - 1; i >= 0; i--)
                    {
                        temp++;
                        if (isSafe(currentCell.RowNumber -temp, i))
                            theGrid[currentCell.RowNumber - temp, i].IsLegalMove = true;
                    }
                    temp = 0;
                    for (int i = currentCell.ColumnNumber + 1; i < Size; i++)
                    {
                        temp++;
                        if (isSafe(currentCell.RowNumber - temp, i))
                            theGrid[currentCell.RowNumber - temp, i].IsLegalMove = true;
                    }
                    break;
                case "Queen":
                    //Here i just past King Rook and Bishop code so i didnt have to think about it.
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].IsLegalMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].IsLegalMove = true;
                    for (int i = currentCell.RowNumber + 1; i < Size; i++)
                    {
                        theGrid[i, currentCell.ColumnNumber].IsLegalMove = true;
                    }
                    for (int i = currentCell.RowNumber - 1; i >= 0; i--)
                    {
                        theGrid[i, currentCell.ColumnNumber].IsLegalMove = true;
                    }

                    for (int i = currentCell.ColumnNumber + 1; i < Size; i++)
                    {
                        theGrid[currentCell.RowNumber, i].IsLegalMove = true;
                    }
                    for (int i = currentCell.ColumnNumber - 1; i >= 0; i--)
                    {
                        theGrid[currentCell.RowNumber, i].IsLegalMove = true;
                    }
                    // and i change temp name to temp2
                    int temp2 = 0;
                    for (int i = currentCell.RowNumber + 1; i < Size; i++)
                    {
                        temp2++;
                        if (isSafe(i, currentCell.ColumnNumber + temp2))
                            theGrid[i, currentCell.ColumnNumber + temp2].IsLegalMove = true;
                    }
                    temp2 = 0;
                    for (int i = currentCell.RowNumber + 1; i < Size; i++)
                    {
                        temp2++;
                        if (isSafe(i, currentCell.ColumnNumber - temp2))
                            theGrid[i, currentCell.ColumnNumber - temp2].IsLegalMove = true;
                    }
                    temp2 = 0;
                    for (int i = currentCell.ColumnNumber - 1; i >= 0; i--)
                    {
                        temp2++;
                        if (isSafe(currentCell.RowNumber - temp2, i))
                            theGrid[currentCell.RowNumber - temp2, i].IsLegalMove = true;
                    }
                    temp2 = 0;
                    for (int i = currentCell.ColumnNumber + 1; i < Size; i++)
                    {
                        temp2++;
                        if (isSafe(currentCell.RowNumber - temp2, i))
                            theGrid[currentCell.RowNumber - temp2, i].IsLegalMove = true;
                    }
                    break;

            }
        }

        private bool isSafe(int row, int col)
        {
            if (row < Size && row>=0 && col < Size && col>=0) return true;
            else return false;
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