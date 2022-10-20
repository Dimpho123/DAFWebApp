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
using Microsoft.AspNetCore.Authorization;

namespace DAFWebApp.Controllers
{
    public class DisasterController : Controller
    {

        //List<Disaster> disaster = new List<Disaster>();


        private readonly ConnectionsClass _cc;

        public DisasterController(ConnectionsClass cc)
        {

            _cc = cc;

        }
   
        // [Authorize(Roles = "Admin,User")]
        public IActionResult NewDisaster()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewDisaster(Disaster disaster)
        {
            _cc.Add(disaster);
            _cc.SaveChanges();
            ViewBag.message = "The Record  " + disaster.Location + "  Is  Successfully Captured..";
            return View();
        }
       // [Authorize]
       public IActionResult DisasterList()
        {
            
            return View(_cc.NewDisaster.ToList());
        }

    }
}
      