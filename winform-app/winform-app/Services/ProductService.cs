using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winform_app.Model;

namespace winform_app.Services
{

    public class ProductService
    {
        public List<ProductModel> List(int limit = int.MaxValue)
        {
            using (var db = new SimpleStoreEntities())
            {
                var list = db.Products.Take(limit).ToList();
                var result = new List<ProductModel>();
                foreach (var product in list)
                {
                    ProductModel productModel = new ProductModel();
                    productModel.Id = product.Id;
                    productModel.Title = product.Title;
                    productModel.Description = product.Description;
                    productModel.ImageUrl = product.ImageUrl;
                    productModel.Price = product.Price;
                    productModel.CreatedAt = product.CreatedAt;
                    productModel.Published = product.Published;
                    productModel.Tags = product.Tags;
                    productModel.StockQuantity = product.StockQuantity;
                    result.Add(productModel);
                }
                return result;
            }
        }
        public void Create(ProductModel product)
        {
            using (var db = new SimpleStoreEntities())
            {
                var newProduct = new Product();
                newProduct.Id = product.Id;
                newProduct.Title = product.Title;
                newProduct.Description = product.Description;
                newProduct.ImageUrl = product.ImageUrl;
                newProduct.Price = product.Price;
                newProduct.CreatedAt = DateTime.Now;
                newProduct.Published = product.Published;
                newProduct.Tags = product.Tags;
                newProduct.StockQuantity = product.StockQuantity;
                newProduct.Price = product.Price;

                db.Products.Add(newProduct);
                db.SaveChanges();
            }
        }
        public void Edit(ProductModel product)
        {
            using (var db = new SimpleStoreEntities())
            {
                var existingProduct = db.Products.Find(product.Id);

                if (existingProduct != null)
                {
                    existingProduct.Title = product.Title;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.ImageUrl = product.ImageUrl;
                    existingProduct.Published = product.Published;
                    existingProduct.Tags = product.Tags;
                    existingProduct.StockQuantity = product.StockQuantity;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Product not found.");
                }
            }
        }
        public void Delete(int productId)
        {
            using (var db = new SimpleStoreEntities())
            {
                var productToDelete = db.Products.Find(productId);
                if (productToDelete != null)
                {
                    db.Products.Remove(productToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception ("Product not found");
                }
            }
        }
        public bool Exists(ProductModel product)
        {
            using (var db = new SimpleStoreEntities())
            {
                return db.Products.Any(p => p.Title == product.Title);
            }
        }

    }
}
