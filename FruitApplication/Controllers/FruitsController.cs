using BusinessLogic;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitsController : Controller
    {
        private readonly IBLFruit _bLFruit;

      
        public FruitsController(IBLFruit iBLFruit)
        {
            _bLFruit = iBLFruit;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FruitDTO fruit)
        {
            FruitDTO fruitResult = await _bLFruit.Update(id,fruit);


            if (fruitResult != null)
            {
                return Json(new { status = 200, msg = "Fruit Updated!", date = DateTime.Now });
            }
            else
            {
                return Json(new { status = 404, msg = "Fruit not found!", date = DateTime.Now });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            FruitDTO fruit = await _bLFruit.FindById(id);
           

            if (fruit!=null)
            {
                return Json(new { status = 200, msg = fruit, date = DateTime.Now });
            }
            else
            {
                return Json(new { status = 404, msg = "Fruit not found", date = DateTime.Now });
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool flag = await _bLFruit.Delete(id);
            string message = (flag==true)? "Fruit Deleted correctly": "Fruit not found";
            int statusCode= (flag == true) ? 200 : 404;
            return Json(new { status = statusCode, msg = message, date =DateTime.Now  });
        }

        // GET: api/Fruits
        [HttpGet("FindAll")]
        public async Task<ActionResult<IEnumerable<FruitDTO>>> FindAll()
        {
            return Ok(await _bLFruit.FindAll());
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FruitDTO fruit)
        {
            //aqui quede
            if (ModelState.IsValid)
            {
                return Json(new { status = 200, msg = "Saved correctly!", Content= await _bLFruit.Save(fruit) });
            }
            else
            {
                return Json(new { status = 404, msg = "An error ocurred!", Content = await _bLFruit.Save(fruit) });
            }
        }
    }
}
