using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1,CategoryId=1,ProductName="Su Bardagi",UnitsInStock=3,UnitPrice=20},
                new Product { ProductId = 2,CategoryId = 1,ProductName = "Cay Bardagi",UnitsInStock = 4,UnitPrice = 15},
                new Product { ProductId = 3,CategoryId=2,ProductName="Tabak",UnitsInStock=5,UnitPrice=27},
                new Product { ProductId = 4,CategoryId=2,ProductName="Tepsi",UnitsInStock=5,UnitPrice=100},
                new Product { ProductId = 5,CategoryId=2,ProductName="Cay Tabagi",UnitsInStock=8,UnitPrice=10}
            };    
        }
        public void Add(Product product)
        {
            _products.Add(product); 
        }

        public void Delete(Product product)
        {
            Product deletedProduct = null;

            deletedProduct = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(deletedProduct);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;   
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public void Update(Product product)
        {

            Product updatedProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            updatedProduct.ProductName = product.ProductName;   
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.UnitPrice = product.UnitPrice;   
            updatedProduct.UnitsInStock = product.UnitsInStock; 
        }

       
    }
}
