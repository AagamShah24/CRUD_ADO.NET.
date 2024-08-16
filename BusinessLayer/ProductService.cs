using BusinessLayer.Entities;
using DataBaseLayer;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProductService 
    {
         ProductRepository _productRepository = new ProductRepository();

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}