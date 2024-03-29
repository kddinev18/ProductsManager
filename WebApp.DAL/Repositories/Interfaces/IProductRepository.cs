﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Models.Data;
using WebApp.DTO;

namespace WebApp.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<int> GetCountAsync();
        public bool CreateProduct(Product product, ref string errorMessage);
        public Product GetProductById(int id);
        public IEnumerable<Product> GetProducts(int pagingSize, int skipAmount);
        public bool EditProduct(Product product , ref string errorMessage);
        public bool DeleteProduct(int id);
        public bool DeleteProduct(Product product);
    }
}
