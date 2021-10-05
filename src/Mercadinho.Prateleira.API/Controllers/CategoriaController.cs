using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok("funcionou");
        }
    }
}
