using Microsoft.EntityFrameworkCore;
using Project.API.Repository;
using Project.Data.Config;
using Project.Data.Entity;
using Project.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repository
{
    public class RepositoryProduct : RepositoryGeneric<Product>, IProduct
    {
        private DbContextOptions<ContextBaseApp> db;

        public RepositoryProduct()
        {
            db = new DbContextOptions<ContextBaseApp>();
        }
        public async Task<List<Product>> GetProductscustomized()
        {
            using (var data = new ContextBaseApp(db))
            {
                return await data.Set<Product>().ToListAsync();
            }
        }
    }
}
