using Project.API.Repository;
using Project.Data.Entity;
using Project.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repository
{
    public class RepositoryProduct: RepositoryGeneric<Product> , IProduct
    {
    }
}
