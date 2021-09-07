using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product(){CategoryId=1,UnitPrice=100,ProductId=1,ProductName="Fisher Price Çıngırak"},
            new Product(){CategoryId=1,UnitPrice=90,ProductId=2,ProductName="Fisher Price Dişlik"},
            new Product(){CategoryId=2,UnitPrice=1500,ProductId=3,ProductName="Pilsan Akülü Araba"},
            new Product(){CategoryId=2,UnitPrice=1800,ProductId=4,ProductName="Pilsan Attack Akülü Araba"},
            new Product(){CategoryId=3,UnitPrice=200,ProductId=5,ProductName="Lego Sörf Kayığı"},
            new Product(){CategoryId=4,UnitPrice=320,ProductId=6,ProductName="Pilsan Super Scooter"},
            };

        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productDelete;
            productDelete= _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
           return _products.ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;

        }
    }
}
