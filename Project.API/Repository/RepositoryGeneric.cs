using Microsoft.EntityFrameworkCore;
using Project.Data.Config;
using Project.Data.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Repository
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private DbContextOptions<ContextBaseApp> db;

        #region Dispose https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a FileStream instance.
        FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                fs.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion



        public RepositoryGeneric()
        {
            db = new DbContextOptions<ContextBaseApp>();
        }

        public async Task Create(T obj)
        {
            using (var data = new ContextBaseApp(db))
            {
                await data.Set<T>().AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var data = new ContextBaseApp(db))
            {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }



        public async Task<T> Get(int Id)
        {
            using (var data = new ContextBaseApp(db))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> Get()
        {
            using (var data = new ContextBaseApp(db))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T obj)
        {
            using (var data = new ContextBaseApp(db))
            {
                data.Set<T>().Update(obj);
                await data.SaveChangesAsync();
            }
        }
    }
}
