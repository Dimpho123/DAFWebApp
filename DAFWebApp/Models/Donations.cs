using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace DAFWebApp.Models
{
    public class Donations
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public IEnumerator<Donations> GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
