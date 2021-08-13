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
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Board()
        {
            Board myBoard = new Board();
            myBoard.MarkNextLegalMoves(myBoard.theGrid[3, 3], "Knight");
            ViewBag.Board = myBoard;

            return View();
        }
        public ActionResult test()
        {
            Board myBoard = new Board();
            myBoard.MarkNextLegalMoves(myBoard.theGrid[4, 4], "Knight");
            ViewBag.Board = myBoard;
            return View("Board");
        }
    }
}