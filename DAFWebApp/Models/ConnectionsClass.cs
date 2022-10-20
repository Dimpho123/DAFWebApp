using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAFWebApp.Models;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Configuration;


namespace DAFWebApp.Models
{
    public class ConnectionsClass:DbContext
    {
        public ConnectionsClass(DbContextOptions<ConnectionsClass> options) : base(options)
        {

        }
        public DbSet<Donations> Goods { get; set; }
        public DbSet<Disaster> NewDisaster { get; set; }
        public DbSet<Monetary> Monetary { get; set; }
       

    }

}
  