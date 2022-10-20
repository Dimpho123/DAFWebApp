using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAFWebApp.Models;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Security.Claims;
using Xamarin.Essentials;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace DAFWebApp.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        //GET:Login
        [HttpGet]
        public IActionResult Login(string email,string password)
        {
            ClaimsIdentity identity = null;
            bool isAuthentication = false;
            if(email=="Admin@gmail.com" && password == "123")
            {
                identity = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Email,email),
                        new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentication = true;
            }
            if (email == "User" && password == "123")
            {
                identity = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Email,email),
                        new Claim(ClaimTypes.Role,"User")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentication = true;
            }
            if (isAuthentication)
            {
                var princepl = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princepl);
                return RedirectToAction("Login");
            }
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Server=tcp:st10129950base.database.windows.net,1433;Initial Catalog=ADFBase;Persist Security Info=False;User ID=ST10129950;Password=Evangelina27;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        public IActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Users where email ='"+acc.email+"' and password = '"+acc.password+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                    return View("Verify");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        
        }
       
    }
}
