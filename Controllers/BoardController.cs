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
            ViewBag.Board = myBoard;
            return View();
        }
    }
}