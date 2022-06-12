using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data.Entity;
using Project.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.API.Controllers
{

    [Authorize]
    public class ProductAPIController : Controller
    {
        private readonly IProduct _product;

        public ProductAPIController(IProduct product)
        {
            _product = product;
        }
 
        [HttpGet("/api/products")]
        public async Task<JsonResult> products()
        {
            return Json(await this._product.Get());
        }

        [HttpPost("/api/createProduct")]
        public async Task createProduct ([FromBody] Product product)
        {
            await Task.FromResult(this._product.Create(product));
        }
    }
}
