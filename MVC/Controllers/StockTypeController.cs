using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class StockTypeController : Controller
    {
        IStockTypeService _stockTypeService;

        public StockTypeController(IStockTypeService stockTypeService)
        {
            _stockTypeService = stockTypeService;
        }

        [HttpGet("stocktype/getall")]
        public IActionResult GetAll()
        {

            var result = _stockTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpPost("add")]
        public IActionResult Add(StockType stockType)
        {
            var result = _stockTypeService.Add(stockType);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
