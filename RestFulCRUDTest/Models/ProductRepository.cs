using RestFulCRUDTest.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFulCRUDTest.Models
{
    public class ProductRepository :IProductRepository
    {
        //private List<Product> products = new List<Product>();
        ProductsContext db = new ProductsContext();
        //private int _nextId = 1;

        public ProductRepository()
        {
            if (db.Products.Count() < 1)
            {
                Add(
                    new Product
                    {
                        Name = "Tomato soup",
                        Description = "this is made to drink when eating a meal made out of tomatoes",
                        Category = "Groceries",
                        Price = 1.39M
                    }
                    );

                Add(
                    new Product
                    {

                        Name = "Yo-yo",
                        Description = "For kids to play with",
                        Category = "Toys",
                        Price = 3.75M

                    }
                    );

                Add(
                    new Product
                    {
                        Name = "Hammer",
                        Description = "Can be use with nails by a handyman",
                        Category = "Hardware",
                        Price = 16.99M


                    }
                    );
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(p=>p.Id == id);
        }


        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            db.Products.Add(item);
            db.SaveChanges();
            return item;
           
        }

        public void Remove (int id)
        {
            Product item = db.Products.Find(id);
            db.Products.Remove(item);
            db.SaveChanges();
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var index = db.Products.Find(item.Id);

            if  (index!= null)
            {
                db.Products.Remove(index);
                db.Products.Add(item);
                db.SaveChanges();
                return true;
            }

            return false;

        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}