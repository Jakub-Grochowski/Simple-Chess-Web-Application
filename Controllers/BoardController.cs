using Simple_Chess_Web_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_Chess_Web_Application.Controllers
{
    public class BoardController : Controller
    {
       static Board myBoard;
        static String picked_chessPiece;
        static bool emptyBoard;
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Board()
        {
            emptyBoard = true;
            myBoard = new Board();           
            ViewBag.Board = myBoard;
            ViewBag.empty = emptyBoard;
            ViewBag.PickedChess = false;

            return View();
        }
        public ActionResult Move(int width, int heigh)
        {
            String hrefJPG;
            if (emptyBoard)
            {
                if ((width + heigh) % 2 == 0)
                {
                    hrefJPG = "/Content/Photos/" + picked_chessPiece+"Light"+".png";
                }
                else { hrefJPG = "/Content/Photos/" + picked_chessPiece + "Dark" + ".png"; }
                myBoard.MarkNextLegalMoves(myBoard.theGrid[width, heigh], picked_chessPiece);
                emptyBoard = false;
            }
            else {             if(myBoard.theGrid[width,heigh].IsLegalMove )
            {
                    if ((width + heigh) % 2 == 0)
                    {
                        hrefJPG = "/Content/Photos/" + picked_chessPiece + "Light" + ".png";
                    }
                    else { hrefJPG = "/Content/Photos/" + picked_chessPiece + "Dark" + ".png"; }
                    myBoard.MarkNextLegalMoves(myBoard.theGrid[width, heigh], picked_chessPiece);
            }
            else
            {
                ViewBag.Board = myBoard;
                return View("Board");
            }
            }

            // myBoard.MarkNextLegalMoves(myBoard.theGrid[4, 4], "Knight");
            ViewBag.href = hrefJPG;
            ViewBag.Board = myBoard;
            ViewBag.empty = emptyBoard;
            return View("Board");
        }

        public ActionResult PickChess(String chessPiece)
        {
            myBoard.ClearBoard();
            picked_chessPiece = chessPiece;
            ViewBag.Board = myBoard;
            emptyBoard = true;
            ViewBag.empty = emptyBoard;
            ViewBag.PickedChess = true;
            return View("Board");
        }
    }
}