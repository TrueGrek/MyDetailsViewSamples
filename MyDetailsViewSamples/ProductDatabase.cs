using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDetailsViewSamples
{
    public class ProductDatabase
    {
        private static List<Product> _products;

        public static List<Product> Products {

            get {
                if(_products == null)
                {
                    _products = new List<Product>();
                    _products.Add(new Product { Id = 1, Name = "Forbes", Price = 21.0 });
                    _products.Add(new Product { Id = 2, Name = "Success", Price = 22.0 });
                }
                return _products;
            }

            set {
                _products = value;
            } 
        }

        public List<Product> SelectAllProducts()
        {
            return Products;
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }
        public void RemoveProduct(Product p)
        {
            Products.Remove(p);
        }
        public void UpdateProduct(Product p)
        {
            int index = Products.IndexOf(p);
            Products.Remove(p);
            Products.Insert(index,p);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Product()
        {

        }

        public override bool Equals(object obj)
        {
            Product temp = obj as Product;
            if (temp == null)
            {
                return false;
            }
            return temp.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}