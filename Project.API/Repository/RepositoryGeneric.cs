using Project.API.Interface;
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


        public Task Create(T obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T obj)
        {
            throw new NotImplementedException();
        }



        public Task Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
