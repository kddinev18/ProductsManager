using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Models.Data;

namespace WebApp.DAL
{
    public interface IProductManagerDbContex
    {
        public DbSet<Product> Products { get; set; }
    }
}
