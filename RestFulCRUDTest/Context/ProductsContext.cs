using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RestFulCRUDTest.Models;
using System.Data.Entity;

namespace RestFulCRUDTest.Context
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
   
    }
}