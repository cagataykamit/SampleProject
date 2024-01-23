using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class StockController : Controller
    {
        IStockService _StockService;

        public StockController(IStockService StockService)
        {
            _StockService = StockService;
        }

        [HttpGet("Stock/getall")]
        public IActionResult GetAll()
        {

            var result = _StockService.GetAll();
            if (result.Success)
            {
                //return Ok(result);
                return View(result.Data);
            }
            else
            {
                return BadRequest(result);
            }

        }


        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(Stock Stock)
        {
            var result = _StockService.Add(Stock);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _StockService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

    }
}
