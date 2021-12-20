using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DeThi_WAD.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Dethi_WAD") { }

        public DbSet<Contact> Contacts { get; set; }
    }
}