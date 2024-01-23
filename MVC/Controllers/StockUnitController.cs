using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class StockUnitController : Controller
    {
        IStockUnitService _stockUnitService;

        public StockUnitController(IStockUnitService stockUnitService)
        {
            _stockUnitService = stockUnitService;
        }

        [HttpGet("StockUnit/getall")]
        public IActionResult GetAll()
        {

            var result = _stockUnitService.GetAll();
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
        public IActionResult Add(StockUnit stockUnit)
        {
            var result = _stockUnitService.Add(stockUnit);
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
