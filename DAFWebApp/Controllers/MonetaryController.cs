using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAFWebApp.Models;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


namespace DAFWebApp.Controllers
{
    public class MonetaryController : Controller
    {
        //List<Monetary> disaster = new List<Monetary>();


        private readonly ConnectionsClass _cc;

        public MonetaryController(ConnectionsClass cc)
        {

            _cc = cc;
        }
        public IActionResult MonetaryRecieved()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MonetaryRecieved(Monetary monetary)
        {
            _cc.Add(monetary);
            _cc.SaveChanges();
            ViewBag.message = "The Record  " + monetary.Amount + "  Is  Successfully Captured..";
            return View();
            
        }
        [HttpGet]
        public IActionResult MonetaryCaptured()
        {
            return View(_cc.Monetary.ToList());
        }
    }
}
