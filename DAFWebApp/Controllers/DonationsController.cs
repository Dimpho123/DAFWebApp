using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAFWebApp.Models;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace DAFWebApp.Controllers
{

    public class DonationsController : Controller
    {

          SqlConnection con = new SqlConnection();
          SqlCommand cmd = new SqlCommand();
          SqlDataReader dr;
          List<Donations> ds = new List<Donations>();


          private readonly ConnectionsClass _cc;

          public DonationsController(ConnectionsClass cc)
          {

              _cc = cc;
          }
          public IActionResult Goods()
          {
              return View();
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult Goods(Donations ds)
          {
              _cc.Add(ds);
              _cc.SaveChanges();
              ViewBag.message = "The Record" + ds.ProductName + "Is Successfully Captured..";
              return View();
          }
     
       //   [HttpGet]
         public IActionResult NewDonations()
          {
              //var NewDonations = _cc.NewDonations.ToList();
              return View(_cc.Goods.ToList());
          }

      } }
       
   